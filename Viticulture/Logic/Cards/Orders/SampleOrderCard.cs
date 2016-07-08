using System;
using System.Collections.Generic;
using Viticulture.Logic.Pieces;

namespace Viticulture.Logic.Cards.Orders
{
    public class SampleOrderCard : OrderCard
    {
        public override int VictoryPoints => 1;
        public override int Residual => 1;
        public override IEnumerable<Tuple<WineType, int>> RequiredWines => new List<Tuple<WineType, int>> {new Tuple<WineType, int>(WineType.Red, 5)};
    }
}