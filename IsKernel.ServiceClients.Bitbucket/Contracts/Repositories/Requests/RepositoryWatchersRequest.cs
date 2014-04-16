using System;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Requests.Repositories;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Repositories.Requests
{
	public class RepositoryWatchersRequest : RepositoryBaseRequest
	{
		public RepositoryWatchersRequest(string owner, string repoSLug) 
			   : base(owner, repoSLug)
		{
			
		}
	}
}
