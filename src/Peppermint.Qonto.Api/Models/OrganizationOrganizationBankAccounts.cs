using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Models {

  /// <summary>
  /// List of the bank accounts
  /// </summary>
  [DataContract]
  public class OrganizationOrganizationBankAccounts {
    /// <summary>
    /// Slug of the bank account
    /// </summary>
    /// <value>Slug of the bank account</value>
    [DataMember(Name="slug", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "slug")]
    public string Slug { get; set; }

    /// <summary>
    /// IBAN of the bank account
    /// </summary>
    /// <value>IBAN of the bank account</value>
    [DataMember(Name="iban", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "iban")]
    public string Iban { get; set; }

    /// <summary>
    /// BIC of the bank account
    /// </summary>
    /// <value>BIC of the bank account</value>
    [DataMember(Name="bic", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "bic")]
    public string Bic { get; set; }

    /// <summary>
    /// Currency code of the account (Can only be EUR, for now)
    /// </summary>
    /// <value>Currency code of the account (Can only be EUR, for now)</value>
    [DataMember(Name="currency", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "currency")]
    public string Currency { get; set; }

    /// <summary>
    /// Amount of money on the account, in euro cents
    /// </summary>
    /// <value>Amount of money on the account, in euro cents</value>
    [DataMember(Name="balance_cents", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "balance_cents")]
    public int? BalanceCents { get; set; }

    /// <summary>
    /// Amount of money available for payment from the account, in euro cents
    /// </summary>
    /// <value>Amount of money available for payment from the account, in euro cents</value>
    [DataMember(Name="authorized_balance_cents", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "authorized_balance_cents")]
    public int? AuthorizedBalanceCents { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class OrganizationOrganizationBankAccounts {\n");
      sb.Append("  Slug: ").Append(Slug).Append("\n");
      sb.Append("  Iban: ").Append(Iban).Append("\n");
      sb.Append("  Bic: ").Append(Bic).Append("\n");
      sb.Append("  Currency: ").Append(Currency).Append("\n");
      sb.Append("  BalanceCents: ").Append(BalanceCents).Append("\n");
      sb.Append("  AuthorizedBalanceCents: ").Append(AuthorizedBalanceCents).Append("\n");
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
