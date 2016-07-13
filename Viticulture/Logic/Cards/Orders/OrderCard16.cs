using System;
using System.Collections.Generic;
using Viticulture.Logic.Pieces;

namespace Viticulture.Logic.Cards.Orders
{
    public class OrderCard16 : OrderCard
    {
        public override int VictoryPoints => 5;
        public override int Residual => 2;

        public override IEnumerable<Tuple<WineType, int>> RequiredWines
            => new List<Tuple<WineType, int>> {new Tuple<WineType, int>(WineType.Sparkling, 9)};
    }
}