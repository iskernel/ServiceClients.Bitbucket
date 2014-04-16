using System;
using IsKernel.ServiceClients.Bitbucket.Exceptions;
using IsKernel.ServiceClients.Bitbucket.Models.Common;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Requests.Repositories
{
	public abstract class RepositoryBaseRequest
	{
		private readonly RequestParameter<string> _owner;
		private readonly RequestParameter<string> _repoSlug;
		
		protected RepositoryBaseRequest(string owner, string repoSLug)
		{
			if(string.IsNullOrWhiteSpace(owner) == true)
			{
				throw new RequestParameterException("Owner of the repository cannot be null");
			}
			if(string.IsNullOrWhiteSpace(repoSLug) == true)
			{
				throw new RequestParameterException("Repository slug cannot be null");
			}
			_owner = new RequestParameter<string>("owner", owner);
			_repoSlug = new RequestParameter<string>("repo_slug", repoSLug);
		}
		
		
		public RequestParameter<string> Owner 
		{
			get 
			{
				return _owner;
			}
		}

		public RequestParameter<string> RepoSlug 
		{
			get 
			{
				return _repoSlug;
			}
		}
	}
}
