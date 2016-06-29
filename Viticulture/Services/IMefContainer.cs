using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;

namespace Viticulture.Services
{
    public interface IMefContainer
    {
        /// <summary>
        /// Creates a part from the specified value and composes it in the specified composition container.
        /// </summary>
        /// <typeparam name="T">Type of the exported value.</typeparam>
        /// <param name="exportedValue">The value to export.</param>
        void ComposeExportedValue<T>(T exportedValue);

        /// <summary>
        /// Creates a part from the specified object under the specified contract name and composes it in the
        /// specified composition container.
        /// </summary>
        /// <typeparam name="T">Type of the exported value.</typeparam>
        /// <param name="contractName">The contract name to export the part under.</param>
        /// <param name="exportedValue">The value to export.</param>
        void ComposeExportedValue<T>(string contractName, T exportedValue);

        /// <summary>
        /// Returns the exported objects derived from the specified type parameter.
        /// If there is not exactly one matching exported object, an exception is thrown.
        /// </summary>
        /// <typeparam name="T">Type of the exported object.</typeparam>
        /// <returns>Returns the exported object.</returns>
        IEnumerable<T> GetExportedValues<T>();

        /// <summary>
        /// Returns the exported objects with the contract name derived from the specified type parameter.
        /// If there is not exactly one matching exported object, an exception is thrown.
        /// </summary>
        /// <typeparam name="T">Type of the exported object.</typeparam>
        /// <param name="contractName">The contract name to export the part under.</param>
        /// <returns>Returns the exported object.</returns>
        IEnumerable<T> GetExportedValues<T>(string contractName);

        /// <summary>
        /// Creates composable parts from an array of attributed objects and composes them
        /// in the specified composition container.
        /// </summary>
        /// <param name="attributedParts">An array of attributed objects to compose.</param>
        void ComposeParts(params object[] attributedParts);

        /// <summary>
        /// Returns the exported object with the contract name derived from the specified type parameter.
        /// If there is not exactly one matching exported object, an exception is thrown.
        /// </summary>
        /// <typeparam name="T">Type of the exported object.</typeparam>
        /// <returns>Returns the exported object</returns>
        T GetExportedValue<T>();

        /// <summary>
        /// Returns the exported object with the specified contract name. If there is not exactly one
        /// matching exported object, an exception is thrown.
        /// </summary>
        /// <typeparam name="T">Type of the exported object.</typeparam>
        /// <param name="contractName">The contract name when exporting.</param>
        /// <returns>Returns the exported object.</returns>
        T GetExportedValue<T>(string contractName);

        /// <summary>
        /// Returns the export with the contract name derived from the specified type parameter. If there is not
        /// exactly one matching export, an exception is thrown.
        /// </summary>
        /// <typeparam name="T">Type of the exported object.</typeparam>
        /// <typeparam name="TMetadataView">The type of the metadata view.</typeparam>
        /// <returns>Returns the export with special type parameter.</returns>
        System.Lazy<T, TMetadataView> GetExport<T, TMetadataView>();

        /// <summary>
        /// Returns the exports with the contract name derived from the specified type parameter. If there is not
        /// exactly one matching export, an exception is thrown.
        /// </summary>
        /// <typeparam name="T">Type of the exported object.</typeparam>
        /// <typeparam name="TMetadataView">The type of the metadata view.</typeparam>
        /// <returns>Returns a list of the exports with special type parameter.</returns>
        IEnumerable<System.Lazy<T, TMetadataView>> GetExports<T, TMetadataView>();

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        void Dispose();

        void Compose(CompositionBatch batch);
        void SatisfyImportsOnce(object instance);
    }
}