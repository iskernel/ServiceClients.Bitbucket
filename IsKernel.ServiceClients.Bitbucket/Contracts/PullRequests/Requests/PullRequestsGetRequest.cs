using System;
using System.Collections.Generic;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Requests.Repositories;
using IsKernel.ServiceClients.Bitbucket.Models.Common;
using IsKernel.ServiceClients.Bitbucket.Models.PullRequests;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.PullRequests.Requests
{
	public class PullRequestsGetRequest : RepositoryBaseRequest
	{
		private readonly MultiValueRequestParameter<PullRequestState> _states;
		
		public PullRequestsGetRequest(string owner, string repoSlug, IEnumerable<PullRequestState> values = null) 
			   : base(owner, repoSlug)
		{
			_states = new MultiValueRequestParameter<PullRequestState>("state", values);
		}
		
		
		public IEnumerable<PullRequestState> States 
		{
			get 
			{
				return _states.Values;
			}
		}
	}
}
