using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Viticulture.Logic.Actions.Summer;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class ContractorCard : SelectManyVisitorCard
    {
        private readonly BuildStructureAction _buildStructureAction;
        private readonly PlantVineAction _plantVineAction;
        private List<Option> _options;

        [ImportingConstructor]
        public ContractorCard(BuildStructureAction buildStructureAction, PlantVineAction plantVineAction)
        {
            _buildStructureAction = buildStructureAction;
            _plantVineAction = plantVineAction;
        }

        public ContractorCard()
        {
        }

        protected override IEnumerable<Option> Options
        {
            get
            {
                return _options ??
                       (_options =
                           new List<Option>
                           {
                               new Option("gain 1 VP", GainVictoryPoint, state => true),
                               new Option("build 1 structure", BuildStructure,
                                   state => _buildStructureAction.CanExecuteSpecial),
                               new Option("plant 1 vine", PlantVine, state => _plantVineAction.CanExecuteSpecial)
                           });
            }
        }

        protected override int RequiredSelections => 2;

        private async Task<bool> PlantVine(IGameState gameState)
        {
            return await _plantVineAction.OnExecute();
        }

        private async Task<bool> BuildStructure(IGameState gameState)
        {
            return await _buildStructureAction.OnExecute();
        }

        private Task<bool> GainVictoryPoint(IGameState gameState)
        {
            gameState.VictoryPoints++;
            return Task.FromResult(true);
        }

        public override string Name => "Contractor";
        public override Season Season => Season.Summer;
    }
}