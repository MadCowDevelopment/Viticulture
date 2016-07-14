using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Parents.Mamas
{
    public class ArielMamaCard : MamaCard
    {
        public override string Name => "Ariel";

        protected override void OnSetup(IGameState gameState)
        {
            gameState.Money += 2;
            gameState.SummerVisitorDeck.DrawToHand();
            gameState.OrderDeck.DrawToHand();
        }

        protected override string Benefits => "2 lira, 1 summer visitor and 1 order";
    }
}