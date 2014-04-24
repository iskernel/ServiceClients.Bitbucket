using System;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Abstract
{
	public interface IBitbucketClient
	{
		IBitbucketRepositoryClient RepositoryClient {get;}
		IBitbucketPullRequestClient PullRequestClient {get;}
		IBitbucketCommitClient CommitClient {get;}
		IBitbucketBranchRestrictionClient BranchRestrictionClient{get;}
		IBitbucketDiffClient DiffClient {get;}
		IBitbucketTeamClient TeamClient {get;}
		IBitbucketUserClient UserClient {get;}
	}
}
