using System;
using System.Collections.Generic;
using IsKernel.ServiceClients.Bitbucket.Infrastructure;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Commits.Parameters
{
	public class CommitGetOptionalParameters
	{
		private readonly MultiValueRequestParameter<string> _includes;
		private readonly MultiValueRequestParameter<string> _excludes;
		private readonly RequestParameter<string> _branchOrTag;
		
		public CommitGetOptionalParameters(string branchOrTag = "", 
										   List<string> includes = null, 
										   List<string> excludes = null)
		{
			if(branchOrTag == "")
			{
				_branchOrTag = null;
			}
			else
			{
				_branchOrTag = new RequestParameter<string>("branchOrTag", branchOrTag);
			}
			if(includes == null)
			{
				_includes = null;
			}
			else
			{
				_includes = new MultiValueRequestParameter<string>("include", includes);
			}
			if(excludes == null)
			{
				_excludes = null;
			}
			else
			{
				_excludes = new MultiValueRequestParameter<string>("exclude", excludes);
			}
		}
		
		public MultiValueRequestParameter<string> Includes {get; private set;}
		public MultiValueRequestParameter<string> Excludes {get; private set;}
		public RequestParameter<string> BranchOrTag {get;private set;}
		
	}
}
