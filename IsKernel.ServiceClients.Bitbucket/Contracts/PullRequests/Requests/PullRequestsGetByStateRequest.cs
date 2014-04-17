using System;
using System.Collections.Generic;
using IsKernel.ServiceClients.Bitbucket.Contracts.Repositories.Requests;
using IsKernel.ServiceClients.Bitbucket.Models.Common;
using IsKernel.ServiceClients.Bitbucket.Models.PullRequests;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.PullRequests.Requests
{
	public class PullRequestsGetByStateRequest : RepositoryBaseRequest
	{
		private readonly MultiValueRequestParameter<PullRequestState> _states;
		
		public PullRequestsGetByStateRequest(string owner, string repoSlug, IEnumerable<PullRequestState> values = null) 
			   : base(owner, repoSlug)
		{
			_states = new MultiValueRequestParameter<PullRequestState>("state", values);
		}
		
		
		public MultiValueRequestParameter<PullRequestState> States 
		{
			get 
			{
				return _states;
			}
		}
	}
}
