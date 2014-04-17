using System;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Repositories.Requests
{
	public class RepositoryRequest : RepositoryBaseRequest
	{
		public RepositoryRequest(string owner, string repoSLug) 
			   : base(owner, repoSLug)
		{
			
		}
	}
}
