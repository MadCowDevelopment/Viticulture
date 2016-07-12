namespace Viticulture.Logic.Cards.Vines
{
    public abstract class TrebbianoCard : VineCard
    {
        public override string Name => "Trebbiano";
        public override bool RequiresIrigation => false;
        public override bool RequiresTrellis => true;
        public override int RedValue => 0;
        public override int WhiteValue => 2;
    }

    public class Trebbiano1 : TrebbianoCard { }
    public class Trebbiano2 : TrebbianoCard { }
    public class Trebbiano3 : TrebbianoCard { }
    public class Trebbiano4 : TrebbianoCard { }
    public class Trebbiano5 : TrebbianoCard { }
}