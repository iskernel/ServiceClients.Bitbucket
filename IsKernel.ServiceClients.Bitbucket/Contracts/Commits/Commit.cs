﻿using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Models.Repositories;
using IsKernel.ServiceClients.Bitbucket.Contracts.Users;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Commits
{
	public class Commit : BitbucketJsonModel
	{
		[JsonProperty("hash")]
		public string Hash {get;set;}
		
		[JsonProperty("links")]
		public CommitLinks Links {get;set;}
		
		[JsonProperty("repository")]
		public Repository Repository {get;set;}
		
		[JsonProperty("author")]
		public Author Author {get;set;}
		
		[JsonProperty("parents")]
		public Commit[] Parents {get;set;}
		
		[JsonProperty("date")]
		public DateTime? Date {get;set;}
		
		[JsonProperty("message")]
		public string Message {get;set;}
	}
}