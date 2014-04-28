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