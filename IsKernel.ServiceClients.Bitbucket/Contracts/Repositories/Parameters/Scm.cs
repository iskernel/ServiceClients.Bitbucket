using System;
using IsKernel.ServiceClients.Bitbucket.Exceptions;
using IsKernel.ServiceClients.Bitbucket.Infrastructure;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Repositories.Parameters
{
	public class Scm : PrivateValueModel<string>
	{
		private Scm(string value) : base(value)
		{

		}
		
		public static readonly Scm Git = new Scm("git");
		public static readonly Scm Hg = new Scm("hg");
		
		public static Scm FromString(string value)
		{
			var result = Scm.Git;
			if(value == "git")
			{
				result = Scm.Git;
			}
			else if(value == "hg")
			{
				result = Scm.Hg;
			}
			else
			{
				throw new BitbucketException(value + " is an unknown value");
			}
			return result;
		}
	}
}
