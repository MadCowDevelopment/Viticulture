using System;
using System.Collections.Generic;
using Viticulture.Logic.Pieces;

namespace Viticulture.Logic.Cards.Orders
{
    public class OrderCard04 : OrderCard
    {
        public override int VictoryPoints => 5;
        public override int Residual => 2;

        public override IEnumerable<Tuple<WineType, int>> RequiredWines
            =>
                new List<Tuple<WineType, int>>
                {
                    new Tuple<WineType, int>(WineType.White, 7),
                    new Tuple<WineType, int>(WineType.White, 6)
                };
    }
}