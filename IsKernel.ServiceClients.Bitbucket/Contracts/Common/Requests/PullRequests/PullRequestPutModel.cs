using System;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Branches;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Users;
namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Requests.PullRequests
{
	public class PullRequestPutModel : PullRequestModelBase
	{	
		public PullRequestPutModel(string title, string description, BranchLocation destination,
								   User[] reviewers, bool closeSourceBranch)
		{
			Title = title;
			Description = description;
			Destination = destination;
			Reviewers = reviewers;
			CloseSourceBranch = closeSourceBranch;
		}
				
	}
}
