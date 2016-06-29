namespace Viticulture.Logic.Cards.Vines
{
    public class PinotVineCard : VineCard
    {
        public override string Name => "Pinot";
        public override bool RequiresIrigation => false;
        public override bool RequiresTODO => false;
        public override int RedValue => 0;
        public override int WhiteValue => 1;
    }
}