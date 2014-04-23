using System;
using Newtonsoft.Json;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Other
{
	public class SelfAndAvatarLinks : LinksBase
	{	
		[JsonProperty("avatar")]
		public Link Avatar {get;set;}
	}
}
