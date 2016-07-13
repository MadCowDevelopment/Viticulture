using System;
using System.Collections.Generic;
using Viticulture.Logic.Pieces;

namespace Viticulture.Logic.Cards.Orders
{
    public class OrderCard34 : OrderCard
    {
        public override int VictoryPoints => 5;
        public override int Residual => 2;

        public override IEnumerable<Tuple<WineType, int>> RequiredWines
            =>
                new List<Tuple<WineType, int>>
                {
                    new Tuple<WineType, int>(WineType.Red, 2),
                    new Tuple<WineType, int>(WineType.White, 2),
                    new Tuple<WineType, int>(WineType.Blush, 5)
                };
    }
}