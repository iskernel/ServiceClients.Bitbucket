using System;
using IsKernel.ServiceClients.Bitbucket.Exceptions;
using IsKernel.ServiceClients.Bitbucket.Models.Common;
using IsKernel.ServiceClients.Bitbucket.Models.Repositories;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Repositories.Requests
{
	public class RepositoryPostRequest : RepositoryBaseRequest
	{	
		public RepositoryPostOptionalParametersModel OptionalParameters {get;set;}
		
		public RepositoryPostRequest(string owner, string repoSLug, 
									RepositoryPostOptionalParametersModel optionalParameters) 
			   : base(owner, repoSLug)
		{
			OptionalParameters = optionalParameters;
		}
	}
}
