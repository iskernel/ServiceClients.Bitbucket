using System;
using System.Threading.Tasks;
using IsKernel.ServiceClients.Bitbucket.Contracts.Repositories;
using IsKernel.ServiceClients.Bitbucket.Contracts.Requests;
using IsKernel.ServiceClients.Bitbucket.Contracts.Responses;
using IsKernel.ServiceClients.Bitbucket.Contracts.Teams;
using IsKernel.ServiceClients.Bitbucket.Contracts.Users;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Abstract
{
	public interface IBitbucketUserClient
	{
		Task<Team> GetProfileAsync(string user);
		Task<PaginatedResponse<User>> GetFollowersAsync(string user, PaginatedRequest request);
		Task<PaginatedResponse<User>> GetFollowedAsync(string user, PaginatedRequest request);
		Task<PaginatedResponse<Repository>> GetRepositoriesAsync(string teamName, PaginatedRequest request);
	}
}
