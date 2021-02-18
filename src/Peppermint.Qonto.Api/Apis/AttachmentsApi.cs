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
    public interface IAttachmentsApi
    {
        /// <summary>
        /// Show attachment Obtain the details (e.g: download URL) for a specific attachment.   - --  Inside Qonto, attachments are files uploaded onto transactions by users. Attachments typically correspond to the *invoice* or *receipt*, and are used to justify the transactions from a bookkeeping standpoint.   You can retrieve the IDs of those attachments inside each Transaction object, by calling #endpoint:LSh2jq2tcFLCJ9wW3.   An attachment object is returned as follows:  &#x60;&#x60;&#x60;json {     \&quot;attachment\&quot;: {         \&quot;id\&quot;: \&quot;1ec373a5-e30d-4a70-948d-c8d49e4a4d31\&quot;,         \&quot;created_at\&quot;: \&quot;2019-01-07T16:36:25.862Z\&quot;,         \&quot;file_name\&quot;: \&quot;doc.pdf\&quot;,         \&quot;file_size\&quot;: \&quot;49599\&quot;,         \&quot;file_content_type\&quot;: \&quot;application/pdf\&quot;,         \&quot;url\&quot;: \&quot;https://qonto-dev.s3.eu-central-1.amazonaws.com/production/uploads/attachment/1ec373a5-e30d-4a70-948d-c8d49e4a4d31/5ff8b9fa-4161-4904-ae93-ebc9e34d1614.pdf?response-content-disposition&#x3D;attachment%3Bfilename%2A%3DUTF-8%27%27doc.pdf&amp;response-content-type&#x3D;application%2Fpdf&amp;X-Amz-Algorithm&#x3D;AWS4-HMAC-SHA256&amp;X-Amz-Credential&#x3D;AKIAIWLF7G5ORP46XMEA%2F20190108%2Feu-central-1%2Fs3%2Faws4_request&amp;X-Amz-Date&#x3D;20190108T145400Z&amp;X-Amz-Expires&#x3D;1800&amp;X-Amz-SignedHeaders&#x3D;host&amp;X-Amz-Signature&#x3D;7cb89f5363fb5eef8299d03a6602b08843c41aebbe24bffca96b6d11741ccde3\&quot;     } } &#x60;&#x60;&#x60;  **Important**: for security reasons, the &#x60;url&#x60; you retrieve for each Attachment is only valid for 30 minutes. If you need to download the file after more than 30 minutes, you will need to perform another authenticated call in order to generate a new download URL.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Attachment</returns>
        Attachment GETAttachmentsId (string id);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class AttachmentsApi : IAttachmentsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentsApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public AttachmentsApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AttachmentsApi(String basePath)
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
        /// Show attachment Obtain the details (e.g: download URL) for a specific attachment.   - --  Inside Qonto, attachments are files uploaded onto transactions by users. Attachments typically correspond to the *invoice* or *receipt*, and are used to justify the transactions from a bookkeeping standpoint.   You can retrieve the IDs of those attachments inside each Transaction object, by calling #endpoint:LSh2jq2tcFLCJ9wW3.   An attachment object is returned as follows:  &#x60;&#x60;&#x60;json {     \&quot;attachment\&quot;: {         \&quot;id\&quot;: \&quot;1ec373a5-e30d-4a70-948d-c8d49e4a4d31\&quot;,         \&quot;created_at\&quot;: \&quot;2019-01-07T16:36:25.862Z\&quot;,         \&quot;file_name\&quot;: \&quot;doc.pdf\&quot;,         \&quot;file_size\&quot;: \&quot;49599\&quot;,         \&quot;file_content_type\&quot;: \&quot;application/pdf\&quot;,         \&quot;url\&quot;: \&quot;https://qonto-dev.s3.eu-central-1.amazonaws.com/production/uploads/attachment/1ec373a5-e30d-4a70-948d-c8d49e4a4d31/5ff8b9fa-4161-4904-ae93-ebc9e34d1614.pdf?response-content-disposition&#x3D;attachment%3Bfilename%2A%3DUTF-8%27%27doc.pdf&amp;response-content-type&#x3D;application%2Fpdf&amp;X-Amz-Algorithm&#x3D;AWS4-HMAC-SHA256&amp;X-Amz-Credential&#x3D;AKIAIWLF7G5ORP46XMEA%2F20190108%2Feu-central-1%2Fs3%2Faws4_request&amp;X-Amz-Date&#x3D;20190108T145400Z&amp;X-Amz-Expires&#x3D;1800&amp;X-Amz-SignedHeaders&#x3D;host&amp;X-Amz-Signature&#x3D;7cb89f5363fb5eef8299d03a6602b08843c41aebbe24bffca96b6d11741ccde3\&quot;     } } &#x60;&#x60;&#x60;  **Important**: for security reasons, the &#x60;url&#x60; you retrieve for each Attachment is only valid for 30 minutes. If you need to download the file after more than 30 minutes, you will need to perform another authenticated call in order to generate a new download URL.
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>Attachment</returns>            
        public Attachment GETAttachmentsId (string id)
        {
            
            // verify the required parameter 'id' is set
            if (id == null) throw new ApiException(400, "Missing required parameter 'id' when calling GETAttachmentsId");
            
    
            var path = "/attachments/{id}";
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
                throw new ApiException ((int)response.StatusCode, "Error calling GETAttachmentsId: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GETAttachmentsId: " + response.ErrorMessage, response.ErrorMessage);
    
            return (Attachment) ApiClient.Deserialize(response.Content, typeof(Attachment), response.Headers);
        }
    
    }
}
