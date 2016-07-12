namespace Viticulture.Logic.Cards.Vines
{
    public abstract class MalvasiaCard : VineCard
    {
        public override string Name => "Malvasia";
        public override bool RequiresIrigation => false;
        public override bool RequiresTrellis => false;
        public override int RedValue => 0;
        public override int WhiteValue => 1;
    }

    public class Malvasia1 : MalvasiaCard { }
    public class Malvasia2 : MalvasiaCard { }
    public class Malvasia3 : MalvasiaCard { }
    public class Malvasia4 : MalvasiaCard { }
}