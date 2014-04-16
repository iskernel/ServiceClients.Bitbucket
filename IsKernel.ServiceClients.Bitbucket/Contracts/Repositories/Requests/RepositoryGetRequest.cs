using System;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Requests.Repositories;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Repositories.Requests
{
	public class RepositoryGetRequest : RepositoryBaseRequest
	{
		public RepositoryGetRequest(string owner, string repoSLug) 
			   : base(owner, repoSLug)
		{
			
		}
	}
}
