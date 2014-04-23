using System;
using System.Threading.Tasks;
using RestSharp;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;
using IsKernel.ServiceClients.Bitbucket.Contracts.Commits;
using IsKernel.ServiceClients.Bitbucket.Contracts.Responses;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Concrete
{
	public class BitbucketCommitClient : BitbucketClientBase, IBitbucketCommitClient
	{
		private const string COMMITS_BASE_URL = "https://api.bitbucket.org/2.0/repositories";
		private const string COMMITS_DEFAULT_RESOURCE =  @"/{owner}/{repo_slug}/commits";
		private const string COMMITS_BRANCH_RESOURCE =  @"/{owner}/{repo_slug}/commits/{branch}";
		
		public BitbucketCommitClient(IAuthenticator authentificator) : base(authentificator, COMMITS_BASE_URL)
		{
			
		}
		
		public Task<PaginatedResponse<Commit>> GetCommitsForRepositoryAsync(string owner, string repoSlug)
		{
			return null;
		}
		
		
	}
}
