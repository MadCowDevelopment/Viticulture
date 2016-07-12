namespace Viticulture.Logic.Cards.Vines
{
    public abstract class ChardonnayCard : VineCard
    {
        public override string Name => "Chardonnay";
        public override bool RequiresIrigation => true;
        public override bool RequiresTrellis => true;
        public override int RedValue => 0;
        public override int WhiteValue => 4;
    }

    public class Chardonnay1 : ChardonnayCard { }
    public class Chardonnay2 : ChardonnayCard { }
    public class Chardonnay3 : ChardonnayCard { }
    public class Chardonnay4 : ChardonnayCard { }
}