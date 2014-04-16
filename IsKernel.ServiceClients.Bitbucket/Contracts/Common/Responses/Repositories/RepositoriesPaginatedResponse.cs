using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses.Other;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses.Repositories;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses.Repositories
{
	public class RepositoriesPaginatedResponse : PaginatedResponse
	{
		[JsonProperty("values")]
		public Repository[] Values {get;set;}
	}
}
