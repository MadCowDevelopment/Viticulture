using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Viticulture.Logic.Pieces;

namespace Viticulture.Logic.Cards.Orders
{
    [InheritedExport]
    public abstract class OrderCard : Card
    {
        public override string Name => string.Empty;

        public override string Text => string.Empty;

        public abstract int VictoryPoints { get; }

        public abstract int Residual { get; }

        public abstract IEnumerable<Tuple<WineType, int>> RequiredWines { get; }

        public bool WinesCanFillOrder(IEnumerable<Wine> wines)
        {
            var allWines = wines.ToList();
            foreach (var requiredWine in RequiredWines)
            {
                var wine =
                    allWines.OrderBy(p => p.Value)
                        .FirstOrDefault(p => p.Type == requiredWine.Item1 && p.Value >= requiredWine.Item2);
                if (wine == null) return false;
                allWines.Remove(wine);
            }

            return true;
        }
    }
}
