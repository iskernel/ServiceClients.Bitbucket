using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Repositories;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Users;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses;
using IsKernel.ServiceClients.Bitbucket.Contracts.Repositories.Requests;
using IsKernel.ServiceClients.Bitbucket.Exceptions;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Concrete
{	
	public class BitbucketRepositoryClient : IBitbucketRepositoryClient
	{
		private const string OWNER_SEGMENT = "owner";
		private const string REPO_SLUG_SEGMENT = "repo_slug";
		
		private const string REPOSITORY_URL = "https://api.bitbucket.org/2.0/repositories";
		private const string DEFAULT_REPOSITORY_RESOURCE = @"/{owner}/{repo_slug}";
		private const string WATCHERS_REPOSITORY_RESOURCE = DEFAULT_REPOSITORY_RESOURCE + @"/watchers";
		
		private readonly RestClient _client;
		
		public BitbucketRepositoryClient(IAuthenticator authentificator)
		{
			_client = new RestClient(REPOSITORY_URL);
			_client.Authenticator = authentificator;
		}
		
		public Task<Repository> GetRepositoryAsync(string owner, string reposlug)
		{
			var taskCompletionSource = new TaskCompletionSource<Repository>();
			
			var request = new RestRequest(DEFAULT_REPOSITORY_RESOURCE);
			request.AddUrlSegment(OWNER_SEGMENT, owner);
			request.AddUrlSegment(REPO_SLUG_SEGMENT, reposlug);
			request.Method = Method.GET;
			_client.ExecuteAsync(request, response => {
				try
				{
					var repository = JsonConvert.DeserializeObject<Repository>(response.Content);
					taskCompletionSource.SetResult(repository);
				}
				catch(Exception exception)
				{
					var bitbucketException = new BitbucketException("Could not read repository", exception);
					taskCompletionSource.SetException(bitbucketException);
				}

			});			
			return taskCompletionSource.Task;			
		}
		
		public Task<bool> CreateRepositoryAsync(string owner, string reposlug, RepositoryAddOptionalParametersModel optional)
		{
			var taskCompletionSource = new TaskCompletionSource<bool>();
			
			var request = new RestRequest(DEFAULT_REPOSITORY_RESOURCE);
			request.AddUrlSegment(OWNER_SEGMENT, owner);
			request.AddUrlSegment(REPO_SLUG_SEGMENT, reposlug);
			request.Method = Method.POST;
			var json = optional.ToJson();
			request.AddParameter("text/json", json, ParameterType.RequestBody);
			
			_client.ExecuteAsync(request, response => {
				try
				{
					taskCompletionSource.SetResult(true);
				}
				catch(Exception exception)
				{
					var bitbucketException = new BitbucketException("Could not post repository", exception);
					taskCompletionSource.SetException(bitbucketException);
				}

			});			
			return taskCompletionSource.Task;			
		}
		
		public Task<bool> DeleteRepositoryAsync(string owner, string reposlug)
		{
			var taskCompletionSource = new TaskCompletionSource<bool>();
			
			var request = new RestRequest(DEFAULT_REPOSITORY_RESOURCE);
			request.AddUrlSegment(OWNER_SEGMENT, owner);
			request.AddUrlSegment(REPO_SLUG_SEGMENT, reposlug);
			request.Method = Method.DELETE;
			
			_client.ExecuteAsync(request, response => {
				try
				{
					taskCompletionSource.SetResult(true);
				}
				catch(Exception exception)
				{
					var bitbucketException = new BitbucketException("Could not delete repository", exception);
					taskCompletionSource.SetException(bitbucketException);
				}

			});			
			return taskCompletionSource.Task;			
		}
		
		public Task<GenericPaginatedResponse<User>> GetRepositoryWatchersAsync(string owner, string reposlug)
		{
			var taskCompletionSource = new TaskCompletionSource<GenericPaginatedResponse<User>>();
			
			var request = new RestRequest(WATCHERS_REPOSITORY_RESOURCE);
			request.AddUrlSegment(OWNER_SEGMENT, owner);
			request.AddUrlSegment(REPO_SLUG_SEGMENT, reposlug);
			request.Method = Method.GET;
			
			_client.ExecuteAsync(request, response => {
				try
				{
					var list = JsonConvert.DeserializeObject<GenericPaginatedResponse<User>>(response.Content);
					taskCompletionSource.SetResult(list);
				}
				catch(Exception exception)
				{
					var bitbucketException = new BitbucketException("Could not retrieve watchers.", exception);
					taskCompletionSource.SetException(bitbucketException);
				}

			});			
			return taskCompletionSource.Task;		
		}
		
		public Task<GenericPaginatedResponse<Repository>> GetRepositoryForksAsync(string owner, string reposlug)
		{
			var taskCompletionSource = new TaskCompletionSource<GenericPaginatedResponse<Repository>>();
			
			var request = new RestRequest(WATCHERS_REPOSITORY_RESOURCE);
			request.AddUrlSegment(OWNER_SEGMENT, owner);
			request.AddUrlSegment(REPO_SLUG_SEGMENT, reposlug);
			request.Method = Method.GET;
			
			_client.ExecuteAsync(request, response => {
				try
				{
					var list = JsonConvert.DeserializeObject<GenericPaginatedResponse<Repository>>(response.Content);
					taskCompletionSource.SetResult(list);
				}
				catch(Exception exception)
				{
					var bitbucketException = new BitbucketException("Could not retrieve forks.", exception);
					taskCompletionSource.SetException(bitbucketException);
				}

			});			
			return taskCompletionSource.Task;		
		}
		
		
	}
}
