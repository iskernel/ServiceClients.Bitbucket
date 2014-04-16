using System;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Requests.Repositories;
using IsKernel.ServiceClients.Bitbucket.Exceptions;
using IsKernel.ServiceClients.Bitbucket.Models.Common;
using IsKernel.ServiceClients.Bitbucket.Models.Repositories;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Repositories.Requests
{
	public class RepositoryAddRequest : RepositoryBaseRequest
	{
		private readonly RequestParameter<bool> _isPrivate;
		private readonly RequestParameter<ForkingPolicy> _forkingPolicy;		
		public RepositoryAddOptionalParameters OptionalParameters {get; private set;}
		
		public RepositoryAddRequest(string owner, string repoSLug, bool isPrivate, ForkingPolicy forkingPolicy) 
			   : base(owner, repoSLug)
		{
			if(forkingPolicy == null)
			{
				throw new RequestParameterException("Forking policy cannot be null");
			}
			_isPrivate = new RequestParameter<bool>("is_private", isPrivate);
			_forkingPolicy = new RequestParameter<ForkingPolicy>("forking_policy", forkingPolicy);
			OptionalParameters = new RepositoryAddOptionalParameters();	
		}
		
		public RepositoryAddRequest(string owner, string repoSLug, bool isPrivate, ForkingPolicy forkingPolicy, 
									RepositoryAddOptionalParameters optionalParameters) 
			   : this(owner, repoSLug, isPrivate, forkingPolicy)
		{
			if(optionalParameters == null)
			{
				throw new RequestParameterException("Optional parameters should not be null. Call the other constructor.");
			}
			OptionalParameters = optionalParameters;
		}
		
		public RepositoryOptionalParameterJsonModel GenerateJsonModel()
		{
			var model = new RepositoryOptionalParameterJsonModel()
			{
				Scm = this.OptionalParameters.Scm,
				Name = this.OptionalParameters.Name,
				IsPrivate = this._isPrivate.Value,
				Language = this.OptionalParameters.Language,
				HasIssues = this.OptionalParameters.HasIssues,
				HasWiki = this.OptionalParameters.HasWiki
			};
			return model;
		}
	}
}
