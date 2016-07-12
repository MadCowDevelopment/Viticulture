namespace Viticulture.Logic.Cards.Vines
{
    public abstract class CabernetSauvignonCard : VineCard
    {
        public override string Name => "Cabernet Sauvignon";
        public override bool RequiresIrigation => true;
        public override bool RequiresTrellis => true;
        public override int RedValue => 4;
        public override int WhiteValue => 0;
    }

    public class CabernetSauvignon1 : CabernetSauvignonCard { }
    public class CabernetSauvignon2 : CabernetSauvignonCard { }
    public class CabernetSauvignon3 : CabernetSauvignonCard { }
    public class CabernetSauvignon4 : CabernetSauvignonCard { }
}