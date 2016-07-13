using System;
using System.Collections.Generic;
using Viticulture.Logic.Pieces;

namespace Viticulture.Logic.Cards.Orders
{
    public class OrderCard25 : OrderCard
    {
        public override int VictoryPoints => 4;
        public override int Residual => 1;

        public override IEnumerable<Tuple<WineType, int>> RequiredWines
            => new List<Tuple<WineType, int>> {new Tuple<WineType, int>(WineType.Blush, 8)};
    }
}