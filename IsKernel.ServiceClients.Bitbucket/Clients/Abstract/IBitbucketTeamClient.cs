using System;
using System.Threading.Tasks;
using IsKernel.ServiceClients.Bitbucket.Contracts.Models.Repositories;
using IsKernel.ServiceClients.Bitbucket.Contracts.Requests;
using IsKernel.ServiceClients.Bitbucket.Contracts.Responses;
using IsKernel.ServiceClients.Bitbucket.Contracts.Teams;
using IsKernel.ServiceClients.Bitbucket.Contracts.Users;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Abstract
{
	public interface IBitbucketTeamClient
	{
		Task<Team> GetProfileAsync(string teamName);
		Task<PaginatedResponse<User>> GetMembersAsync(string teamName, PaginatedRequest request);
		Task<PaginatedResponse<User>> GetFollowersAsync(string teamName, PaginatedRequest request);
		Task<PaginatedResponse<User>> GetFollowingAsync(string teamName, PaginatedRequest request);
		Task<PaginatedResponse<Repository>> GetRepositoriesAsync(string teamName, PaginatedRequest request);
	}
}
