using System;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Requests.PullRequests;
using IsKernel.ServiceClients.Bitbucket.Exceptions;
using IsKernel.ServiceClients.Bitbucket.Models.Common;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.PullRequests.Requests
{
	public class PullRequestGetSpecific : PullRequestSpecificRequestBase
	{
		public PullRequestGetSpecific(string owner, string repoSlug, string pullRequestId) 
			   : base(owner, repoSlug, pullRequestId)
		{
			
		}
	}
}
