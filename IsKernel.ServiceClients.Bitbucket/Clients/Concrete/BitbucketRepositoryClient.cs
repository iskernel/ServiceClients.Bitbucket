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
			var taskCompletionSource = new TaskCompletionSource<Repository>();
			
			var request = new RestRequest(DEFAULT_SPECIFIC_REPOSITORY_RESOURCE);
			request.AddUrlSegment(OWNER_SEGMENT, owner);
			request.AddUrlSegment(REPO_SLUG_SEGMENT, reposlug);
			
			request.Method = Method.GET;
			_client.ExecuteAsync(request, response => {
				try {
					var repository = JsonConvert.DeserializeObject<Repository>(response.Content);
					taskCompletionSource.SetResult(repository);
				} catch (Exception exception) {
					var bitbucketException = new BitbucketException("Could not read repository", exception);
					taskCompletionSource.SetException(bitbucketException);
				}

			});			
			return taskCompletionSource.Task;			
		}
		
		public Task<bool> CreateAsync(string owner, string reposlug, RepositoryCreateOptionalParameters optional)
		{
			var taskCompletionSource = new TaskCompletionSource<bool>();
			var request = new RestRequest(DEFAULT_SPECIFIC_REPOSITORY_RESOURCE, Method.POST);
			
			request.AddUrlSegment(OWNER_SEGMENT, owner);
			request.AddUrlSegment(REPO_SLUG_SEGMENT, reposlug);
			request.RequestFormat = DataFormat.Json;
			request.AddBody(optional);
			
			_client.ExecuteAsync(request, response => {
				try {
					taskCompletionSource.SetResult(true);
				} catch (Exception exception) {
					var bitbucketException = new BitbucketException("Could not post repository", exception);
					taskCompletionSource.SetException(bitbucketException);
				}

			});			
			return taskCompletionSource.Task;			
		}
		
		public Task<bool> DeleteAsync(string owner, string reposlug)
		{
			var taskCompletionSource = new TaskCompletionSource<bool>();
			
			var request = new RestRequest(DEFAULT_SPECIFIC_REPOSITORY_RESOURCE);
			request.AddUrlSegment(OWNER_SEGMENT, owner);
			request.AddUrlSegment(REPO_SLUG_SEGMENT, reposlug);
			request.Method = Method.DELETE;
			
			_client.ExecuteAsync(request, response => {
				try {
					taskCompletionSource.SetResult(true);
				} catch (Exception exception) {
					var bitbucketException = new BitbucketException("Could not delete repository", exception);
					taskCompletionSource.SetException(bitbucketException);
				}

			});			
			return taskCompletionSource.Task;			
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
			var task = MakeAsyncRequest<PaginatedResponse<Repository>>(FORKS_REPOSITORY_RESOURCE, restRequest);
			return task;	
		}
		
		public Task<PaginatedResponse<Repository>> GetAllPublicAsync(PaginatedRequest paginatedRequest)
		{
			var parameters = CreateDefaultPaginationParameters(paginatedRequest);
			var restRequest = new RestComplexRequest(Method.GET, null, parameters);
			var task = MakeAsyncRequest<PaginatedResponse<Repository>>(FORKS_REPOSITORY_RESOURCE, restRequest);
			return task;	
		}
	}
}
