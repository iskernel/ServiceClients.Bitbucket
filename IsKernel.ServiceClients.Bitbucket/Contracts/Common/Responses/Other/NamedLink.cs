﻿using System;
using Newtonsoft.Json;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses.Other
{
	public class NamedLink : Link
	{
		[JsonProperty("name")]
		public string Name {get;set;}
	}
}
