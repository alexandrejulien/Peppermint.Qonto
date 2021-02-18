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
    public interface ILabelsApi
    {
        /// <summary>
        /// List labels Retrieve all labels within the organization.  - --  The response contains the list of labels that are linked to the authenticated company.  The &#x60;id&#x60; field uniquely identifies the label and is used to identify the **label_ids** of a transaction (see #endpoint:LSh2jq2tcFLCJ9wW3)  ### Parent  A label can be linked to another in order to create lists. The parent label can be identified thanks to the &#x60;parent_id&#x60; field. 
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="perPage"></param>
        /// <returns>Labels</returns>
        Labels GETLabels (int? currentPage, int? perPage);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class LabelsApi : ILabelsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LabelsApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public LabelsApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="LabelsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public LabelsApi(String basePath)
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
        /// List labels Retrieve all labels within the organization.  - --  The response contains the list of labels that are linked to the authenticated company.  The &#x60;id&#x60; field uniquely identifies the label and is used to identify the **label_ids** of a transaction (see #endpoint:LSh2jq2tcFLCJ9wW3)  ### Parent  A label can be linked to another in order to create lists. The parent label can be identified thanks to the &#x60;parent_id&#x60; field. 
        /// </summary>
        /// <param name="currentPage"></param> 
        /// <param name="perPage"></param> 
        /// <returns>Labels</returns>            
        public Labels GETLabels (int? currentPage, int? perPage)
        {
            
    
            var path = "/labels";
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
                throw new ApiException ((int)response.StatusCode, "Error calling GETLabels: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GETLabels: " + response.ErrorMessage, response.ErrorMessage);
    
            return (Labels) ApiClient.Deserialize(response.Content, typeof(Labels), response.Headers);
        }
    
    }
}
