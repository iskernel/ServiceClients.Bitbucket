using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Users;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Other
{
	public class ApprovalStatus
	{
		[JsonProperty("date")]
		public DateTime? Date {get;set;}
		
		[JsonProperty("user")]
		public User User {get;set;}
			
	}
}
