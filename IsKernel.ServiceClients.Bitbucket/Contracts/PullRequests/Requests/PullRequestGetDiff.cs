using System;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Requests.PullRequests;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.PullRequests.Requests
{
	public class PullRequestGetDiff : PullRequestSpecificRequestBase
	{
		public PullRequestGetDiff(string owner, string repoSlug, string pullRequestId) 
			   : base(owner, repoSlug, pullRequestId)
		{
			
		}
	}
}
