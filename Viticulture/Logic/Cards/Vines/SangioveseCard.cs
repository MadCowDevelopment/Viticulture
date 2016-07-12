namespace Viticulture.Logic.Cards.Vines
{
    public abstract class SangioveseCard : VineCard
    {
        public override string Name => "Sangiovese";
        public override bool RequiresIrigation => false;
        public override bool RequiresTrellis => false;
        public override int RedValue => 1;
        public override int WhiteValue => 0;
    }

    public class Sangiovese1Card : SangioveseCard { }
    public class Sangiovese2Card : SangioveseCard { }
    public class Sangiovese3Card : SangioveseCard { }
    public class Sangiovese4Card : SangioveseCard { }
}