using System;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;
using NUnit.Framework;
using IsKernel.ServieClients.Bitbucket.Tests.TestHelpers;

namespace IsKernel.ServieClients.Bitbucket.Tests.Clients
{
	
	[TestFixture]
	public class BitbucketDiffClientTests : BitbucketClientTestsBase
	{
		private IBitbucketDiffClient _client;
		
		[SetUp]
		public override void Setup()
		{
			base.Setup();
			_client = _mainClient.DiffClient;
		}
		
		[TearDown]
		public void TearDown()
		{
			
		}
		
		[Test]
		public void GetDiffAsync_GetDiff_DiffIsRetrieved()
		{
			var diff = _client.GetDiffAsync(_defaultUser, _defaultRepository, "default").Result;
			Assert.IsNotNullOrEmpty(diff);
		}
		
		[Test]
		public void GetPatchAsync_GetPatch_PatchIsRetrieved()
		{
			var diff = _client.GetPatchAsync(_defaultUser, _defaultRepository, "default").Result;
			Assert.IsNotNullOrEmpty(diff);
		}
		
		
	}
}
