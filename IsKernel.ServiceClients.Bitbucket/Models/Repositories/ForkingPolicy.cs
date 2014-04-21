using System;
using IsKernel.ServiceClients.Bitbucket.Exceptions;
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
		
		public static ForkingPolicy FromString(string value)
		{
			var result = ForkingPolicy.NoForks;
			if(value == "allow_forks")
			{
				result = ForkingPolicy.AllowForks;
			}
			else if(value == "no_public_forks")
			{
				result = ForkingPolicy.NoPublicForks;
			}
			else if(value == "no_forks")
			{
				result = ForkingPolicy.NoForks;
			}
			else
			{
				throw new BitbucketException(value + " is an unknown value");
			}
			return result;
		}
	}
}
