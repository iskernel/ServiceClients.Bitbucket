ServiceClients.Bitbucket
========================

C# service client for the Bitbucket v2.0 API. 

See the reference at  [https://confluence.atlassian.com/display/BITBUCKET/Version+2](https://confluence.atlassian.com/display/BITBUCKET/Version+2 "Bitbucket API documentation.")

Curently the API is covering the **repository**, **pull requests**, **commit**, **branch restriction**, **diff**, **teams** and **user** resources.

In case of API changes or if you find a bug, create an issue.

*If you like this library and want to improve it, contributions are always welcomed.* 

Usage
-

```csharp
using System;
using System.Collections.Generic;
using System.Diagnostics;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;
using IsKernel.ServiceClients.Bitbucket.Clients.Concrete;
using IsKernel.ServiceClients.Bitbucket.Contracts.Repositories;
using IsKernel.ServiceClients.Bitbucket.Contracts.Requests;
using IsKernel.ServiceClients.Bitbucket.Contracts.Responses;
using IsKernel.ServiceClients.Bitbucket.Contracts.Users;

namespace IsKernel.ServiceClients.Bitbucket.ConsoleExample
{
	public class Program
	{
		private const string API_KEY = "your api key";
		private const string API_KEY_SECRET = "your secret api key";
		
		public static IBitbucketClient AuthenticateWithUserPassword(IBitbucketAuthenticationClient authClient)
		{
			Console.WriteLine("User : ");
			var user = Console.ReadLine();
			Console.WriteLine("Password : ");
			var password = Console.ReadLine();
			IBitbucketClient client = authClient.AuthentificateWithLogin(user, password);
			return client;
		}
		
		public static IBitbucketClient AuthenticateWithOauth(IBitbucketAuthenticationClient authClient)
		{
			Uri uri = authClient.RequestTokenAsync().Result;
			var uriString = uri.ToString();
			Process.Start(uriString);
			Console.WriteLine("Enter verifier: ");
			var verifier = Console.ReadLine();
			IBitbucketClient client = authClient.AuthentificateAsync(verifier).Result;
			return client;
		}
		
		public static void Main(string[] args)
		{
			IBitbucketAuthenticationClient authClient = new BitbucketAuthenticationClient(API_KEY, API_KEY_SECRET);
			IBitbucketClient client = AuthenticateWithOauth(authClient);
			
			Console.WriteLine("Bitbucket username: ");
			var username = Console.ReadLine();
			
			//Show profile
			User user = client.UserClient.GetProfileAsync(username).Result;
			Console.WriteLine("The user {0} created his profile on {1}", user.Username, user.CreatedOn); 
			
			//Show repositories
			PaginatedRequest request = new PaginatedRequest(10, 1);
			var repositories = new List<Repository>();
			
			PaginatedResponse<Repository> response 
							= client.RepositoryClient.GetAllAsync(username, request).Result;
			repositories.AddRange(response.Values);
			while(response.NextPageUrl != null)
			{
				request.Page.Value++;
				response = client.RepositoryClient.GetAllAsync(username, request).Result;
				repositories.AddRange(response.Values);
			}
			Console.WriteLine("He has {0} repositories : ", response.Total);
			foreach (var element in repositories) 
			{
				Console.WriteLine(element.Name + " " + element.Language + " " + element.CreatedOn);
			}
			
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}
```

Status:
-

- **Authentification** : Done, tested
- **Repository resource** : Done, tested
- **Pull requests resource** : Done, tested
- **Commit resource** : Done, tested
- **Branch-restrictions resource** : Done, tested
- **Diff resource** : Done, tested
- **Teams resource** : Done, tested
- **Users resource** : Done, tested

Version
-

1.0

License
-

MIT
