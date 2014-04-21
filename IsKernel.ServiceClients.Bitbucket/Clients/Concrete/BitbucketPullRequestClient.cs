using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.PullRequests;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses;
using IsKernel.ServiceClients.Bitbucket.Exceptions;
using IsKernel.ServiceClients.Bitbucket.Models.Common;
using IsKernel.ServiceClients.Bitbucket.Models.PullRequests;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Concrete
{
	public class BitbucketPullRequestClient : BitbucketClientBase, IBitbucketPullRequestClient
	{
		private const string OWNER_SEGMENT = "owner";
		private const string REPO_SLUG_SEGMENT = "repo_slug";
		
		private const string PULL_REQUEST_BASE_URL = "https://bitbucket.org/api/1.0/repositories";
		private const string DEFAULT_PULL_REQUEST_RESOURCE = @"/{owner}/{repo_slug}";
		
		public BitbucketPullRequestClient(IAuthenticator authentificator) : base(authentificator, PULL_REQUEST_BASE_URL)
		{
			
		}
		
		public Task<PaginatedResponse<PullRequest>> GetPullRequestsAsync(string owner, string reposlug, 
														     			MultiValueRequestParameter<PullRequestState> states)
		{
			var taskCompletionSource = new TaskCompletionSource<PaginatedResponse<PullRequest>>();
			
			var request = new RestRequest(DEFAULT_PULL_REQUEST_RESOURCE);
			request.AddUrlSegment(OWNER_SEGMENT, owner);
			request.AddUrlSegment(REPO_SLUG_SEGMENT, reposlug);
			request.AddParameter(states.Name, states.ParameterValue);
			
			request.Method = Method.GET;
			_client.ExecuteAsync(request, response => {
				try {
					var result = JsonConvert.DeserializeObject<PaginatedResponse<PullRequest>>(response.Content);
					taskCompletionSource.SetResult(result);
				} catch (Exception exception) {
					var bitbucketException = new BitbucketException("Could not read repository pull requests.", exception);
					taskCompletionSource.SetException(bitbucketException);
				}

			});			
			return taskCompletionSource.Task;	
		}
	}
}
