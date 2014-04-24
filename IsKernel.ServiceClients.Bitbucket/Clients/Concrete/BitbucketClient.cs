﻿using System;
using RestSharp;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Concrete
{
	public class BitbucketClient : IBitbucketClient
	{
		public BitbucketClient(IAuthenticator authentificator)
		{
			RepositoryClient = new BitbucketRepositoryClient(authentificator);
			PullRequestClient = new BitbucketPullRequestClient(authentificator);
			CommitClient = new BitbucketCommitClient(authentificator);
		}
		
		public IBitbucketRepositoryClient RepositoryClient {get; private set;}

		public IBitbucketPullRequestClient PullRequestClient {get; private set;}
		
		public IBitbucketCommitClient CommitClient {get; private set;}
	}
}
