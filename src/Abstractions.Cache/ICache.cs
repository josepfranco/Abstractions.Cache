using System;
using System.Threading;
using System.Threading.Tasks;

namespace Abstractions.Cache
{
    /// <summary>
    /// Contract for a caching service.
    /// Agnostic whether it's used for an in-Memory cache or a distributed cache.
    /// </summary>
    public interface ICache
    {
        /// <summary>
        /// Gets an object saved in a cache with a certain key asynchronously
        /// </summary>
        /// <param name="key">the key</param>
        /// <typeparam name="TObject">the object type it's expecting to get</typeparam>
        /// <param name="token">the cancellation token</param>
        /// <returns>a task with the object deserialized, or null if none was found</returns>
        Task<TObject> GetAsync<TObject>(string key, CancellationToken token = default)
            where TObject : class;
        
        /// <summary>
        /// Saves an object in a cache with a certain key and expiry duration asynchronously
        /// </summary>
        /// <param name="key">the key</param>
        /// <param name="value">the object to save</param>
        /// <param name="expiry">when this cache is supposed to expire</param>
        /// <param name="token">the cancellation token</param>
        /// <returns>a task with whether the value was successfully inserted or not</returns>
        Task<bool> SetAsync(string key, object value, TimeSpan? expiry = null, CancellationToken token = default);
    }
}