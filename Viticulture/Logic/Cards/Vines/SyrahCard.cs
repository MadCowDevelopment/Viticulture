namespace Viticulture.Logic.Cards.Vines
{
    public abstract class SyrahCard : VineCard
    {
        public override string Name => "Syrah";
        public override bool RequiresIrigation => false;
        public override bool RequiresTrellis => true;
        public override int RedValue => 2;
        public override int WhiteValue => 0;
    }

    public class Syrah1 : SyrahCard { }
    public class Syrah2 : SyrahCard { }
    public class Syrah3 : SyrahCard { }
    public class Syrah4 : SyrahCard { }
    public class Syrah5 : SyrahCard { }
}