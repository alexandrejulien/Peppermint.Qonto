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
    public interface IOrganizationsApi
    {
        /// <summary>
        /// Show organization Retrieve the list and details of a company&#39;s bank accounts.  - --  The response contains the list of bank accounts of the authenticated company. There can currently only be one bank account per company.   The &#x60;balance&#x60; represents the actual amount of money on the account, in Euros. The &#x60;authorized_balance&#x60; represents the amount available for payments, taking into account transactions that are being processed. [More information here](https://support.qonto.eu/hc/en-us/articles/115000493249-How-is-the-balance-of-my-account-calculated-)  The bank account&#39;s &#x60;slug&#x60; and &#x60;iban&#x60; will be required for you to retrieve the list of transactions inside that bank account, using  #endpoint:LSh2jq2tcFLCJ9wW3. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Organization</returns>
        Organization GETOrganizationsId (string id);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class OrganizationsApi : IOrganizationsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationsApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public OrganizationsApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public OrganizationsApi(String basePath)
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
        /// Show organization Retrieve the list and details of a company&#39;s bank accounts.  - --  The response contains the list of bank accounts of the authenticated company. There can currently only be one bank account per company.   The &#x60;balance&#x60; represents the actual amount of money on the account, in Euros. The &#x60;authorized_balance&#x60; represents the amount available for payments, taking into account transactions that are being processed. [More information here](https://support.qonto.eu/hc/en-us/articles/115000493249-How-is-the-balance-of-my-account-calculated-)  The bank account&#39;s &#x60;slug&#x60; and &#x60;iban&#x60; will be required for you to retrieve the list of transactions inside that bank account, using  #endpoint:LSh2jq2tcFLCJ9wW3. 
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>Organization</returns>            
        public Organization GETOrganizationsId (string id)
        {
            
            // verify the required parameter 'id' is set
            if (id == null) throw new ApiException(400, "Missing required parameter 'id' when calling GETOrganizationsId");
            
    
            var path = "/organizations/{id}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "id" + "}", ApiClient.ParameterToString(id));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                    
            // authentication setting, if any
            String[] authSettings = new String[] { "Authorization" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GETOrganizationsId: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GETOrganizationsId: " + response.ErrorMessage, response.ErrorMessage);
    
            return (Organization) ApiClient.Deserialize(response.Content, typeof(Organization), response.Headers);
        }
    
    }
}
