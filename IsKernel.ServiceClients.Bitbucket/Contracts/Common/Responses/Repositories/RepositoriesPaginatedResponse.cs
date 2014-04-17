using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Repositories;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses.Other;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses.Repositories
{
	public class RepositoriesPaginatedResponse : PaginatedResponse
	{
		[JsonProperty("values")]
		public Repository[] Values {get;set;}
	}
}
