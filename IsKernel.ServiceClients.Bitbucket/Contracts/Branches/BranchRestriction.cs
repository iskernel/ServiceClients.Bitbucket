using System;
using System.Text;
using Newtonsoft.Json;
using RestSharp.Contrib;
using IsKernel.ServiceClients.Bitbucket.Contracts.Other;
using IsKernel.ServiceClients.Bitbucket.Contracts.Users;
using IsKernel.ServiceClients.Bitbucket.Infrastructure.Extensions;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Branches
{
	public class BranchRestriction : BitbucketModel
	{
		[JsonProperty("groups")]
		public Group[] Groups {get;set;}
		
		[JsonProperty("id")]
		public long? Id {get;set;}
		
		[JsonProperty("links")]
		public BranchRestrictionLinks Links {get;set;}
		
		[JsonProperty("kind")]
		public string Kind {get;set;}
		
		[JsonProperty("pattern")]
		public string Pattern {get;set;}
		
		[JsonProperty("users")]
		public User[] Users {get;set;}
		
		public string CreatePostData()
		{
			var query = HttpUtility.ParseQueryString(string.Empty);
			if(Id!=null)
			{
				query["id"] = Id.ToString();
			}
			if(Kind!=null)
			{
				query["kind"] = Kind;
			}
			if(Pattern!=null)
			{
				query["pattern"] = Pattern;
			}
			if(Users!=null)
			{
				var builder = new StringBuilder();
				foreach (var element in Users) 
				{
					builder.Append(element.Username);
					builder.Append("|");	
				}
				var tempString = builder.ToString();
				query["users"] = tempString.Substring(0, tempString.Length - 1);
			}
			string queryString = query.ToPostData();
			return queryString;
		}
	}
}
