using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;

namespace Viticulture.Services
{
    /// <summary>
    /// Defines the IOC container.
    /// </summary>
    public class MefContainer : IMefContainer
    {
        private readonly string _baseUrl;

        /// <summary>
        /// Initializes a new instance of the <see cref="MefContainer"/> class.
        /// </summary>
        public MefContainer()
        {
            var catalog = new AggregateCatalog();
            var directoryCatalog = new DirectoryCatalog(".");
            catalog.Catalogs.Add(directoryCatalog);
            var entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly != null)
            {
                catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetEntryAssembly()));
            }

            _baseUrl = AppDomain.CurrentDomain.BaseDirectory;
            AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolveHandler;
            Container = new CompositionContainer(catalog);
        }

        private Assembly AssemblyResolveHandler(object sender, ResolveEventArgs args)
        {
            var assemblyName = new AssemblyName(args.Name).Name;
            if (assemblyName.EndsWith(".resources"))
            {
                return null;
            }

            var path = Path.Combine(_baseUrl, assemblyName + ".dll");
            if (File.Exists(path))
            {
                return Assembly.LoadFrom(path);
            }

            return null;
        }
        #region Properties

        /// <summary>
        /// Gets or sets the composition container.
        /// </summary>
        private CompositionContainer Container { get; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a part from the specified value and composes it in the specified composition container.
        /// </summary>
        /// <typeparam name="T">Type of the exported value.</typeparam>
        /// <param name="exportedValue">The value to export.</param>
        public void ComposeExportedValue<T>(T exportedValue)
        {
            Container.ComposeExportedValue(exportedValue);
        }

        /// <summary>
        /// Creates a part from the specified object under the specified contract name and composes it in the
        /// specified composition container.
        /// </summary>
        /// <typeparam name="T">Type of the exported value.</typeparam>
        /// <param name="contractName">The contract name to export the part under.</param>
        /// <param name="exportedValue">The value to export.</param>
        public void ComposeExportedValue<T>(string contractName, T exportedValue)
        {
            Container.ComposeExportedValue(contractName, exportedValue);
        }

        /// <summary>
        /// Returns the exported objects derived from the specified type parameter.
        /// If there is not exactly one matching exported object, an exception is thrown.
        /// </summary>
        /// <typeparam name="T">Type of the exported object.</typeparam>
        /// <returns>Returns the exported object.</returns>
        public IEnumerable<T> GetExportedValues<T>()
        {
            return Container.GetExportedValues<T>();
        }

        /// <summary>
        /// Returns the exported objects with the contract name derived from the specified type parameter.
        /// If there is not exactly one matching exported object, an exception is thrown.
        /// </summary>
        /// <typeparam name="T">Type of the exported object.</typeparam>
        /// <param name="contractName">The contract name to export the part under.</param>
        /// <returns>Returns the exported object.</returns>
        public IEnumerable<T> GetExportedValues<T>(string contractName)
        {
            return Container.GetExportedValues<T>(contractName);
        }

        /// <summary>
        /// Creates composable parts from an array of attributed objects and composes them
        /// in the specified composition container.
        /// </summary>
        /// <param name="attributedParts">An array of attributed objects to compose.</param>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly",
                         Justification = "Reviewed. Suppression is OK here.")]
        public void ComposeParts(params object[] attributedParts)
        {
            Container.ComposeParts(attributedParts);
        }

        /// <summary>
        /// Returns the exported object with the contract name derived from the specified type parameter.
        /// If there is not exactly one matching exported object, an exception is thrown.
        /// </summary>
        /// <typeparam name="T">Type of the exported object.</typeparam>
        /// <returns>Returns the exported object</returns>
        public T GetExportedValue<T>()
        {
            return Container.GetExportedValue<T>();
        }

        /// <summary>
        /// Returns the exported object with the specified contract name. If there is not exactly one
        /// matching exported object, an exception is thrown.
        /// </summary>
        /// <typeparam name="T">Type of the exported object.</typeparam>
        /// <param name="contractName">The contract name when exporting.</param>
        /// <returns>Returns the exported object.</returns>
        public T GetExportedValue<T>(string contractName)
        {
            return Container.GetExportedValue<T>(contractName);
        }

        /// <summary>
        /// Returns the export with the contract name derived from the specified type parameter. If there is not
        /// exactly one matching export, an exception is thrown.
        /// </summary>
        /// <typeparam name="T">Type of the exported object.</typeparam>
        /// <typeparam name="TMetadataView">The type of the metadata view.</typeparam>
        /// <returns>Returns the export with special type parameter.</returns>
        public System.Lazy<T, TMetadataView> GetExport<T, TMetadataView>()
        {
            return Container.GetExport<T, TMetadataView>();
        }

        /// <summary>
        /// Returns the exports with the contract name derived from the specified type parameter. If there is not
        /// exactly one matching export, an exception is thrown.
        /// </summary>
        /// <typeparam name="T">Type of the exported object.</typeparam>
        /// <typeparam name="TMetadataView">The type of the metadata view.</typeparam>
        /// <returns>Returns a list of the exports with special type parameter.</returns>
        public IEnumerable<System.Lazy<T, TMetadataView>> GetExports<T, TMetadataView>()
        {
            return Container.GetExports<T, TMetadataView>();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Container.Dispose();
        }

        #endregion Public Methods

        public void Compose(CompositionBatch batch)
        {
            Container.Compose(batch);
        }

        public void SatisfyImportsOnce(object instance)
        {
            Container.SatisfyImportsOnce(instance);
        }
    }
}
