using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Other;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Users.Responses
{
	public class UserLinks : SelfAndAvatarLinks
	{
		[JsonProperty("repositories")]
		public Link Repositories {get;set;}
		
		[JsonProperty("html")]
		public Link Html {get;set;}
		
		[JsonProperty("followers")]
		public Link Followers {get;set;}
		
		[JsonProperty("following")]
		public Link Following {get;set;}
	}
}
