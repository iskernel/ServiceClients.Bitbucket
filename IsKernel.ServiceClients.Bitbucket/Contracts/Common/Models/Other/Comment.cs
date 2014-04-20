﻿using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Users;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Other
{
	public class Comment : BitbucketJsonModel
	{
		[JsonProperty("parent")]
		public Comment Parent {get;set;}
		
		[JsonProperty("links")]
		public LinksBase Links {get;set;}
		
		[JsonProperty("comment")]
		public Content Content {get;set;}
		
		[JsonProperty("created_on")]
		public DateTime? CreatedOn {get;set;}
		
		[JsonProperty("updated_on")]
		public DateTime? UpdatedOn {get;set;}
		
		[JsonProperty("user")]
		public User User {get;set;}
		
		[JsonProperty("inline")]
		public Inline Inline {get;set;}
		
		[JsonProperty("id")]
		public long? Id {get;set;}
	}
}