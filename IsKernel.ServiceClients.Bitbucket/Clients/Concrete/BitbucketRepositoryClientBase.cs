using System;
using System.Collections.Generic;
using RestSharp;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Concrete
{
	public abstract class BitbucketRepositoryClientBase : BitbucketClientBase
	{
		protected const string OWNER_SEGMENT = "owner";
		protected const string REPO_SLUG_SEGMENT = "repo_slug";
		
		protected BitbucketRepositoryClientBase(IAuthenticator authentificator, string clientBaseUrl = "") 
				  : base(authentificator, clientBaseUrl)
		{
			
		}
		
		protected Dictionary<string,string> CreateDefaultSegmentsDictionary(string owner, string reposlug)
		{
			var dictionary = new Dictionary<string,string>();
			dictionary.Add(OWNER_SEGMENT, owner);
			dictionary.Add(REPO_SLUG_SEGMENT, reposlug);
			return dictionary;
		}
	}
}
