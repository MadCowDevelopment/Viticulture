
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;
using System.Windows;
using Caliburn.Micro;

namespace Viticulture
{
    public class MefBootstrapper : BootstrapperBase
    {
        private CompositionContainer _container;

        static MefBootstrapper()
        {
            LogManager.GetLog = type => new DebugLogger(type);
        }

        public MefBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            var catalog =
                new AggregateCatalog(
                    new AssemblyCatalog(Assembly.GetExecutingAssembly()),
                    new DirectoryCatalog("."));

            _container = new CompositionContainer(catalog);

            var batch = new CompositionBatch();

            batch.AddExportedValue<IWindowManager>(new WindowManager());
            batch.AddExportedValue<IEventAggregator>(new EventAggregator());
            batch.AddExportedValue(_container);

            _container.Compose(batch);
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            string contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(serviceType) : key;
            var exports = _container.GetExportedValues<object>(contract);

            if (exports.Any())
                return exports.First();

            throw new Exception($"Could not locate any instances of contract {contract}.");
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _container.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
        }

        protected override void BuildUp(object instance)
        {
            _container.SatisfyImportsOnce(instance);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<IAppViewModel>();
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            var assemblies = new DirectoryCatalog(".").LoadedFiles.Select(Assembly.LoadFrom).ToList();
            assemblies.Add(Assembly.GetExecutingAssembly());
            return assemblies.ToArray();
        }

    }
}