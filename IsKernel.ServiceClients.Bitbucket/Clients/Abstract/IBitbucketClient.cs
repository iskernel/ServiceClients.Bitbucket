﻿using System;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Abstract
{
	public interface IBitbucketClient
	{
		IBitbucketRepositoryClient RepositoryClient {get;}
	}
}