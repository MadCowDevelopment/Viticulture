using System;
using System.Collections.Generic;
using Viticulture.Logic.Pieces;

namespace Viticulture.Logic.Cards.Orders
{
    public class OrderCard07 : OrderCard
    {
        public override int VictoryPoints => 4;
        public override int Residual => 1;

        public override IEnumerable<Tuple<WineType, int>> RequiredWines
            =>
                new List<Tuple<WineType, int>>
                {
                    new Tuple<WineType, int>(WineType.White, 4),
                    new Tuple<WineType, int>(WineType.White, 3),
                    new Tuple<WineType, int>(WineType.White, 2)
                };
    }
}