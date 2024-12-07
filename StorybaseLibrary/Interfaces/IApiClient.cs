﻿using Storybase.Application.Models;
using System.Threading.Tasks;

namespace Storybase.Application.Interfaces
{
    public interface IApiClient
    {
        /// <summary>
        /// Sends a GET request to the specified URL and returns the response.
        /// </summary>
        /// <typeparam name="T">The type of the response data.</typeparam>
        /// <param name="url">The endpoint URL.</param>
        /// <returns>An ApiResponse containing the result.</returns>
        Task<ApiResponse<T>> GetAsync<T>(string url);

        /// <summary>
        /// Sends a POST request with data to the specified URL and returns the response.
        /// </summary>
        /// <typeparam name="T">The type of the response data.</typeparam>
        /// <param name="url">The endpoint URL.</param>
        /// <param name="data">The data to be sent in the request body.</param>
        /// <returns>An ApiResponse containing the result.</returns>
        Task<ApiResponse<T>> PostAsync<T>(string url, object data);

        /// <summary>
        /// Sends a PUT request with data to the specified URL and returns the response.
        /// </summary>
        /// <typeparam name="T">The type of the response data.</typeparam>
        /// <param name="url">The endpoint URL.</param>
        /// <param name="data">The data to be sent in the request body.</param>
        /// <returns>An ApiResponse containing the result.</returns>
        Task<ApiResponse<T>> PutAsync<T>(string url, object data);

        /// <summary>
        /// Sends a DELETE request to the specified URL and returns the response.
        /// </summary>
        /// <typeparam name="T">The type of the response data.</typeparam>
        /// <param name="url">The endpoint URL.</param>
        /// <returns>An ApiResponse containing the result.</returns>
        Task<ApiResponse<T>> DeleteAsync<T>(string url);
    }
}
