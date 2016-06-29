using System.ComponentModel.Composition;

namespace Viticulture.Logic.Cards.Parents
{
    [InheritedExport(typeof(IMamaCard))]
    public abstract class MamaCard : ParentCard, IMamaCard
    {
    }
}