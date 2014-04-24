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
	public class BitbucketTeamClient : BitbucketClientBase, IBitbucketTeamClient
	{
		private const string TEAM_NAME_SEGMENT = "teamname";
		
		private const string BASE_URL = "https://bitbucket.org/api/2.0";
		
		private const string TEAM_NAME_RESOURCE = "/teams/{teamname}";
		private const string TEAM_MEMBERS_RESOURCE = "/teams/{teamname}/members";
		private const string TEAM_FOLLOWERS_RESOURCE = "/teams/{teamname}/followers";
		private const string TEAM_FOLLOWING_RESOURCE = "/teams/{teamname}/following";
		private const string TEAM_REPOSITORIES_RESOURCE = "/teams/{teamname}/repositories";
		
		public BitbucketTeamClient(IAuthenticator authenticator) : base(authenticator, BASE_URL)
		{
			
		}
		
		public Task<Team> GetProfileAsync(string teamName)
		{
			var urlSegments = new List<Tuple<string,string>>()
			{
				new Tuple<string, string>(TEAM_NAME_SEGMENT, teamName)
			};
			var task = MakeAsyncRequest<Team>(TEAM_NAME_RESOURCE, Method.GET, 
											  urlSegments, null, 
											  "Could not retrieve team.");
			return task;
		}
		
		public Task<PaginatedResponse<User>> GetMembersAsync(string teamName, PaginatedRequest request)
		{
			var urlSegments = new List<Tuple<string,string>>()
			{
				new Tuple<string, string>(TEAM_MEMBERS_RESOURCE, teamName)
			};
			var parameters = request.ToTuples();
			var task = MakeAsyncRequest<PaginatedResponse<User>>(TEAM_NAME_RESOURCE, Method.GET,
																 urlSegments, parameters, 
																 "Could not retrieve team members.");
			return task;
		}
		
		public Task<PaginatedResponse<User>> GetFollowersAsync(string teamName, PaginatedRequest request)
		{
			var urlSegments = new List<Tuple<string,string>>()
			{
				new Tuple<string, string>(TEAM_FOLLOWERS_RESOURCE, teamName)
			};
			var parameters = request.ToTuples();
			var task = MakeAsyncRequest<PaginatedResponse<User>>(TEAM_NAME_RESOURCE, Method.GET,
																 urlSegments, parameters, 
																 "Could not retrieve team followers.");
			return task;
		}
		
		public Task<PaginatedResponse<User>> GetFollowingAsync(string teamName, PaginatedRequest request)
		{
			var urlSegments = new List<Tuple<string,string>>()
			{
				new Tuple<string, string>(TEAM_FOLLOWERS_RESOURCE, teamName)
			};
			var parameters = request.ToTuples();
			var task = MakeAsyncRequest<PaginatedResponse<User>>(TEAM_FOLLOWING_RESOURCE, Method.GET,
																 urlSegments, parameters, 
																 "Could not retrieve team followers.");
			return task;
		}
		
		public Task<PaginatedResponse<Repository>> GetRepositoriesAsync(string teamName, PaginatedRequest request)
		{
			var urlSegments = new List<Tuple<string,string>>()
			{
				new Tuple<string, string>(TEAM_REPOSITORIES_RESOURCE, teamName)
			};
			var parameters = request.ToTuples();
			var task = MakeAsyncRequest<PaginatedResponse<Repository>>(TEAM_FOLLOWING_RESOURCE, Method.GET,
																	   urlSegments, parameters, 
																 	   "Could not retrieve team repositories.");
			return task;
		}
		

		
	}
}
