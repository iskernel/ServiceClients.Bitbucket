using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Other;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.PullRequests
{
	public class PullRequestComment
	{
		[JsonProperty("comment")]
		public Comment Comment {get;set;}
		
		[JsonProperty("pull_request")]
		public PullRequest PullRequest {get;set;}
	}
}
