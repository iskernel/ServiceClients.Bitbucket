using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Repositories;
using IsKernel.ServiceClients.Bitbucket.Contracts.Repositories.Requests;
using IsKernel.ServiceClients.Bitbucket.Contracts.Repositories.Responses;
using IsKernel.ServiceClients.Bitbucket.Exceptions;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Concrete
{	
	public class BitbucketRepositoryClient : IBitbucketRepositoryClient
	{
		private const string REPOSITORY_URL = "https://api.bitbucket.org/2.0/repositories/";
		private readonly RestClient _client;
		
		public BitbucketRepositoryClient(IAuthenticator authentificator)
		{
			_client = new RestClient(REPOSITORY_URL);
			_client.Authenticator = authentificator;
		}
		
		public Task<RepositoryResponse> GetRepositoryAsync(RepositoryRequest repositoryRequest)
		{
			var taskCompletionSource = new TaskCompletionSource<RepositoryResponse>();
			
			var request = new RestRequest();
			request.AddUrlSegment(repositoryRequest.Owner.Name, repositoryRequest.Owner.Value);
			request.AddUrlSegment(repositoryRequest.RepoSlug.Name, repositoryRequest.RepoSlug.Value);
			request.Method = Method.GET;
			
			_client.ExecuteAsync(request, response => {
				try
				{
					var repository = JsonConvert.DeserializeObject<Repository>(response.Content);
					var repositoryResponse = new RepositoryResponse() { Repository = repository };
					taskCompletionSource.SetResult(repositoryResponse);
				}
				catch(Exception exception)
				{
					var bitbucketException = new BitbucketException("Could not read repository", exception);
					taskCompletionSource.SetException(bitbucketException);
				}

			});			
			return taskCompletionSource.Task;			
		}
		
		public Task<bool> CreateRepositoryAsync(RepositoryPostRequest repositoryRequest)
		{
			var taskCompletionSource = new TaskCompletionSource<bool>();
			
			var request = new RestRequest();
			request.AddUrlSegment(repositoryRequest.Owner.Name, repositoryRequest.Owner.Value);
			request.AddUrlSegment(repositoryRequest.RepoSlug.Name, repositoryRequest.RepoSlug.Value);
			request.Method = Method.POST;
			var json = repositoryRequest.OptionalParameters.ToJson();
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
		
	}
}
