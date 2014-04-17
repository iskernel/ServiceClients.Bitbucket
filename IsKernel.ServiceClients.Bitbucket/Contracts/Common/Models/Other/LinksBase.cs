using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Models.Common;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Other
{
	public class LinksBase : BitbucketJsonModel
	{
		[JsonProperty("self")]
		public Link Self {get;set;}
	}
}
