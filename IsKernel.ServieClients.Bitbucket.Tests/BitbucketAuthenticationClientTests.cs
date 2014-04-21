using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;
using IsKernel.ServiceClients.Bitbucket.Clients.Concrete;
using NUnit.Framework;

namespace IsKernel.ServieClients.Bitbucket.Tests
{
	[TestFixture]
	public class BitbucketAuthenticationClientTests
	{
		private IBitbucketAuthenticationClient _client;
		private string _username;
		private string _password;
		private string _token;
		private string _tokenSecret;
		
		[SetUp]
		public void Setup()
		{
			var keys = File.ReadAllText("ApiKeys.txt")
					   .Split(Environment.NewLine.ToCharArray())
					   .Where(line => string.IsNullOrWhiteSpace(line) == false)
					   .ToArray();
			var apiKey = keys[0];
			var apiSecretKey = keys[1];
			_token = keys[2];
			_tokenSecret = keys[3];
			_username = keys[4];
			_password = keys[5];
			_client = new BitbucketAuthenticationClient(apiKey, apiSecretKey);
		}
		
		[Test]
		public void RequestTokenAsync_RequestAToken_AuthentificationUriReceived()
		{
			var uri = _client.RequestTokenAsync().Result;
			var uriString = uri.ToString();
			bool condition = (string.IsNullOrWhiteSpace(uriString) == false);
			Assert.IsTrue(condition);
		}
		
		[Test]
		public void AuthentificateAsync_AfterRequestToken_BitbucketClientCreated()
		{
			var uri = _client.RequestTokenAsync().Result;
			var uriString = uri.ToString();
			Process.Start(uriString);
			//Put breakpoint here to add verifier
			Console.WriteLine("Enter verifier: ");
			var verifier = Console.ReadLine();
			var client = _client.AuthentificateAsync(verifier).Result;
			Assert.IsNotNull(client);
		}
		
		[Test]
		public void AuthentificateWithLogin_ProvideUserNameAndPasword_BitbucketClientCreated()
		{
			var client = _client.AuthentificateWithLogin(_username, _password);
			Assert.IsNotNull(client);
		}
		
		[Test]
		public void AuthentificateWithAccessToken_TokenAndSecretTokenProvided_BitbucketClientCreated()
		{
			var client = _client.AuthentificateWithAccessToken(_token, _tokenSecret);
			Assert.IsNotNull(client);
		}
	}
}
