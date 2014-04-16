using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses.Other;
using IsKernel.ServiceClients.Bitbucket.Contracts.Users.Responses;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses.Users
{
	public class UsersPaginatedResponse : PaginatedResponse
	{
		[JsonProperty("values")]
		public User[] Values {get;set;}
	}
}
