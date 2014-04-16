using System;
using IsKernel.ServiceClients.Bitbucket.Models.Common;

namespace IsKernel.ServiceClients.Bitbucket.Models.Repositories
{
	public class Scm : PrivateValueModel<string>
	{
		private Scm(string value) : base(value)
		{

		}
		
		public static readonly Scm Git = new Scm("git");
		public static readonly Scm Hg = new Scm("hg");
	}
}
