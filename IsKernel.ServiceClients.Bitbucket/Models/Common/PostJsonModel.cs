using System;
using System.IO;
using Newtonsoft.Json;

namespace IsKernel.ServiceClients.Bitbucket.Models.Common
{
	public abstract class PostJsonModel
	{
		public string ToJson()
		{
			var jsonString = JsonConvert.SerializeObject(this, Formatting.Indented);
			return jsonString;
		}
	}
}
