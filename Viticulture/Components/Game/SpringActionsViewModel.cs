using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Components.Game
{
    [Export(typeof(ISpringActionsViewModel))]
    public class SpringActionsViewModel : ViewModel, ISpringActionsViewModel
    {
        private readonly IGameState _gameState;
        private readonly List<Benefit> _benefits = new List<Benefit>();

        [ImportingConstructor]
        public SpringActionsViewModel(IGameState gameState, IPlayerSelection playerSelection)
        {
            _gameState = gameState;
            _benefits.Add(new NoneBenefit());
            _benefits.Add(new VineBenefit());
            _benefits.Add(new OrderBenefit());
            _benefits.Add(new LiraBenefit());
            _benefits.Add(new VisitorBenefit(playerSelection));
            _benefits.Add(new VictoryPointBenefit());
            _benefits.Add(new WorkerBenefit());
        }

        public IEnumerable<Benefit> Benefits => _benefits;

        public void SelectBenefit(Benefit benefit)
        {
            benefit.Apply(_gameState);
            _gameState.Season = Season.Summer;
            _benefits.Remove(benefit);
        }
    }

    public class WorkerBenefit : Benefit
    {
        public override string Name => "Neutral worker";

        public override void OnApply(IGameState gameState)
        {
            gameState.NeutralWorker.IsBought = true;
        }
    }

    public class VictoryPointBenefit : Benefit
    {
        public override string Name => "1 VP";

        public override void OnApply(IGameState gameState)
        {
            gameState.VictoryPoints++;
        }
    }

    public class VisitorBenefit : Benefit
    {
        private readonly IPlayerSelection _playerSelection;

        public VisitorBenefit(IPlayerSelection playerSelection)
        {
            _playerSelection = playerSelection;
        }

        public override string Name => "Summer or winter visitor";

        public override async void OnApply(IGameState gameState)
        {
            var selection = await _playerSelection.Select("Benefit", "Which visitor card do you want?", "Summer", "Winter");

            if (selection == Selection.Option1) gameState.SummerVisitorDeck.DrawToHand();
            else gameState.WinterVisitorDeck.DrawToHand();
        }
    }

    public class LiraBenefit : Benefit
    {
        public override string Name => "1 Lira";
        public override void OnApply(IGameState gameState)
        {
            gameState.Money++;
        }
    }

    public class OrderBenefit : Benefit
    {
        public override string Name => "Order card";
        public override void OnApply(IGameState gameState)
        {
            gameState.OrderDeck.DrawToHand();
        }
    }

    public class VineBenefit : Benefit
    {
        public override string Name => "Vine card";
        public override void OnApply(IGameState gameState)
        {
            gameState.VineDeck.DrawToHand();
        }
    }

    public class NoneBenefit : Benefit
    {
        public override string Name => "None";

        public override void OnApply(IGameState gameState)
        {
        }
    }


    public abstract class Benefit
    {
        public abstract string Name { get; }

        public void Apply(IGameState gameState)
        {
            gameState.RemainingBonusActions++;
            OnApply(gameState);
        }

        public abstract void OnApply(IGameState gameState);
    }
}