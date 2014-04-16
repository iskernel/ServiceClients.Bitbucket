using System;
using IsKernel.ServiceClients.Bitbucket.Models.Common;

namespace IsKernel.ServiceClients.Bitbucket.Models.Repositories
{
	public class RepositoryAddOptionalParameters
	{
		private readonly RequestParameter<Scm> _scm;
		private readonly RequestParameter<string> _name;
		private readonly RequestParameter<string> _language;
		private readonly RequestParameter<bool?> _hasIssues;
		private readonly RequestParameter<bool?> _hasWiki;
		
		public RepositoryAddOptionalParameters(Scm scm = null, string name = null, string language = null,
											   bool? hasIssues = null, bool? hasWiki = null)
		{
			_scm = new RequestParameter<Scm>("scm", scm);
			_name = new RequestParameter<string>("name", name);
			_language = new RequestParameter<string>("language", language);
			_hasIssues = new RequestParameter<bool?>("has_issues", hasIssues);
			_hasWiki = new RequestParameter<bool?>("has_wiki", hasWiki);
		}
			
		public string Scm 
		{
			get 
			{
				return _scm.Value.Value;
			}
		}

		public string Name 
		{
			get 
			{
				return _name.Value;
			}
		}
			
		public string Language 
		{
			get 
			{
				return _name.Value;
			}
		}

		public bool? HasIssues 
		{
			get 
			{
				return _hasIssues.Value;
			}
		}

		public bool? HasWiki 
		{
			get 
			{
				return _hasWiki.Value;
			}
		}
	}
}
