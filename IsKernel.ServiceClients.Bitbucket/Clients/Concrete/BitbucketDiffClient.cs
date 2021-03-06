﻿using System;
using System.Threading.Tasks;
using RestSharp;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;
using IsKernel.ServiceClients.Bitbucket.Clients.Concrete;
using IsKernel.ServiceClients.Bitbucket.Infrastructure.Rest;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Concrete
{
	public class BitbucketDiffClient : BitbucketRepositoryClientBase, IBitbucketDiffClient
	{
		private const string SPEC_SEGMENT = "spec";
		
		private const string BASE_URL = "https://bitbucket.org/api/2.0";
		private const string DIFF_RESOURCE = "/repositories/{owner}/{repo_slug}/diff/{spec}";
		private const string PATCH_RESOURCE = "/repositories/{owner}/{repo_slug}/patch/{spec}";
		
		public BitbucketDiffClient(IAuthenticator authenticator) : base(authenticator, BASE_URL)
		{
			
		}
		
		public Task<string> GetDiffAsync(string owner, string reposlug, string spec)
		{
			var segments = CreateDefaultSegmentsDictionary(owner, reposlug);
			segments.Add(SPEC_SEGMENT, spec);
			var restRequest = new RestComplexRequest(Method.GET, segments, null, null);	
			var task = MakeAsyncRequest<string>(DIFF_RESOURCE, restRequest);
			return task;
		}
		
		public Task<string> GetPatchAsync(string owner, string reposlug, string spec)
		{
			var segments = CreateDefaultSegmentsDictionary(owner, reposlug);
			segments.Add(SPEC_SEGMENT, spec);
			var restRequest = new RestComplexRequest(Method.GET, segments, null, null);	
			var task = MakeAsyncRequest<string>(PATCH_RESOURCE, restRequest);
			return task;
		}
	}
}

