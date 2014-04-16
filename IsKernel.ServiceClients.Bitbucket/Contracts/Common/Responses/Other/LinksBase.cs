using System;
using Newtonsoft.Json;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses.Other
{
	public class LinksBase
	{
		[JsonProperty("self")]
		public Link Self {get;set;}
	}
}
