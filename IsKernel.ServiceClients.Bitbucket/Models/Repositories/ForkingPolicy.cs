using System;
using IsKernel.ServiceClients.Bitbucket.Models.Common;

namespace IsKernel.ServiceClients.Bitbucket.Models.Repositories
{
	public class ForkingPolicy : PrivateValueModel<string>
	{		
		private ForkingPolicy(string value) : base(value)
		{
			
		}
			
		public static readonly ForkingPolicy AllowForks = new ForkingPolicy("allow_forks");
		public static readonly ForkingPolicy NoPublicForks = new ForkingPolicy("no_public_forks");
		public static readonly ForkingPolicy NoForks = new ForkingPolicy("no_forks");
	}
}
