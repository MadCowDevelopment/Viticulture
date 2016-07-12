namespace Viticulture.Logic.Cards.Vines
{
    public abstract class SauvignonBlancCard : VineCard
    {
        public override string Name => "Sauvignon Blanc";
        public override bool RequiresIrigation => true;
        public override bool RequiresTrellis => false;
        public override int RedValue => 0;
        public override int WhiteValue => 3;
    }

    public class SauvignonBlanc1 : SauvignonBlancCard { }
    public class SauvignonBlanc2 : SauvignonBlancCard { }
    public class SauvignonBlanc3 : SauvignonBlancCard { }
    public class SauvignonBlanc4 : SauvignonBlancCard { }
    public class SauvignonBlanc5 : SauvignonBlancCard { }
}