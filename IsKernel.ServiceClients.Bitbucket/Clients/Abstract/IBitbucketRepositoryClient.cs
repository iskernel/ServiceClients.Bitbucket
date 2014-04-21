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
		Task<Repository> GetRepositoryAsync(string owner, string reposlug);
		Task<bool> CreateRepositoryAsync(string owner, string reposlug, RepositoryAddOptionalParametersModel optional);
		Task<bool> DeleteRepositoryAsync(string owner, string reposlug);
		Task<PaginatedResponse<User>> GetRepositoryWatchersAsync(string owner, string reposlug, PaginatedRequest request);
		Task<PaginatedResponse<Repository>> GetAllRepositoryForksAsync(string owner, string reposlug, PaginatedRequest request);
		Task<PaginatedResponse<Repository>> GetAllRepositoriesForUserAsync(string owner, PaginatedRequest request);
		Task<PaginatedResponse<Repository>> GetAllPublicRepositoriesAsync(PaginatedRequest request);
	}
}
