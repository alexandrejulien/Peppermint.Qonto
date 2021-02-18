using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Models {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class OrganizationOrganization {
    /// <summary>
    /// Slug of the organization (e.g: acme-corp-1111)
    /// </summary>
    /// <value>Slug of the organization (e.g: acme-corp-1111)</value>
    [DataMember(Name="slug", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "slug")]
    public string Slug { get; set; }

    /// <summary>
    /// Gets or Sets BankAccounts
    /// </summary>
    [DataMember(Name="bank_accounts", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "bank_accounts")]
    public OrganizationOrganizationBankAccounts[] BankAccounts { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class OrganizationOrganization {\n");
      sb.Append("  Slug: ").Append(Slug).Append("\n");
      sb.Append("  BankAccounts: ").Append(BankAccounts).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
