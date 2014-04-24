using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using IsKernel.ServiceClients.Bitbucket.Contracts;
using IsKernel.ServiceClients.Bitbucket.Contracts.Requests;
using IsKernel.ServiceClients.Bitbucket.Exceptions;

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
		
		protected RestRequest AddPaginationParameters(RestRequest request, PaginatedRequest paginationRequest)
		{
			request.AddParameter(paginationRequest.PageLength.Name, paginationRequest.PageLength.Value);
			request.AddParameter(paginationRequest.Page.Name, paginationRequest.Page.Value);
			return request;
		}
		
		public Task<T> MakeAsyncRequest<T>(string resourceUrl, 
										   Method method,
										   List<Tuple<string, string>> urlSegments = null, 
										   List<Tuple<string, string>> parameters = null,
										   string exceptionMessage = "")
		{
			var taskCompletionSource = new TaskCompletionSource<T>();
			var request = new RestRequest(resourceUrl, method);
			if(urlSegments != null)
			{
				foreach (var element in urlSegments) 
				{
					request.AddUrlSegment(element.Item1, element.Item2);		
				}
			}
			if(parameters != null)
			{
				foreach (var element in parameters) 
				{
					request.AddParameter(element.Item1, element.Item2);
				}
			}
			_client.ExecuteAsync(request, response => {
				try 
				{
					System.Diagnostics.Debug.WriteLine(response.ResponseUri);
					System.Diagnostics.Debug.WriteLine(response.Content);
					var result = JsonConvert.DeserializeObject<T>(response.Content);
					taskCompletionSource.SetResult(result);
				} 
				catch (Exception exception)
				{
					var bitbucketException = new BitbucketException(exceptionMessage, exception);
					taskCompletionSource.SetException(bitbucketException);
				}
			});	
			return taskCompletionSource.Task;	
		}
		
		public Task<T> MakePostWithContentAsyncRequest<T>(string resourceUrl, 
										  			 	  BitbucketModel model,										   	
										   				  List<Tuple<string, string>> urlSegments = null, 
										   				  List<Tuple<string, string>> parameters = null,
														  string exceptionMessage = "") 
		{
			var taskCompletionSource = new TaskCompletionSource<T>();
			var request = new RestRequest(resourceUrl, Method.POST);
			if(urlSegments != null)
			{
				foreach (var element in urlSegments) 
				{
					request.AddUrlSegment(element.Item1, element.Item2);		
				}
			}
			if(parameters != null)
			{
				foreach (var element in parameters) 
				{
					request.AddParameter(element.Item1, element.Item2);
				}
			}
			request.RequestFormat = DataFormat.Json;
			request.AddBody(model.ToJson());
			_client.ExecuteAsync(request, response => {
				try
				{
					System.Diagnostics.Debug.WriteLine(response.ResponseUri);
					System.Diagnostics.Debug.WriteLine(response.Content);
					var result = JsonConvert.DeserializeObject<T>(response.Content);
					taskCompletionSource.SetResult(result);
				} 
				catch (Exception exception) {
					var bitbucketException = new BitbucketException(exceptionMessage, exception);
					taskCompletionSource.SetException(bitbucketException);
				}
			});	
			return taskCompletionSource.Task;	
		}
		
		public Task<T> MakePutWithContentAsyncRequest<T>(string resourceUrl, 
										  			 	 BitbucketModel model,										   	
										   				 List<Tuple<string, string>> urlSegments = null, 
										   				 List<Tuple<string, string>> parameters = null,
										   				 string exceptionMessage = "")
		{
			var taskCompletionSource = new TaskCompletionSource<T>();
			var request = new RestRequest(resourceUrl, Method.PUT);
			if(urlSegments != null)
			{
				foreach (var element in urlSegments) 
				{
					request.AddUrlSegment(element.Item1, element.Item2);		
				}
			}
			if(parameters != null)
			{
				foreach (var element in parameters) 
				{
					request.AddParameter(element.Item1, element.Item2);
				}
			}
			request.RequestFormat = DataFormat.Json;
			request.AddBody(model.ToJson());
			_client.ExecuteAsync(request, response => {
				try 
				{
					System.Diagnostics.Debug.WriteLine(response.ResponseUri);
					System.Diagnostics.Debug.WriteLine(response.Content);
					var result = JsonConvert.DeserializeObject<T>(response.Content);
					taskCompletionSource.SetResult(result);
				} 
				catch (Exception exception) {
					var bitbucketException = new BitbucketException(exceptionMessage, exception);
					taskCompletionSource.SetException(bitbucketException);
				}
			});	
			return taskCompletionSource.Task;	
		}
	}
}
