using System;
using System.CodeDom.Compiler;
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
			var segments = new Dictionary<string,string>()
			{
				{TEAM_NAME_SEGMENT, teamName}
			};;
			var request = new RestComplexRequest(Method.GET, segments, null);
			var task = MakeAsyncRequest<Team>(TEAM_NAME_RESOURCE, request);
			return task;	
		}
		
		public Task<PaginatedResponse<User>> GetMembersAsync(string teamName, PaginatedRequest request)
		{
			var segments = new Dictionary<string,string>()
			{
				{TEAM_NAME_SEGMENT, teamName}
			};
			var restRequest = new RestComplexRequest(Method.GET, segments, null);
			var task = MakeAsyncRequest<PaginatedResponse<User>>(TEAM_MEMBERS_RESOURCE, restRequest);
			return task;	
		}
		
		public Task<PaginatedResponse<User>> GetFollowersAsync(string teamName, PaginatedRequest request)
		{
			var segments = new Dictionary<string,string>()
			{
				{TEAM_NAME_SEGMENT, teamName}
			};
			var restRequest = new RestComplexRequest(Method.GET, segments, null);
			var task = MakeAsyncRequest<PaginatedResponse<User>>(TEAM_FOLLOWERS_RESOURCE, restRequest);
			return task;	
		}
		
		public Task<PaginatedResponse<User>> GetFollowingAsync(string teamName, PaginatedRequest request)
		{
			var segments = new Dictionary<string,string>()
			{
				{TEAM_NAME_SEGMENT, teamName}
			};
			var restRequest = new RestComplexRequest(Method.GET, segments, null);
			var task = MakeAsyncRequest<PaginatedResponse<User>>(TEAM_FOLLOWING_RESOURCE, restRequest);
			return task;	
		}
		
		public Task<PaginatedResponse<Repository>> GetRepositoriesAsync(string teamName, PaginatedRequest request)
		{
			var segments = new Dictionary<string,string>()
			{
				{TEAM_NAME_SEGMENT, teamName}
			};
			var restRequest = new RestComplexRequest(Method.GET, segments, null);
			var task = MakeAsyncRequest<PaginatedResponse<Repository>>(TEAM_REPOSITORIES_RESOURCE, restRequest);
			return task;
		}		
	}
}
