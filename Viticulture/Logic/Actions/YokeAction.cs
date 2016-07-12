using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Caliburn.Micro;
using Viticulture.Logic.Actions.Winter;
using Viticulture.Services;

namespace Viticulture.Logic.Actions
{
    [Export(typeof(YokeAction))]
    public class YokeAction : PlayerAction, IWinterAction, ISummerAction
    {
        [ImportingConstructor]
        public YokeAction(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public override string Text => "Yoke: Harvest 1 field or uproot 1 vine";

        public override bool CanExecuteSpecial
            => GameState.Yoke.IsBought && (HarvestField.CanExecuteSpecial || UprootVine.CanExecuteSpecial);

        [Import]
        public HarvestFieldAction HarvestField { get; set; }

        [Import]
        public UprootVineAction UprootVine { get; set; }

        public override async Task<bool> OnExecute()
        {
            if (!HarvestField.CanExecuteSpecial) return await UprootVine.OnExecute();
            if (!UprootVine.CanExecuteSpecial) return await HarvestField.OnExecute();

            var selectedOption =
                await
                    PlayerSelection.Select("Select action", "Choose to harvest 1 field or uproot 1 vine",
                        "harvest 1 field", "uproot 1 vine");
            if(selectedOption == Selection.None) return false;
            if (selectedOption == Selection.Option1) return await HarvestField.OnExecute();
            return await UprootVine.OnExecute();
        }
    }
}