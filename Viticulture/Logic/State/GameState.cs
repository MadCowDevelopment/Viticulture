using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;
using Viticulture.Logic.Cards.Automa;
using Viticulture.Logic.Cards.Orders;
using Viticulture.Logic.Cards.Vines;
using Viticulture.Logic.Cards.Visitors;
using Viticulture.Logic.Cards.Visitors.Summer;
using Viticulture.Logic.Pieces;
using Viticulture.Logic.Pieces.Structures;

namespace Viticulture.Logic.State
{
    [Export(typeof(IGameState))]
    public class GameState : PropertyChangedBase, IGameState
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IEnumerable<AutomaCard> _automaCards;
        private readonly List<VisitorCard> _visitorCards;
        private readonly List<OrderCard> _orderCards;
        private readonly List<VineCard> _vineCards;

        private List<Worker> _workers;

        private List<Grape> _redGrapes;

        private List<Grape> _whiteGrapes;
        private List<Wine> _redWines;
        private List<Wine> _whiteWines;
        private List<Wine> _blushWines;
        private List<Wine> _sparklingWines;

        [ImportingConstructor]
        public GameState(
            IEventAggregator eventAggregator,
            [ImportMany] IEnumerable<VineCard> vineCards,
            [ImportMany] IEnumerable<OrderCard> orderCards,
            [ImportMany] IEnumerable<VisitorCard> visitorCards,
            [ImportMany] IEnumerable<AutomaCard> automaCards)
        {
            _eventAggregator = eventAggregator;
            _automaCards = automaCards;

            _vineCards = vineCards.ToList();
            _orderCards = orderCards.ToList();
            _visitorCards = visitorCards.ToList();

            PropertyChanged += StateChanged;
        }

        private GameState()
        {
        }

