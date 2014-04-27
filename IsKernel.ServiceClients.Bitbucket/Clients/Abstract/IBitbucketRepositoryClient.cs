using System;
using System.Threading.Tasks;
using IsKernel.ServiceClients.Bitbucket.Contracts.Repositories;
using IsKernel.ServiceClients.Bitbucket.Contracts.Repositories.Parameters;
using IsKernel.ServiceClients.Bitbucket.Contracts.Requests;
using IsKernel.ServiceClients.Bitbucket.Contracts.Responses;
using IsKernel.ServiceClients.Bitbucket.Contracts.Users;

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
		Task<Repository> GetAsync(string owner, string reposlug);
		/// <summary>
		/// Creates a new repository
		/// </summary>
		/// <param name="owner">The owner of the repository (must be authentificated)</param>
		/// <param name="reposlug">The reposlug (name) associated with the repository</param>
		/// <param name="optional">Optional parameters for the creation of the repository</param>
		/// <returns>True if the repository was created</returns>
		Task<bool> CreateAsync(string owner, string reposlug, RepositoryCreateOptionalParameters optional);
		/// <summary>
		/// Deletes an existing repository
		/// </summary>
		/// <param name="owner">The owner of the repository (must be authentificated)</param>
		/// <param name="reposlug">The reposlug (name) associated with the repository</param>
		/// <returns>True if the repository was deleted</returns>
		Task<bool> DeleteAsync(string owner, string reposlug);
		/// <summary>
		/// Returns all users who watch a repository
		/// </summary>
		/// <param name="owner">The owner of the repository</param>
		/// <param name="reposlug">The reposlug (name) associated with the repository</param>
		/// <param name="request">Pagination settings for the list</param>
		/// <returns>A paginated list of the users watching the repository</returns>
		Task<PaginatedResponse<User>> GetWatchersAsync(string owner, string reposlug, PaginatedRequest request);
		/// <summary>
		/// Returns all repositories forked from the specified repository.
		/// </summary>
		/// <param name="owner">The owner of the repository</param>
		/// <param name="reposlug">The reposlug (name) associated with the repository</param>
		/// <param name="request">Pagination settings for the list</param>
		/// <returns>A paginated list of the repositories forked from this repository</returns>
		Task<PaginatedResponse<Repository>> GetForksAsync(string owner, string reposlug, PaginatedRequest request);
		/// <summary>
		/// Returns all public repositories created by a user.
		/// </summary>
		/// <param name="owner">The searched user</param>
		/// <param name="request">Pagination settings for the list</param>
		/// <returns>A paginated list of all the owner's repositories</returns>
		Task<PaginatedResponse<Repository>> GetAllAsync(string owner, PaginatedRequest request);
		/// <summary>
		/// Returns all public repositories on Bitbucket.
		/// </summary>
		/// <param name="request">Pagination settings for the list</param>
		/// <returns>A paginated list of the public repositories on Bitbucket</returns>
		Task<PaginatedResponse<Repository>> GetAllPublicAsync(PaginatedRequest request);
	}
}
