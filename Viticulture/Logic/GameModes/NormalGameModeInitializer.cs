using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Cards.Parents;
using Viticulture.Logic.State;
using Viticulture.Utils;

namespace Viticulture.Logic.GameModes
{
    [Export(typeof(INormalGameModeInitializer))]
    public class NormalGameModeInitializer : GameModeInitializer, INormalGameModeInitializer
    {
        private readonly IEnumerable<MamaCard> _mamaCards;
        private readonly IEnumerable<PapaCard> _papaCards;

        [ImportingConstructor]
        public NormalGameModeInitializer([ImportMany] IEnumerable<MamaCard> mamaCards,
            [ImportMany] IEnumerable<PapaCard> papaCards)
        {
            _mamaCards = mamaCards;
            _papaCards = papaCards;
        }

        public override async void Initialize(IGameState gameState)
        {
            var mamaCard = _mamaCards.RandomOrDefault();
            var papaCard = _papaCards.RandomOrDefault();

            await mamaCard.Setup(gameState);
            await papaCard.Setup(gameState);

            gameState.NumberOfRounds = 7;
        }
    }
}