using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;
using IsKernel.ServiceClients.Bitbucket.Contracts.Repositories;
using IsKernel.ServiceClients.Bitbucket.Contracts.Requests;
using IsKernel.ServiceClients.Bitbucket.Contracts.Responses;
using IsKernel.ServiceClients.Bitbucket.Contracts.Teams;
using IsKernel.ServiceClients.Bitbucket.Contracts.Users;
using IsKernel.ServiceClients.Bitbucket.Infrastructure.Rest;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Concrete
{
	public class BitbucketUserClient : BitbucketClientBase , IBitbucketUserClient
	{
		private const string BASE_URL = "https://bitbucket.org/api/2.0/users";
		
		private const string USERNAME_SEGMENT = "{username}";
		
		private const string USER_RESOURCE = "/{username}";
		private const string FOLLOWERS_RESOURCE = "/{username}/followers";
		private const string FOLLOWING_RESOURCE = "/{username}/following";
		private const string REPOSITORIES_RESOURCE = "/repositories/{username}";
		
		public BitbucketUserClient(IAuthenticator authenticator) : base(authenticator, BASE_URL)
		{
			
		}
		
		public Task<Team> GetProfileAsync(string user)
		{
			var segments = new Dictionary<string,string>()
			{
				{USERNAME_SEGMENT, user}
			};
			var restRequest = new RestComplexRequest(Method.GET, segments, null);
			var task = MakeAsyncRequest<Team>(USER_RESOURCE, restRequest);
			return task;
		}
		
		public Task<PaginatedResponse<User>> GetFollowersAsync(string user, PaginatedRequest request)
		{
			var segments = new Dictionary<string,string>()
			{
				{USERNAME_SEGMENT, user}
			};
			var parameters = CreateDefaultPaginationParameters(request);
			var restRequest = new RestComplexRequest(Method.GET, segments, parameters);
			var task = MakeAsyncRequest<PaginatedResponse<User>>(FOLLOWERS_RESOURCE, restRequest);
			return task;
		}
		
		public Task<PaginatedResponse<User>> GetFollowedAsync(string user, PaginatedRequest request)
		{
			var segments = new Dictionary<string,string>()
			{
				{USERNAME_SEGMENT, user}
			};
			var parameters = CreateDefaultPaginationParameters(request);
			var restRequest = new RestComplexRequest(Method.GET, segments, parameters);
			var task = MakeAsyncRequest<PaginatedResponse<User>>(FOLLOWING_RESOURCE, restRequest);
			return task;
		}
		
		public Task<PaginatedResponse<Repository>> GetRepositoriesAsync(string user, PaginatedRequest request)
		{
			var segments = new Dictionary<string,string>()
			{
				{USERNAME_SEGMENT, user}
			};
			var parameters = CreateDefaultPaginationParameters(request);
			var restRequest = new RestComplexRequest(Method.GET, segments, parameters);
			var task = MakeAsyncRequest<PaginatedResponse<Repository>>(REPOSITORIES_RESOURCE, restRequest);
			return task;
		}
	}
}
