namespace Viticulture.Logic.Cards.Vines
{
    public abstract class PinotCard : VineCard
    {
        public override string Name => "Pinot";
        public override bool RequiresIrigation => false;
        public override bool RequiresTrellis => true;
        public override int RedValue => 1;
        public override int WhiteValue => 1;
    }

    public class Pinot1 : PinotCard { }
    public class Pinot2 : PinotCard { }
    public class Pinot3 : PinotCard { }
    public class Pinot4 : PinotCard { }
    public class Pinot5 : PinotCard { }
    public class Pinot6 : PinotCard { }
}