        private void StateChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            _eventAggregator.PublishOnCurrentThread(new GameStateChanged(this, e.PropertyName));
        }

        public Grande Grande { get; private set; }
        public int Money { get; set; }
        public Trellis Trellis { get; private set; }
        public Irigation Irigation { get; private set; }
        public Yoke Yoke { get; private set; }
        public TastingRoom TastingRoom { get; private set; }
        public Cottage Cottage { get; private set; }
        public Windmill Windmill { get; private set; }
        public MediumCellar MediumCellar { get; private set; }
        public LargeCellar LargeCellar { get; private set; }
        public IEnumerable<Worker> Workers => _workers;
        public Deck<VineCard> VineDeck { get; private set; }
        public Deck<VisitorCard> SummerVisitorDeck { get; private set; }
        public Deck<VisitorCard> WinterVisitorDeck { get; private set; }
        public Deck<OrderCard> OrderDeck { get; private set; }
        public Deck<AutomaCard> AutomaDeck { get; private set; }

        public Field Field1 { get; private set; }
        public Field Field2 { get; private set; }
        public Field Field3 { get; private set; }
        public IEnumerable<Field> Fields => new List<Field> { Field1, Field2, Field3 };
        public IEnumerable<Wine> RedWines => _redWines;
        public IEnumerable<Wine> WhiteWines => _whiteWines;
        public IEnumerable<Wine> BlushWines => _blushWines;
        public IEnumerable<Wine> SparklingWines => _sparklingWines;
        public IEnumerable<Grape> RedGrapes => _redGrapes;
        public IEnumerable<Grape> WhiteGrapes => _whiteGrapes;

        public Hand Hand { get; private set; }
        public int RemainingBonusActions { get; set; }
        public int Round { get; set; }
        public Season Season { get; set; }
        public int VictoryPoints { get; set; }

        public Worker NeutralWorker { get; private set; }
        public AutomaCard AutomaCard { get; set; }
        public int NumberOfRounds { get; set; }
        public int ResidualMoney { get; set; }

        public IEnumerable<GamePiece> Pieces
            => _workers.Concat(Structures.OfType<GamePiece>()).Concat(new List<GamePiece> { Grande });

        public IEnumerable<Structure> Structures => new List<Structure>
        {
            Trellis,
            Irigation,
            Yoke,
            Windmill,
            Cottage,
            MediumCellar,
            LargeCellar,
            TastingRoom
        };

        public IEnumerable<Wine> Wines => RedWines.Union(WhiteWines).Union(BlushWines).Union(SparklingWines);
        public IEnumerable<Grape> Grapes => RedGrapes.Union(WhiteGrapes);
        public IEnumerable<Worker> AllWorkers => Workers.Union(new List<Worker> {NeutralWorker, Grande});

        public void Reset()
        {
            VictoryPoints = 0;
            Money = 0;
            NumberOfRounds = 0;
            ResidualMoney = 0;
            RemainingBonusActions = 0;
            Round = 1;

            Hand = new Hand();

            VineDeck = new Deck<VineCard>(Hand, _vineCards);
            OrderDeck = new Deck<OrderCard>(Hand, _orderCards);
            AutomaDeck = new Deck<AutomaCard>(Hand, _automaCards);
            SummerVisitorDeck = new Deck<VisitorCard>(Hand, _visitorCards.Where(p => p.Season == Season.Summer));
            WinterVisitorDeck = new Deck<VisitorCard>(Hand, _visitorCards.Where(p => p.Season == Season.Winter));

            Yoke = new Yoke(_eventAggregator);
            Trellis = new Trellis(_eventAggregator);
            Cottage = new Cottage(_eventAggregator);
            Windmill = new Windmill(_eventAggregator);
            Irigation = new Irigation(_eventAggregator);
            LargeCellar = new LargeCellar(_eventAggregator);
            TastingRoom = new TastingRoom(_eventAggregator);
            MediumCellar = new MediumCellar(_eventAggregator);

            Field1 = new Field(_eventAggregator, 5);
            Field2 = new Field(_eventAggregator, 6);
            Field3 = new Field(_eventAggregator, 7);

            Grande = new Grande(_eventAggregator);
            NeutralWorker = new Worker(_eventAggregator);

            _workers = new List<Worker>();
            for (var i = 0; i < 5; i++)
            {
                _workers.Add(new Worker(_eventAggregator));
            }

            InitializeGrapes(out _redGrapes, GrapeColor.Red);
            InitializeGrapes(out _whiteGrapes, GrapeColor.White);

            InitializeWines(out _redWines, WineType.Red, 9);
            InitializeWines(out _whiteWines, WineType.White, 9);
            InitializeWines(out _blushWines, WineType.Blush, 6);
            InitializeWines(out _sparklingWines, WineType.Sparkling, 3);
        }

        private void InitializeWines(out List<Wine> wines, WineType type, int number)
        {
            wines = new List<Wine>();
            for (int i = 9 - number; i < 9; i++)
            {
                wines.Add(new Wine(_eventAggregator, i + 1, type));
            }
        }

        public GameState Clone()
        {
            var gameState = new GameState();
            gameState.VictoryPoints = VictoryPoints;
            gameState.Money = Money;
            gameState.NumberOfRounds = NumberOfRounds;
            gameState.ResidualMoney = ResidualMoney;
            gameState.RemainingBonusActions = RemainingBonusActions;
            gameState.Round = Round;

            gameState.Hand = Hand.Clone() as Hand;

            gameState.VineDeck = VineDeck.Clone();
            gameState.OrderDeck = OrderDeck.Clone();
            gameState.AutomaDeck = AutomaDeck.Clone();
            gameState.SummerVisitorDeck = SummerVisitorDeck.Clone();
            gameState.WinterVisitorDeck = WinterVisitorDeck.Clone();

            gameState.Yoke = Yoke.Clone() as Yoke;
            gameState.Trellis = Trellis.Clone() as Trellis;
            gameState.Cottage = Cottage.Clone() as Cottage;
            gameState.Windmill = Windmill.Clone() as Windmill;
            gameState.Irigation = Irigation.Clone() as Irigation;
            gameState.LargeCellar = LargeCellar.Clone() as LargeCellar;
            gameState.TastingRoom = TastingRoom.Clone() as TastingRoom;
            gameState.MediumCellar = MediumCellar.Clone() as MediumCellar;

            gameState.Field1 = Field1.Clone() as Field;
            gameState.Field2 = Field2.Clone() as Field;
            gameState.Field3 = Field3.Clone() as Field;

            gameState.Grande = Grande.Clone() as Grande;
            gameState.NeutralWorker = NeutralWorker.Clone() as Worker;

            gameState._workers = new List<Worker>();
            for (var i = 0; i < 5; i++)
            {
                gameState._workers.Add(_workers[i].Clone() as Worker);
            }

            gameState._redGrapes = new List<Grape>();
            foreach (var redGrape in _redGrapes)
            {
                gameState._redGrapes.Add(redGrape.Clone() as Grape);
            }

            gameState._whiteGrapes = new List<Grape>();
            foreach (var whiteGrape in _whiteGrapes)
            {
                gameState._whiteGrapes.Add(whiteGrape.Clone() as Grape);
            }

            gameState._redWines = new List<Wine>();
            foreach (var redWine in _redWines)
            {
                gameState._redWines.Add(redWine.Clone() as Wine);
            }

            gameState._whiteWines = new List<Wine>();
            foreach (var whiteWine in _whiteWines)
            {
                gameState._whiteWines.Add(whiteWine.Clone() as Wine);
            }

            gameState._blushWines = new List<Wine>();
            foreach (var blushWine in _blushWines)
            {
                gameState._blushWines.Add(blushWine.Clone() as Wine);
            }

            gameState._sparklingWines = new List<Wine>();
            foreach (var sparklingWine in _sparklingWines)
            {
                gameState._sparklingWines.Add(sparklingWine.Clone() as Wine);
            }

            return gameState;
        }

        public void SetFromClone(GameState clone)
        {
            VictoryPoints = clone.VictoryPoints;
            Money = clone.Money;
            NumberOfRounds = clone.NumberOfRounds;
            ResidualMoney = clone.ResidualMoney;
            RemainingBonusActions = clone.RemainingBonusActions;
            Round = clone.Round;

            Hand.SetFromClone(clone.Hand, Entities);

            VineDeck.SetFromClone(clone.VineDeck, Entities);
            OrderDeck.SetFromClone(clone.OrderDeck, Entities);
            AutomaDeck.SetFromClone(clone.AutomaDeck, Entities);
            SummerVisitorDeck.SetFromClone(clone.SummerVisitorDeck, Entities);
            WinterVisitorDeck.SetFromClone(clone.WinterVisitorDeck, Entities);

            Yoke.SetFromClone(clone.Yoke, Entities);
            Trellis.SetFromClone(clone.Trellis, Entities);
            Cottage.SetFromClone(clone.Cottage, Entities);
            Windmill.SetFromClone(clone.Windmill, Entities);
            Irigation.SetFromClone(clone.Irigation, Entities);
            LargeCellar.SetFromClone(clone.LargeCellar, Entities);
            TastingRoom.SetFromClone(clone.TastingRoom, Entities);
            MediumCellar.SetFromClone(clone.MediumCellar, Entities);

            Field1.SetFromClone(clone.Field1, Entities);
            Field2.SetFromClone(clone.Field2, Entities);
            Field3.SetFromClone(clone.Field3, Entities);

            Grande.SetFromClone(clone.Grande, Entities);
            NeutralWorker.SetFromClone(clone.NeutralWorker, Entities);

            for (var i = 0; i < 5; i++)
            {
                _workers[i].SetFromClone(clone.Workers.ElementAt(i), Entities);
            }

            for (int i = 0; i < 9; i++)
            {
                _redGrapes[i].SetFromClone(clone._redGrapes[i], Entities);
            }

            for (int i = 0; i < 9; i++)
            {
                _whiteGrapes[i].SetFromClone(clone._whiteGrapes[i], Entities);
            }

            for (int i = 0; i < 9; i++)
            {
                _redWines[i].SetFromClone(clone._redWines[i], Entities);
            }

            for (int i = 0; i < 9; i++)
            {
                _whiteWines[i].SetFromClone(clone._whiteWines[i], Entities);
            }
            for (int i = 0; i < 6; i++)
            {
                _blushWines[i].SetFromClone(clone._blushWines[i], Entities);
            }
            for (int i = 0; i < 3; i++)
            {
                _sparklingWines[i].SetFromClone(clone._sparklingWines[i], Entities);
            }
        }

        private IEnumerable<Entity> Entities
            =>
                _automaCards.OfType<Entity>()
                    .Concat(_orderCards)
                    .Concat(_vineCards)
                    .Concat(_visitorCards)
                    .Concat(_workers)
                    .Concat(Fields)
                    .Concat(Structures);

        public static int MinimumVictoryPoints => -5;

        private void InitializeGrapes(out List<Grape> grapes, GrapeColor color)
        {
            grapes = new List<Grape>();
            for (int i = 1; i <= 9; i++)
            {
                grapes.Add(new Grape(_eventAggregator, i, color));
            }
        }
    }

    public class GameStateChanged
    {
        public GameStateChanged(GameState gameState, string propertyName)
        {
            GameState = gameState;
            PropertyName = propertyName;
        }

        public GameState GameState { get; }
        public string PropertyName { get; }
    }

    public static class GameStateExtensions
    {
        public static Worker GetFirstAvailableWorker(this IGameState gameState)
        {
            if (gameState.NeutralWorker.IsBought && !gameState.NeutralWorker.HasBeenUsed)
                return gameState.NeutralWorker;
            if (gameState.Workers.Any(p => p.IsBought && !p.HasBeenUsed))
                return gameState.Workers.First(p => p.IsBought && !p.HasBeenUsed);
            if (gameState.Grande.IsBought && !gameState.Grande.HasBeenUsed)
                return gameState.Grande;

            return null;
        }

        public static IEnumerable<Wine> GetCellarByWineType(this IGameState gameState, WineType type)
        {
            switch (type)
            {
                case WineType.Red:
                    return gameState.RedWines;
                case WineType.White:
                    return gameState.WhiteWines;
                case WineType.Blush:
                    return gameState.BlushWines;
                case WineType.Sparkling:
                    return gameState.SparklingWines;
                default:
                    return Enumerable.Empty<Wine>();
            }
        }
    }
}
