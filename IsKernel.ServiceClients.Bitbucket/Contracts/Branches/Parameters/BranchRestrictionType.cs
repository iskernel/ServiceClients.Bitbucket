using System;
using IsKernel.ServiceClients.Bitbucket.Infrastructure;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Branches.Parameters
{
	public class BranchRestrictionType : ClassEnumBase<string>
	{
		private BranchRestrictionType(string value) : base(value)
		{
		}
		
		public static BranchRestrictionType Push = new BranchRestrictionType("push");
		public static BranchRestrictionType Delete = new BranchRestrictionType("delete");
		public static BranchRestrictionType Force = new BranchRestrictionType("force");
	}
}
