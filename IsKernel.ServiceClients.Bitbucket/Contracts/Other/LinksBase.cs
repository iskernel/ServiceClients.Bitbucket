using System;
using Newtonsoft.Json;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Other
{
	public class LinksBase : BitbucketJsonModel
	{
		[JsonProperty("self")]
		public Link Self {get;set;}
	}
}
