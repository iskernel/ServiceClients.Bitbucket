using System;
using System.Threading.Tasks;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Repositories;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Users;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Requests;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses;
using IsKernel.ServiceClients.Bitbucket.Contracts.Repositories.Requests;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Abstract
{
	public interface IBitbucketRepositoryClient
	{
		/// <summary>
		/// Returns a repository.
		/// </summary>
		/// <param name="owner">The owner of the repository</param>
		/// <param name="reposlug">The reposlug (name) associated with the repository</param>
		/// <returns>The repository information.</returns>
		Task<Repository> GetRepositoryAsync(string owner, string reposlug);
		/// <summary>
		/// Creates a new repository
		/// </summary>
		/// <param name="owner">The owner of the repository (must be authentificated)</param>
		/// <param name="reposlug">The reposlug (name) associated with the repository</param>
		/// <param name="optional">Optional parameters for the creation of the repository</param>
		/// <returns>True if the repository was created</returns>
		Task<bool> CreateRepositoryAsync(string owner, string reposlug, RepositoryAddOptionalParametersModel optional);
		/// <summary>
		/// Deletes an existing repository
		/// </summary>
		/// <param name="owner">The owner of the repository (must be authentificated)</param>
		/// <param name="reposlug">The reposlug (name) associated with the repository</param>
		/// <returns>True if the repository was deleted</returns>
		Task<bool> DeleteRepositoryAsync(string owner, string reposlug);
		/// <summary>
		/// Returns all users who watch a repository
		/// </summary>
		/// <param name="owner">The owner of the repository</param>
		/// <param name="reposlug">The reposlug (name) associated with the repository</param>
		/// <param name="request">Pagination settings for the list</param>
		/// <returns>A paginated list of the users watching the repository</returns>
		Task<PaginatedResponse<User>> GetRepositoryWatchersAsync(string owner, string reposlug, PaginatedRequest request);
		/// <summary>
		/// Returns all repositories forked from the specified repository.
		/// </summary>
		/// <param name="owner">The owner of the repository</param>
		/// <param name="reposlug">The reposlug (name) associated with the repository</param>
		/// <param name="request">Pagination settings for the list</param>
		/// <returns>A paginated list of the repositories forked from this repository</returns>
		Task<PaginatedResponse<Repository>> GetAllRepositoryForksAsync(string owner, string reposlug, PaginatedRequest request);
		/// <summary>
		/// Returns all public repositories created by a user.
		/// </summary>
		/// <param name="owner">The searched user</param>
		/// <param name="request">Pagination settings for the list</param>
		/// <returns>A paginated list of all the owner's repositories</returns>
		Task<PaginatedResponse<Repository>> GetAllRepositoriesForUserAsync(string owner, PaginatedRequest request);
		/// <summary>
		/// Returns all public repositories on Bitbucket.
		/// </summary>
		/// <param name="request">Pagination settings for the list</param>
		/// <returns>A paginated list of the public repositories on Bitbucket</returns>
		Task<PaginatedResponse<Repository>> GetAllPublicRepositoriesAsync(PaginatedRequest request);
	}
}
