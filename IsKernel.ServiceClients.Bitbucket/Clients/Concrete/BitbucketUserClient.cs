using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;
using IsKernel.ServiceClients.Bitbucket.Contracts.Models.Repositories;
using IsKernel.ServiceClients.Bitbucket.Contracts.Requests;
using IsKernel.ServiceClients.Bitbucket.Contracts.Responses;
using IsKernel.ServiceClients.Bitbucket.Contracts.Teams;
using IsKernel.ServiceClients.Bitbucket.Contracts.Users;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Concrete
{
	public class BitbucketUserClient : BitbucketClientBase ,IBitbucketUserClient
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
		
		public Task<Team> GetUserProfileAsync(string user)
		{
			var urlSegments = new List<Tuple<string,string>>()
			{
				new Tuple<string, string>(USERNAME_SEGMENT, user)
			};
			var task = MakeAsyncRequest<Team>(USER_RESOURCE, Method.GET, 
											  urlSegments, null, 
											  "Could not retrieve user.");
			return task;
		}
		
		public Task<PaginatedResponse<User>> GetFollowersAsync(string user, PaginatedRequest request)
		{
			var urlSegments = new List<Tuple<string,string>>()
			{
				new Tuple<string, string>(USERNAME_SEGMENT, user)
			};
			var parameters = request.ToTuples();
			var task = MakeAsyncRequest<PaginatedResponse<User>>(FOLLOWERS_RESOURCE, Method.GET,
																 urlSegments, parameters, 
																 "Could not retrieve user followers.");
			return task;
		}
		
		public Task<PaginatedResponse<User>> GetFollowedAsync(string user, PaginatedRequest request)
		{
			var urlSegments = new List<Tuple<string,string>>()
			{
				new Tuple<string, string>(USERNAME_SEGMENT, user)
			};
			var parameters = request.ToTuples();
			var task = MakeAsyncRequest<PaginatedResponse<User>>(FOLLOWERS_RESOURCE, Method.GET,
																 urlSegments, parameters, 
																 "Could not retrieve the followed users.");
			return task;
		}
		
		public Task<PaginatedResponse<Repository>> GetRepositoriesAsync(string teamName, PaginatedRequest request)
		{
			var urlSegments = new List<Tuple<string,string>>()
			{
				new Tuple<string, string>(USERNAME_SEGMENT, teamName)
			};
			var parameters = request.ToTuples();
			var task = MakeAsyncRequest<PaginatedResponse<Repository>>(REPOSITORIES_RESOURCE, Method.GET,
																	   urlSegments, parameters, 
																 	   "Could not retrieve user repositories.");
			return task;
		}
	}
}
