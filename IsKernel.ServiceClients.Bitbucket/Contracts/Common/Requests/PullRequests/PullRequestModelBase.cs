using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Branches;
using IsKernel.ServiceClients.Bitbucket.Contracts.Users.Responses;
using IsKernel.ServiceClients.Bitbucket.Models.Common;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Requests.PullRequests
{
	public abstract class PullRequestModelBase : BitbucketJsonModel
	{
		[JsonProperty("title")]
		public string Title {get;set;}
		
		[JsonProperty("description")]
		public string Description {get;set;}
		
		[JsonProperty("destination")]
		public BranchLocation Destination {get;set;}
		
		[JsonProperty("reviewers")]
		public User[] Reviewers {get;set;}
		
		[JsonProperty("close_source_branch")]
		public bool? CloseSourceBranch {get;set;}
	}
}
