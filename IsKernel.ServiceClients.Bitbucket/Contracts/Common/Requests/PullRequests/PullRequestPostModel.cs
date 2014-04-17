using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Branches;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Users;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Requests.PullRequests
{
	public class PullRequestPostModel : PullRequestModelBase
	{
		public PullRequestPostModel(string title, BranchLocation source)
		{
			Title = title;
			Source = source;
		}
		
		public PullRequestPostModel(string title, string description, BranchLocation source, BranchLocation destination,
									User[] reviewers, bool closeSourceBranch)
			:this(title, source)
		{
			Description = description;
			Destination = destination;
			Reviewers = reviewers;
			CloseSourceBranch = closeSourceBranch;
		}
				
		[JsonProperty("source")]
		public BranchLocation Source {get;set;}
		
	}
}
