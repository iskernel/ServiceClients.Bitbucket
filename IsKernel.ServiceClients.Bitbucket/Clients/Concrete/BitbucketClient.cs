using System;
using RestSharp;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Concrete
{
	public class BitbucketClient : IBitbucketClient
	{
		private readonly IAuthenticator _authentificator;
		private BitbucketDiffClient _diffClient = null;
		private BitbucketRepositoryClient _repositoryClient = null;
		private BitbucketPullRequestClient _pullRequestClient = null;
		private BitbucketCommitClient _commitClient = null;
		private BitbucketBranchRestrictionClient _branchRestrictionClient = null;
		private BitbucketTeamClient _teamClient = null;
		private BitbucketUserClient _userClient = null;
		
		public BitbucketClient(IAuthenticator authentificator)
		{
			_authentificator = authentificator;
		}
		
		public IBitbucketRepositoryClient RepositoryClient 
		{
			get
			{
				if(_repositoryClient == null)
				{
					_repositoryClient = new BitbucketRepositoryClient(_authentificator);
				}
				return _repositoryClient;
			}
		}

		public IBitbucketPullRequestClient PullRequestClient 
		{
			get
			{
				if(_pullRequestClient == null)
				{
					_pullRequestClient = new BitbucketPullRequestClient(_authentificator);
				}
				return _pullRequestClient;
			}
		}
		
		public IBitbucketCommitClient CommitClient
		{
			get
			{
				if(_commitClient == null)
				{
					_commitClient = new BitbucketCommitClient(_authentificator);
				}
				return _commitClient;
			}
		}

		public IBitbucketBranchRestrictionClient BranchRestrictionClient
		{
			get
			{
				if(_branchRestrictionClient == null)
				{
					_branchRestrictionClient = new BitbucketBranchRestrictionClient(_authentificator);
				}
				return _branchRestrictionClient;
			}
		}
		
		public IBitbucketDiffClient DiffClient 
		{
			get
			{
				if(_diffClient == null)
				{
					_diffClient = new BitbucketDiffClient(_authentificator);
				}
				return _diffClient;
			}
		}
	
		public IBitbucketTeamClient TeamClient
		{
			get
			{
				if(_teamClient == null)
				{
					_teamClient = new BitbucketTeamClient(_authentificator);
				}
				return _teamClient;
			}
		}
	
		public IBitbucketUserClient UserClient 
		{
			get
			{
				if(_userClient == null)
				{
					_userClient = new BitbucketUserClient(_authentificator);
				}
				return _userClient;
			}
		}
	}
}
