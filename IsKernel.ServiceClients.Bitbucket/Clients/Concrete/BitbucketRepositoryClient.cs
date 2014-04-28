using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;
using IsKernel.ServiceClients.Bitbucket.Contracts.Repositories;
using IsKernel.ServiceClients.Bitbucket.Contracts.Repositories.Parameters;
using IsKernel.ServiceClients.Bitbucket.Contracts.Requests;
using IsKernel.ServiceClients.Bitbucket.Contracts.Responses;
using IsKernel.ServiceClients.Bitbucket.Contracts.Users;
using IsKernel.ServiceClients.Bitbucket.Exceptions;
using IsKernel.ServiceClients.Bitbucket.Infrastructure.Rest;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Concrete
{
	public class BitbucketRepositoryClient : BitbucketRepositoryClientBase, IBitbucketRepositoryClient
	{		
		private const string REPOSITORY_BASE_URL = "https://api.bitbucket.org/2.0/repositories";
		private const string DEFAULT_SPECIFIC_REPOSITORY_RESOURCE = @"/{owner}/{repo_slug}";
		private const string DEFAULT_OWNER_RESOURCE = @"/{owner}";
		private const string WATCHERS_REPOSITORY_RESOURCE = @"/{owner}/{repo_slug}/watchers";
		private const string FORKS_REPOSITORY_RESOURCE = @"/{owner}/{repo_slug}/forks";
		
				
		public BitbucketRepositoryClient(IAuthenticator authentificator)
			: base(authentificator, REPOSITORY_BASE_URL)
		{
			
		}
		
		public Task<Repository> GetAsync(string owner, string reposlug)
		{					
			var segments = CreateDefaultSegmentsDictionary(owner, reposlug);
			var request = new RestComplexRequest(Method.GET, segments, null);
			var task = MakeAsyncRequest<Repository>(DEFAULT_SPECIFIC_REPOSITORY_RESOURCE, request);
			return task;			
		}
		
		public Task<RepositoryCreated> CreateAsync(string owner, string reposlug, RepositoryCreateOptionalParameters optional)
		{
			var segments = CreateDefaultSegmentsDictionary(owner, reposlug);
			var request = new RestComplexDataRequest(Method.POST, segments, null, null, optional, 
													 RestDataContentType.Json);
			var task = MakeAsyncRequest<RepositoryCreated>(DEFAULT_SPECIFIC_REPOSITORY_RESOURCE, request);
			return task;		
		}
		
		public Task<string> DeleteAsync(string owner, string reposlug)
		{
			var segments = CreateDefaultSegmentsDictionary(owner, reposlug);
			var request = new RestComplexRequest(Method.DELETE, segments, null, null);
			var task = MakeAsyncRequest<string>(DEFAULT_SPECIFIC_REPOSITORY_RESOURCE, request);
			return task;			
		}
		
		public Task<PaginatedResponse<User>> GetWatchersAsync(string owner, string reposlug, 
															  PaginatedRequest paginatedRequest)
		{
			var segments = CreateDefaultSegmentsDictionary(owner, reposlug);
			var parameters = CreateDefaultPaginationParameters(paginatedRequest);
			var restRequest = new RestComplexRequest(Method.GET, segments, parameters);
			var task = MakeAsyncRequest<PaginatedResponse<User>>(WATCHERS_REPOSITORY_RESOURCE, restRequest);
			return task;			
		}
		
		public Task<PaginatedResponse<Repository>> GetForksAsync(string owner, string reposlug, 																		
																 PaginatedRequest paginatedRequest)
		{
			var segments = CreateDefaultSegmentsDictionary(owner, reposlug);
			var parameters = CreateDefaultPaginationParameters(paginatedRequest);
			var restRequest = new RestComplexRequest(Method.GET, segments, parameters);
			var task = MakeAsyncRequest<PaginatedResponse<Repository>>(FORKS_REPOSITORY_RESOURCE, restRequest);
			return task;	
		}
				
		public Task<PaginatedResponse<Repository>> GetAllAsync(string owner, PaginatedRequest paginatedRequest)
		{
			var segments = new Dictionary<string,string>()
			{
				{OWNER_SEGMENT, owner}
			};
			var parameters = CreateDefaultPaginationParameters(paginatedRequest);
			var restRequest = new RestComplexRequest(Method.GET, segments, parameters);
			var task = MakeAsyncRequest<PaginatedResponse<Repository>>(DEFAULT_OWNER_RESOURCE, restRequest);
			return task;	
		}
		
		public Task<PaginatedResponse<Repository>> GetAllPublicAsync(PaginatedRequest paginatedRequest)
		{
			var parameters = CreateDefaultPaginationParameters(paginatedRequest);
			var restRequest = new RestComplexRequest(Method.GET, null, parameters);
			var task = MakeAsyncRequest<PaginatedResponse<Repository>>(string.Empty, restRequest);
			return task;	
		}
	}
}
