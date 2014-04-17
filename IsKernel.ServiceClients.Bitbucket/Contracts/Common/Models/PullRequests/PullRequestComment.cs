using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Other;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.PullRequests
{
	public class PullRequestComment
	{
		[JsonProperty("comment")]
		public Comment Comment {get;set;}
		
		[JsonProperty("pull_request")]
		public PullRequest PullRequest {get;set;}
	}
}
