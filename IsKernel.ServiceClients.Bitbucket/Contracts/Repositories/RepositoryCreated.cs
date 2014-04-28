using System;
using Newtonsoft.Json;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Repositories
{
	public class RepositoryCreated : RepositoryBase
	{
		[JsonProperty("owner")]
		public string Owner {get;set;}
	}
}
