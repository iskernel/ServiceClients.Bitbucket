using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using IsKernel.ServiceClients.Bitbucket.Contracts;
using IsKernel.ServiceClients.Bitbucket.Contracts.Requests;
using IsKernel.ServiceClients.Bitbucket.Exceptions;
using IsKernel.ServiceClients.Bitbucket.Infrastructure;
using IsKernel.ServiceClients.Bitbucket.Infrastructure.Rest;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Concrete
{
	public abstract class BitbucketClientBase
	{
		protected readonly RestClient _client;
		
		protected BitbucketClientBase(IAuthenticator authentificator, string clientBaseUrl = "")
		{
			_client = new RestClient(clientBaseUrl);
			_client.Authenticator = authentificator;
		}		
		
		private RestRequest CreateRequest(string resourceUrl, RestComplexRequest request)
		{
			var restRequest = new RestRequest(resourceUrl, request.Method);
			if(request.UrlSegments != null)
			{
				foreach (var element in request.UrlSegments) 
				{
					restRequest.AddUrlSegment(element.Key, element.Value);		
				}
			}
			if(request.Parameters != null)
			{
				foreach (var element in request.Parameters) 
				{
					restRequest.AddParameter(element.Key, element.Value);
				}
			}
			if(request.ExtraHeaders != null)
			{
				foreach (var element in request.ExtraHeaders) 
				{
					restRequest.AddHeader(element.Key, element.Value);
				}
			}
			
			if(request.GetType() == typeof(RestComplexDataRequest))
			{
				var dataRequest = (request as RestComplexDataRequest);
				if(dataRequest != null)
				{
					if(dataRequest.ContentType != null)
					{
						if(dataRequest.ContentType == RestDataContentType.Json)
						{
							restRequest.RequestFormat = DataFormat.Json;
							restRequest.JsonSerializer = new JsonCustomSerializer();
							restRequest.AddBody(dataRequest.Content);
						}
						else if(dataRequest.ContentType == RestDataContentType.Xml)
						{
							restRequest.RequestFormat = DataFormat.Xml;
							restRequest.AddBody(dataRequest.Content);
						}
						else if(dataRequest.ContentType == RestDataContentType.UrlEncode)
						{
							var content = (dataRequest.Content as Dictionary<string, string>);
							restRequest.RequestFormat = DataFormat.Json;
							foreach (var element in content)
							{
								restRequest.AddParameter(element.Key, element.Value, ParameterType.GetOrPost);
							}							
							restRequest.AddBody(dataRequest.Content);
						}
					}
					
				}
			}
			return restRequest;
		}
		
		private string CreateExceptionMessage(IRestResponse response)
		{
			string responseString = response.ResponseUri + Environment.NewLine 
									+ " " + response.ResponseStatus.ToString() + Environment.NewLine
									+ " " + response.Content + Environment.NewLine;
			return responseString;
		}
		
		private void MakeRequestCallAsync<T>(TaskCompletionSource<T> taskCompletionSource, RestRequest request)
		{					
 			_client.ExecuteAsync(request, response => {
				try 
				{									
					System.Diagnostics.Debug.WriteLine(response.ResponseUri);
					System.Diagnostics.Debug.WriteLine(response.Content);
					if(typeof(T) != typeof(string))
					{ 
						var result = JsonConvert.DeserializeObject<T>(response.Content);
						taskCompletionSource.SetResult(result);
					}
					else
					{
						var result = response.Content;
						taskCompletionSource.SetResult((dynamic)(result));
					}
				} 
				catch (Exception exception)
				{
					var exceptionMessage = CreateExceptionMessage(response);
					var bitbucketException = new BitbucketException(exceptionMessage, exception);
					taskCompletionSource.SetException(bitbucketException);
				}
			});	
		}
		
		protected Dictionary<string,string> CreateDefaultPaginationParameters(PaginatedRequest request)
		{
			var dictionary = new Dictionary<string,string>();
			dictionary.Add(request.Page.Name, request.Page.Value.ToString());
			dictionary.Add(request.PageLength.Name, request.PageLength.Value.ToString());
			return dictionary;
		}
		
		protected Task<T> MakeAsyncRequest<T>(string resourceUrl, RestComplexRequest request)
		{
			var taskCompletionSource = new TaskCompletionSource<T>();
			var restRequest = CreateRequest(resourceUrl, request);
			MakeRequestCallAsync(taskCompletionSource, restRequest);
			return taskCompletionSource.Task;
		}		

		protected Task<T> MakeAsyncRequest<T>(string resourceUrl, RestComplexRequest request, Dictionary<string,string> files)
		{
			var taskCompletionSource = new TaskCompletionSource<T>();
			var restRequest = CreateRequest(resourceUrl, request);
			foreach (var element in files) 
			{
				restRequest.AddFile(element.Key, element.Value);	
			}
			MakeRequestCallAsync(taskCompletionSource, restRequest);
			return taskCompletionSource.Task;
		}	
	}
}
