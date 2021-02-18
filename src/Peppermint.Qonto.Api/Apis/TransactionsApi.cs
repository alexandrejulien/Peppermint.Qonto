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
    public interface ITransactionsApi
    {
        /// <summary>
        /// List transactions Retrieve all transactions within a particular bank account.  - --  The response contains the list of transactions that contributed to the bank account&#39;s balances (e.g., incomes, transfers, cards). All transactions visible in Qonto&#39;s UI can be fetched, as of API V2.  ## Attributes details  ##### Amount  * The &#x60;amount&#x60;, &#x60;amount_cents&#x60; and &#x60;currency&#x60; correspond to the amount of the transaction in the currency of the bank account (in our case, it will be in **euros** as it is our only supported bank account currency). * The &#x60;local_amount&#x60;, &#x60;local_amount_cents&#x60; and &#x60;local_currency&#x60; correspond to the amount of the transaction in the **foreign currency** (if any)   * e.g, for a transaction of 10.00 USD, &#x60;local_amount_cents&#x60; takes a &#x60;1000&#x60;value, and &#x60;local_currency&#x60;takes on a &#x60;USD&#x60; value   ##### VAT  * The &#x60;vat_amount&#x60; and &#x60;vat_amount_cents&#x60; contain the amount of VAT. * The &#x60;vat_rate&#x60; refers to the rate selected or detected. The value can be &#x60;-1&#x60; for uncategorized rate (e.g in France any value which is not in &#x60;0, 2.1, 5.5, 10, 20&#x60;) or multiple rates transaction because we do not support them yet.   * e.g, for a transaction of 10.00 EUR with 10% VAT, &#x60;vat_amount_cents&#x60; takes a &#x60;91&#x60; value, and &#x60;vat_rate&#x60; takes a &#x60;10&#x60; value  **Do note:** If you&#39;re a user of VAT auto-detection feature, only confirmed VAT information will appear in the response.   ##### Side  - &#x60;credit&#x60;: incoming transaction - &#x60;debit&#x60;: outgoing transaction  #### Timestamps  Each transaction contains three timestamps:  * &#x60;emitted_at&#x60;, the time at which the transaction was first recorded * &#x60;settled_at&#x60;, the time at which the transaction impacted the &#x60;balance&#x60; and got set to a &#x60;completed&#x60; status * &#x60;updated_at&#x60;, the time at which the transaction was last updated  **Do note**: *The &#x60;settled_at&#x60; value can be &#x60;null&#x60;, for transaction which aren&#39;t &#x60;completed&#x60; (&#x60;pending&#x60;, &#x60;reversed&#x60; and  &#x60;declined&#x60;)*  ##### Operation type  - &#x60;income&#x60;: an incoming transfer - &#x60;transfer&#x60;: an outgoing transfer - &#x60;card&#x60;: a card payment - &#x60;direct_debit&#x60;: a SEPA Direct Debit (collecting payments from other businesses) - &#x60;qonto_fee&#x60;: a Qonto fee (subscription, atm withdrawal, fx card...) - &#x60;cheque&#x60;: a Check cashed in on the account  #### Attachments  - &#x60;attachment_ids&#x60; contains an array of UUIDs, corresponding to the attachments (up to 5) uploaded on the transaction. You can obtain details for each attachment using #endpoint:LqaS4zJLgJXdCA6kP.  - &#x60;attachment_lost&#x60; contains a boolean describing whether the attachment of the transaction was marked as lost or not.  - &#x60;attachment_required&#x60; contains a boolean describing whether the attachment of the transaction was marked as required or not.  ## Filters  #### &#x60;status&#x60;  Transactions can be filtered by status. The &#x60;status&#x60; query parameter accepts an array of statuses as value. Here is what statuses correspond to:  - &#x60;pending&#x60;: a transaction that is processing and has impacted the bank account&#39;s &#x60;auth_balance&#x60; but not its &#x60;balance&#x60; - &#x60;reversed&#x60;: a transaction that used to be processing, but has then been reversed - &#x60;declined&#x60;: a transaction that has been declined - &#x60;completed&#x60;: a transaction that is completed, and has impacted the bank account&#39;s &#x60;balance&#x60;  For example, if you want to retrieve all transaction statuses, you can use the following filter: &#x60;status[]&#x3D;completed&amp;status[]&#x3D;declined&amp;status[]&#x3D;reversed&amp;status[]&#x3D;pending&#x60;   **Do note**: *If no &#x60;status&#x60; is specified, the API will only return &#x60;completed&#x60; transactions by default, as they are the only ones that usually make sense in an accounting integration.*  #### &#x60;updated_at&#x60; / &#x60;settled_at&#x60;  Transactions can be filtered according to both &#x60;updated_at&#x60; and &#x60;settled_at&#x60; fields. This is particularly useful to retrieve only the latest transactions in your application. Two filters are available :  - **updated_at**   - &#x60;updated_at_from&#x60;: Minimum value (e.g: &#x60;2019-01-10T11:47:53.123Z&#x60;)   - &#x60;updated_at_to&#x60;: Maximum value - **settled_at**   - &#x60;settled_at_from&#x60;: Minimum value   - &#x60;settled_at_to&#x60;: Maximum value  **Do note**:  - *You can use one or the other &#x60;updated_at&#x60; filter (same for &#x60;settled_at&#x60;), or use them in combination if you want transactions updated within a specific timeframe.* - *&#x60;updated_at&#x60; / &#x60;settled_at&#x60; filters should have a valid date time format (**ISO 8601** for instance)*  ## Sorting  Transactions can be sorted by a specific field and order. The &#x60;sort_by&#x60; query parameter accepts a string defining these two items with the &#x60;field:order&#x60; format.  #### Field  - Both &#x60;updated_at&#x60; and &#x60;settled_at&#x60; values are available. - By default the field used to sort transactions is &#x60;settled_at&#x60;  #### Order  - Two values are available : &#x60;asc&#x60; (Ascending) / &#x60;desc&#x60; (Descending) - By default the order used to sort transactions is &#x60;desc&#x60;  **Do note**: You can use a combination of field and order to define how to sort transactions : - Only field (e.g &#x60;updated_at&#x60;, order will have default value &#x60;desc&#x60;) - Only order (e.g &#x60;:asc&#x60;, field will have default value &#x60;settled_at&#x60;) - Both (e.g &#x60;updated_at:asc&#x60;) 
        /// </summary>
        /// <param name="slug"></param>
        /// <param name="iban"></param>
        /// <param name="status"></param>
        /// <param name="updatedAtFrom"></param>
        /// <param name="updatedAtTo"></param>
        /// <param name="settledAtFrom"></param>
        /// <param name="settledAtTo"></param>
        /// <param name="sortBy"></param>
        /// <param name="currentPage"></param>
        /// <param name="perPage"></param>
        /// <returns>Transactions</returns>
        Transactions GETTransactions (string slug, string iban, List<string> status, string updatedAtFrom, string updatedAtTo, string settledAtFrom, string settledAtTo, string sortBy, int? currentPage, int? perPage);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class TransactionsApi : ITransactionsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionsApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public TransactionsApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public TransactionsApi(String basePath)
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
        /// List transactions Retrieve all transactions within a particular bank account.  - --  The response contains the list of transactions that contributed to the bank account&#39;s balances (e.g., incomes, transfers, cards). All transactions visible in Qonto&#39;s UI can be fetched, as of API V2.  ## Attributes details  ##### Amount  * The &#x60;amount&#x60;, &#x60;amount_cents&#x60; and &#x60;currency&#x60; correspond to the amount of the transaction in the currency of the bank account (in our case, it will be in **euros** as it is our only supported bank account currency). * The &#x60;local_amount&#x60;, &#x60;local_amount_cents&#x60; and &#x60;local_currency&#x60; correspond to the amount of the transaction in the **foreign currency** (if any)   * e.g, for a transaction of 10.00 USD, &#x60;local_amount_cents&#x60; takes a &#x60;1000&#x60;value, and &#x60;local_currency&#x60;takes on a &#x60;USD&#x60; value   ##### VAT  * The &#x60;vat_amount&#x60; and &#x60;vat_amount_cents&#x60; contain the amount of VAT. * The &#x60;vat_rate&#x60; refers to the rate selected or detected. The value can be &#x60;-1&#x60; for uncategorized rate (e.g in France any value which is not in &#x60;0, 2.1, 5.5, 10, 20&#x60;) or multiple rates transaction because we do not support them yet.   * e.g, for a transaction of 10.00 EUR with 10% VAT, &#x60;vat_amount_cents&#x60; takes a &#x60;91&#x60; value, and &#x60;vat_rate&#x60; takes a &#x60;10&#x60; value  **Do note:** If you&#39;re a user of VAT auto-detection feature, only confirmed VAT information will appear in the response.   ##### Side  - &#x60;credit&#x60;: incoming transaction - &#x60;debit&#x60;: outgoing transaction  #### Timestamps  Each transaction contains three timestamps:  * &#x60;emitted_at&#x60;, the time at which the transaction was first recorded * &#x60;settled_at&#x60;, the time at which the transaction impacted the &#x60;balance&#x60; and got set to a &#x60;completed&#x60; status * &#x60;updated_at&#x60;, the time at which the transaction was last updated  **Do note**: *The &#x60;settled_at&#x60; value can be &#x60;null&#x60;, for transaction which aren&#39;t &#x60;completed&#x60; (&#x60;pending&#x60;, &#x60;reversed&#x60; and  &#x60;declined&#x60;)*  ##### Operation type  - &#x60;income&#x60;: an incoming transfer - &#x60;transfer&#x60;: an outgoing transfer - &#x60;card&#x60;: a card payment - &#x60;direct_debit&#x60;: a SEPA Direct Debit (collecting payments from other businesses) - &#x60;qonto_fee&#x60;: a Qonto fee (subscription, atm withdrawal, fx card...) - &#x60;cheque&#x60;: a Check cashed in on the account  #### Attachments  - &#x60;attachment_ids&#x60; contains an array of UUIDs, corresponding to the attachments (up to 5) uploaded on the transaction. You can obtain details for each attachment using #endpoint:LqaS4zJLgJXdCA6kP.  - &#x60;attachment_lost&#x60; contains a boolean describing whether the attachment of the transaction was marked as lost or not.  - &#x60;attachment_required&#x60; contains a boolean describing whether the attachment of the transaction was marked as required or not.  ## Filters  #### &#x60;status&#x60;  Transactions can be filtered by status. The &#x60;status&#x60; query parameter accepts an array of statuses as value. Here is what statuses correspond to:  - &#x60;pending&#x60;: a transaction that is processing and has impacted the bank account&#39;s &#x60;auth_balance&#x60; but not its &#x60;balance&#x60; - &#x60;reversed&#x60;: a transaction that used to be processing, but has then been reversed - &#x60;declined&#x60;: a transaction that has been declined - &#x60;completed&#x60;: a transaction that is completed, and has impacted the bank account&#39;s &#x60;balance&#x60;  For example, if you want to retrieve all transaction statuses, you can use the following filter: &#x60;status[]&#x3D;completed&amp;status[]&#x3D;declined&amp;status[]&#x3D;reversed&amp;status[]&#x3D;pending&#x60;   **Do note**: *If no &#x60;status&#x60; is specified, the API will only return &#x60;completed&#x60; transactions by default, as they are the only ones that usually make sense in an accounting integration.*  #### &#x60;updated_at&#x60; / &#x60;settled_at&#x60;  Transactions can be filtered according to both &#x60;updated_at&#x60; and &#x60;settled_at&#x60; fields. This is particularly useful to retrieve only the latest transactions in your application. Two filters are available :  - **updated_at**   - &#x60;updated_at_from&#x60;: Minimum value (e.g: &#x60;2019-01-10T11:47:53.123Z&#x60;)   - &#x60;updated_at_to&#x60;: Maximum value - **settled_at**   - &#x60;settled_at_from&#x60;: Minimum value   - &#x60;settled_at_to&#x60;: Maximum value  **Do note**:  - *You can use one or the other &#x60;updated_at&#x60; filter (same for &#x60;settled_at&#x60;), or use them in combination if you want transactions updated within a specific timeframe.* - *&#x60;updated_at&#x60; / &#x60;settled_at&#x60; filters should have a valid date time format (**ISO 8601** for instance)*  ## Sorting  Transactions can be sorted by a specific field and order. The &#x60;sort_by&#x60; query parameter accepts a string defining these two items with the &#x60;field:order&#x60; format.  #### Field  - Both &#x60;updated_at&#x60; and &#x60;settled_at&#x60; values are available. - By default the field used to sort transactions is &#x60;settled_at&#x60;  #### Order  - Two values are available : &#x60;asc&#x60; (Ascending) / &#x60;desc&#x60; (Descending) - By default the order used to sort transactions is &#x60;desc&#x60;  **Do note**: You can use a combination of field and order to define how to sort transactions : - Only field (e.g &#x60;updated_at&#x60;, order will have default value &#x60;desc&#x60;) - Only order (e.g &#x60;:asc&#x60;, field will have default value &#x60;settled_at&#x60;) - Both (e.g &#x60;updated_at:asc&#x60;) 
        /// </summary>
        /// <param name="slug"></param> 
        /// <param name="iban"></param> 
        /// <param name="status"></param> 
        /// <param name="updatedAtFrom"></param> 
        /// <param name="updatedAtTo"></param> 
        /// <param name="settledAtFrom"></param> 
        /// <param name="settledAtTo"></param> 
        /// <param name="sortBy"></param> 
        /// <param name="currentPage"></param> 
        /// <param name="perPage"></param> 
        /// <returns>Transactions</returns>            
        public Transactions GETTransactions (string slug, string iban, List<string> status, string updatedAtFrom, string updatedAtTo, string settledAtFrom, string settledAtTo, string sortBy, int? currentPage, int? perPage)
        {
            
            // verify the required parameter 'slug' is set
            if (slug == null) throw new ApiException(400, "Missing required parameter 'slug' when calling GETTransactions");
            
            // verify the required parameter 'iban' is set
            if (iban == null) throw new ApiException(400, "Missing required parameter 'iban' when calling GETTransactions");
            
    
            var path = "/transactions";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (slug != null) queryParams.Add("slug", ApiClient.ParameterToString(slug)); // query parameter
 if (iban != null) queryParams.Add("iban", ApiClient.ParameterToString(iban)); // query parameter
 if (status != null) queryParams.Add("status", ApiClient.ParameterToString(status)); // query parameter
 if (updatedAtFrom != null) queryParams.Add("updated_at_from", ApiClient.ParameterToString(updatedAtFrom)); // query parameter
 if (updatedAtTo != null) queryParams.Add("updated_at_to", ApiClient.ParameterToString(updatedAtTo)); // query parameter
 if (settledAtFrom != null) queryParams.Add("settled_at_from", ApiClient.ParameterToString(settledAtFrom)); // query parameter
 if (settledAtTo != null) queryParams.Add("settled_at_to", ApiClient.ParameterToString(settledAtTo)); // query parameter
 if (sortBy != null) queryParams.Add("sort_by", ApiClient.ParameterToString(sortBy)); // query parameter
 if (currentPage != null) queryParams.Add("current_page", ApiClient.ParameterToString(currentPage)); // query parameter
 if (perPage != null) queryParams.Add("per_page", ApiClient.ParameterToString(perPage)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] { "Authorization" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GETTransactions: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GETTransactions: " + response.ErrorMessage, response.ErrorMessage);
    
            return (Transactions) ApiClient.Deserialize(response.Content, typeof(Transactions), response.Headers);
        }
    
    }
}
