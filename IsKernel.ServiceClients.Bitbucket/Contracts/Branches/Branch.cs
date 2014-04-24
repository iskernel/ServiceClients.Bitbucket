using System;
using Newtonsoft.Json;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Branches
{
	public class Branch : BitbucketModel
	{
		[JsonProperty("name")]
		public string Name {get;set;}
	}
}
