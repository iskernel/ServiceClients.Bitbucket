using System;
using Newtonsoft.Json;
using RestSharp.Serializers;

namespace IsKernel.ServiceClients.Bitbucket.Infrastructure
{
	public class JsonCustomSerializer : ISerializer
	{
		public JsonCustomSerializer()
		{
			ContentType = "application/json";
		}

		#region ISerializer implementation

		public string Serialize(object obj)
		{
			var jsonSerializerSettings = new JsonSerializerSettings()
			{
				NullValueHandling = NullValueHandling.Ignore
			};
			var jsonString = JsonConvert.SerializeObject(obj, jsonSerializerSettings);
			return jsonString;
		}
	
		public string RootElement {get;set;}
	
		public string Namespace  {get;set;}
	
		public string DateFormat {get;set;}
	
		public string ContentType {get;set;}

		#endregion
	}
}
