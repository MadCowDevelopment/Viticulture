using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viticulture.Logic.Cards
{
    public abstract class Card
    {
        public abstract string Name { get; }

        public abstract string Text { get; }
    }
}
