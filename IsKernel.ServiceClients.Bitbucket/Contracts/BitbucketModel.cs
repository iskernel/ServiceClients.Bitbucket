using System;
using Newtonsoft.Json;

namespace IsKernel.ServiceClients.Bitbucket.Contracts
{
	public abstract class BitbucketModel
	{
		public virtual string Serialize()
		{
			var jsonSerializerSettings = new JsonSerializerSettings()
			{
				StringEscapeHandling = StringEscapeHandling.Default,
				Formatting = Formatting.Indented,
				NullValueHandling = NullValueHandling.Ignore
			};
			var jsonString = JsonConvert.SerializeObject(this, jsonSerializerSettings);
			return jsonString;
		}
	}
}
