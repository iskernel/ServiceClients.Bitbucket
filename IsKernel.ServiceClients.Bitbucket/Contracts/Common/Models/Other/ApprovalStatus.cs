﻿using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Users;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Other
{
	public class ApprovalStatus
	{
		[JsonProperty("date")]
		public DateTime? Date {get;set;}
		
		[JsonProperty("user")]
		public User User {get;set;}
			
	}
}
