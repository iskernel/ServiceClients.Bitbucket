using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Repositories;
using IsKernel.ServiceClients.Bitbucket.Contracts.Users;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Repositories
{
	public class Repository : RepositoryBase
	{		
		[JsonProperty("owner")]
		public User Owner {get;set;}		
	}
}
