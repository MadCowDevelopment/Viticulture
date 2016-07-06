namespace Viticulture.Logic.Cards.Vines
{
    public class CabernetSauvignonCard : VineCard
    {
        public override string Name => "Cabernet Sauvignon";
        public override bool RequiresIrigation => true;
        public override bool RequiresTrellis => true;
        public override int RedValue => 2;
        public override int WhiteValue => 2;
    }
}