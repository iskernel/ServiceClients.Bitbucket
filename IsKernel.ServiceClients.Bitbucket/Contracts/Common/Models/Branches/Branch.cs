using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Models.Common;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Branches
{
	public class Branch : BitbucketJsonModel
	{
		[JsonProperty("name")]
		public string Name {get;set;}
	}
}
