using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Cards.Parents;
using Viticulture.Logic.State;
using Viticulture.Utils;

namespace Viticulture.Logic.GameModes
{
    public class NormalGameMode : GameMode
    {
        private readonly IEnumerable<MamaCard> _mamaCards;
        private readonly IEnumerable<PapaCard> _papaCards;

        [ImportingConstructor]
        public NormalGameMode([ImportMany] IEnumerable<MamaCard> mamaCards, [ImportMany] IEnumerable<PapaCard> papaCards)
        {
            _mamaCards = mamaCards;
            _papaCards = papaCards;
        }

        public override string Name => "Normal";

        public override string Description => "No special rules apply.";

        public override void Initialize(IGameState gameState)
        {
            var papaCard = _papaCards.RandomOrDefault();
            var mamaCard = _mamaCards.RandomOrDefault();

            papaCard.Setup(gameState);
            mamaCard.Setup(gameState);
        }
    }
}