using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RestSharp.Contrib;
using IsKernel.ServiceClients.Bitbucket.Contracts.Other;
using IsKernel.ServiceClients.Bitbucket.Contracts.Users;

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
		
		public Dictionary<string,string> CreatePostData()
		{
			var dictionary = new Dictionary<string,string>();
			if(Id!=null)
			{
				dictionary.Add("id", Id.ToString());
			}
			if(Kind!=null)
			{
				dictionary.Add("kind", Kind.ToString());
			}
			if(Pattern!=null)
			{
				dictionary.Add("pattern", Pattern.ToString());
			}
			if( (Users!=null) && (Users.Length > 0) )
			{
				var builder = new StringBuilder();
				foreach (var element in Users) 
				{
					builder.Append(element.Username);
					builder.Append("|");	
				}
				var tempString = builder.ToString();
				dictionary.Add("users", tempString.Substring(0, tempString.Length - 1));
			}
			return dictionary;
		}
	}
}
