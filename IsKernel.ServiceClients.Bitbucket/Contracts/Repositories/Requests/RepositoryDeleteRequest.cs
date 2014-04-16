using System;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Requests.Repositories;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Repositories.Requests
{
	public class RepositoryDeleteRequest : RepositoryBaseRequest
	{
		public RepositoryDeleteRequest(string owner, string repoSLug) 
			   : base(owner, repoSLug)
		{
			
		}
	}
}
