﻿using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Other;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Repositories
{
	public class RepositoryLinks : SelfAndAvatarLinks
	{
		[JsonProperty("watchers")]
		public Link Watchers {get;set;}
		
		[JsonProperty("commits")]
		public Link Commits {get;set;}
		
		[JsonProperty("html")]
		public Link Html {get;set;}
		
		[JsonProperty("forks")]
		public Link Forks {get;set;}
		
		[JsonProperty("clone")]
		public NamedLink[] Clone {get;set;}
		
		[JsonProperty("pullrequests")]
		public Link PullRequests {get;set;}
	}
}
