using System;
using Newtonsoft.Json;

namespace IsKernel.ServiceClients.Bitbucket.Contracts
{
	public abstract class BitbucketModel
	{
		public virtual string ToDataString()
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
