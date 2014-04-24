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
		
		protected List<Tuple<string,string>> CreateOwnerRepoSegments(string owner, string reposlug)
		{
			var list = new List<Tuple<string,string>>();
			list.Add(new Tuple<string, string>(OWNER_SEGMENT, owner));
			list.Add(new Tuple<string, string>(REPO_SLUG_SEGMENT, reposlug));
			return list;
		}
	}
}
