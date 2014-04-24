using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;
using IsKernel.ServiceClients.Bitbucket.Contracts.Models.Repositories;
using IsKernel.ServiceClients.Bitbucket.Contracts.Repositories.Parameters;
using IsKernel.ServiceClients.Bitbucket.Contracts.Requests;
using IsKernel.ServiceClients.Bitbucket.Contracts.Responses;
using IsKernel.ServiceClients.Bitbucket.Contracts.Users;
using IsKernel.ServiceClients.Bitbucket.Exceptions;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Concrete
{
	public class BitbucketRepositoryClient : BitbucketRepositoryClientBase, IBitbucketRepositoryClient
	{		
		private const string REPOSITORY_BASE_URL = "https://api.bitbucket.org/2.0/repositories";
		private const string DEFAULT_SPECIFIC_REPOSITORY_RESOURCE = @"/{owner}/{repo_slug}";
		private const string DEFAULT_OWNER_RESOURCE = @"/{owner}";
		private const string WATCHERS_REPOSITORY_RESOURCE = @"/{owner}/{repo_slug}/watchers";
		
				
		public BitbucketRepositoryClient(IAuthenticator authentificator)
			: base(authentificator, REPOSITORY_BASE_URL)
		{
			
		}
		
		public Task<Repository> GetRepositoryAsync(string owner, string reposlug)
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
		
		public Task<bool> CreateRepositoryAsync(string owner, string reposlug, RepositoryCreateOptionalParameters optional)
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
		
		public Task<bool> DeleteRepositoryAsync(string owner, string reposlug)
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
		
		public Task<PaginatedResponse<User>> GetRepositoryWatchersAsync(string owner, string reposlug, 
			PaginatedRequest paginatedRequest)
		{
			var taskCompletionSource = new TaskCompletionSource<PaginatedResponse<User>>();
			
			var request = new RestRequest(WATCHERS_REPOSITORY_RESOURCE);
			request.AddUrlSegment(OWNER_SEGMENT, owner);
			request.AddUrlSegment(REPO_SLUG_SEGMENT, reposlug);
			request = AddPaginationParameters(request, paginatedRequest);
			request.Method = Method.GET;
			
			_client.ExecuteAsync(request, response => {
				try {
					var list = JsonConvert.DeserializeObject<PaginatedResponse<User>>(response.Content);
					taskCompletionSource.SetResult(list);
				} catch (Exception exception) {
					var bitbucketException = new BitbucketException("Could not retrieve watchers.", exception);
					taskCompletionSource.SetException(bitbucketException);
				}

			});			
			return taskCompletionSource.Task;		
		}
		
		public Task<PaginatedResponse<Repository>> GetAllRepositoryForksAsync(string owner, string reposlug, 																		
			PaginatedRequest paginatedRequest)
		{
			var taskCompletionSource = new TaskCompletionSource<PaginatedResponse<Repository>>();
			
			var request = new RestRequest(WATCHERS_REPOSITORY_RESOURCE);
			request.AddUrlSegment(OWNER_SEGMENT, owner);
			request.AddUrlSegment(REPO_SLUG_SEGMENT, reposlug);
			request = AddPaginationParameters(request, paginatedRequest);
			request.Method = Method.GET;
			
			_client.ExecuteAsync(request, response => {
				try {
					var list = JsonConvert.DeserializeObject<PaginatedResponse<Repository>>(response.Content);
					taskCompletionSource.SetResult(list);
				} catch (Exception exception) {
					var bitbucketException = new BitbucketException("Could not retrieve forks.", exception);
					taskCompletionSource.SetException(bitbucketException);
				}

			});			
			return taskCompletionSource.Task;		
		}
				
		public Task<PaginatedResponse<Repository>> GetAllRepositoriesForUserAsync(string owner, PaginatedRequest paginatedRequest)
		{
			var taskCompletionSource = new TaskCompletionSource<PaginatedResponse<Repository>>();
			var request = new RestRequest(DEFAULT_OWNER_RESOURCE);
			request.AddUrlSegment(OWNER_SEGMENT, owner);
			request = AddPaginationParameters(request, paginatedRequest);
			request.Method = Method.GET;
			
			_client.ExecuteAsync(request, response => {
				try {
					var list = JsonConvert.DeserializeObject<PaginatedResponse<Repository>>(response.Content);
					taskCompletionSource.SetResult(list);
				} catch (Exception exception) {
					var bitbucketException = new BitbucketException("Could not retrieve repositories.", exception);
					taskCompletionSource.SetException(bitbucketException);
				}

			});			
			return taskCompletionSource.Task;	
		}
		
		public Task<PaginatedResponse<Repository>> GetAllPublicRepositoriesAsync(PaginatedRequest paginatedRequest)
		{
			var taskCompletionSource = new TaskCompletionSource<PaginatedResponse<Repository>>();
			var request = new RestRequest(REPOSITORY_BASE_URL);
			request = AddPaginationParameters(request, paginatedRequest);
			request.Method = Method.GET;
			
			_client.ExecuteAsync(request, response => {
				try {
					var list = JsonConvert.DeserializeObject<PaginatedResponse<Repository>>(response.Content);
					taskCompletionSource.SetResult(list);
				} catch (Exception exception) {
					var bitbucketException = new BitbucketException("Could not retrieve repositories.", exception);
					taskCompletionSource.SetException(bitbucketException);
				}

			});			
			return taskCompletionSource.Task;	
		}
	}
}
