namespace Viticulture.Logic.Cards.Vines
{
    public abstract class MerlotCard : VineCard
    {
        public override string Name => "Merlot";
        public override bool RequiresIrigation => true;
        public override bool RequiresTrellis => false;
        public override int RedValue => 3;
        public override int WhiteValue => 0;
    }

    public class Merlot1 : MerlotCard { }
    public class Merlot2 : MerlotCard { }
    public class Merlot3 : MerlotCard { }
    public class Merlot4 : MerlotCard { }
    public class Merlot5 : MerlotCard { }
}