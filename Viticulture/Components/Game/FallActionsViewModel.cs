using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Cards.Parents.Papas;
using Viticulture.Logic.State;

namespace Viticulture.Components.Game
{
    [Export(typeof(IFallActionsViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class FallActionsViewModel : ViewModel, IFallActionsViewModel
    {
    }
}