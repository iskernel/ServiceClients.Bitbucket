using System;
using Newtonsoft.Json;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common
{
	public abstract class BitbucketJsonModel
	{
		public string ToJson()
		{
			var jsonSerializerSettings = new JsonSerializerSettings()
			{
				Formatting = Formatting.Indented,
				NullValueHandling = NullValueHandling.Ignore
			};
			var jsonString = JsonConvert.SerializeObject(this, jsonSerializerSettings);
			return jsonString;
		}
	}
}
