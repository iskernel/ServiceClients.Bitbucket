using System;
using Newtonsoft.Json;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Other
{
	public class LinksBase : BitbucketModel
	{
		[JsonProperty("self")]
		public Link Self {get;set;}
	}
}
