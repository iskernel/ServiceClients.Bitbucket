using System;
using IsKernel.ServiceClients.Bitbucket.Contracts.Repositories.Requests;
using IsKernel.ServiceClients.Bitbucket.Exceptions;
using IsKernel.ServiceClients.Bitbucket.Models.Common;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Requests.PullRequests
{
	public abstract class PullRequestSpecificRequestBase : RepositoryBaseRequest
	{
		private readonly RequestParameter<string> _pullRequestId;
		
		protected PullRequestSpecificRequestBase(string owner, string repoSlug, string pullRequestId) 
			   : base(owner, repoSlug)
		{
			if(string.IsNullOrWhiteSpace(pullRequestId) == true)
			{
				throw new RequestParameterException("Pull request id is null or whitespace");
			}
			_pullRequestId = new RequestParameter<string>("pull_request_id", pullRequestId);
		}
		
		
		public RequestParameter<string> Id 
		{
			get 
			{
				return _pullRequestId;
			}
		}
	}
}
