using System;
using System.Collections.Generic;
using RestSharp;
using Client;
using Models;

namespace Apis
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IMembershipsApi
    {
        /// <summary>
        /// List memberships Retrieve all memberships within the organization.  - --  The response contains the list of memberships that are linked to the authenticated company. A membership is a user who&#39;s been granted access to the Qonto account of a company. There is no limit currently to the number of memberships a company can have.  The &#x60;id&#x60; field uniquely identifies the membership and is used to identify the **initiator** of a transaction (see #endpoint:LSh2jq2tcFLCJ9wW3) 
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="perPage"></param>
        /// <returns>Memberships</returns>
        Memberships GETMemberships (int? currentPage, int? perPage);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class MembershipsApi : IMembershipsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MembershipsApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public MembershipsApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="MembershipsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public MembershipsApi(String basePath)
        {
            this.ApiClient = new ApiClient(basePath);
        }
    
        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }
    
        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public String GetBasePath(String basePath)
        {
            return this.ApiClient.BasePath;
        }
    
        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient {get; set;}
    
        /// <summary>
        /// List memberships Retrieve all memberships within the organization.  - --  The response contains the list of memberships that are linked to the authenticated company. A membership is a user who&#39;s been granted access to the Qonto account of a company. There is no limit currently to the number of memberships a company can have.  The &#x60;id&#x60; field uniquely identifies the membership and is used to identify the **initiator** of a transaction (see #endpoint:LSh2jq2tcFLCJ9wW3) 
        /// </summary>
        /// <param name="currentPage"></param> 
        /// <param name="perPage"></param> 
        /// <returns>Memberships</returns>            
        public Memberships GETMemberships (int? currentPage, int? perPage)
        {
            
    
            var path = "/memberships";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (currentPage != null) queryParams.Add("current_page", ApiClient.ParameterToString(currentPage)); // query parameter
 if (perPage != null) queryParams.Add("per_page", ApiClient.ParameterToString(perPage)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] { "Authorization" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GETMemberships: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GETMemberships: " + response.ErrorMessage, response.ErrorMessage);
    
            return (Memberships) ApiClient.Deserialize(response.Content, typeof(Memberships), response.Headers);
        }
    
    }
}
