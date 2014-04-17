using System;
using Newtonsoft.Json;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common
{
	public abstract class BitbucketJsonModel
	{
		public string ToJson()
		{
			var jsonString = JsonConvert.SerializeObject(this, Formatting.Indented);
			return jsonString;
		}
	}
}
