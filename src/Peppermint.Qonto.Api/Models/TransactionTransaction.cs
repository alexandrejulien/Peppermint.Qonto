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
  public class TransactionTransaction {
    /// <summary>
    /// ID of the transaction (e.g: acme-corp-1111-1-transaction-123)
    /// </summary>
    /// <value>ID of the transaction (e.g: acme-corp-1111-1-transaction-123)</value>
    [DataMember(Name="transaction_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "transaction_id")]
    public string TransactionId { get; set; }

    /// <summary>
    /// Amount of the transaction, in euro cents
    /// </summary>
    /// <value>Amount of the transaction, in euro cents</value>
    [DataMember(Name="amount_cents", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "amount_cents")]
    public int? AmountCents { get; set; }

    /// <summary>
    /// List of attachments' id
    /// </summary>
    /// <value>List of attachments' id</value>
    [DataMember(Name="attachment_ids", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "attachment_ids")]
    public List<string> AttachmentIds { get; set; }

    /// <summary>
    /// Amount in cents of the local_currency
    /// </summary>
    /// <value>Amount in cents of the local_currency</value>
    [DataMember(Name="local_amount_cents", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "local_amount_cents")]
    public int? LocalAmountCents { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [DataMember(Name="side", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "side")]
    public string Side { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [DataMember(Name="operation_type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "operation_type")]
    public string OperationType { get; set; }

    /// <summary>
    /// ISO 4217 currency code of the bank account (can only be `EUR`, currently)
    /// </summary>
    /// <value>ISO 4217 currency code of the bank account (can only be `EUR`, currently)</value>
    [DataMember(Name="currency", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "currency")]
    public string Currency { get; set; }

    /// <summary>
    /// ISO 4217 currency code of the bank account (can be any currency)
    /// </summary>
    /// <value>ISO 4217 currency code of the bank account (can be any currency)</value>
    [DataMember(Name="local_currency", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "local_currency")]
    public string LocalCurrency { get; set; }

    /// <summary>
    /// Counterparty of the transaction (e.g: Amazon)
    /// </summary>
    /// <value>Counterparty of the transaction (e.g: Amazon)</value>
    [DataMember(Name="label", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "label")]
    public string Label { get; set; }

    /// <summary>
    /// Date the transaction impacted the balance of the account
    /// </summary>
    /// <value>Date the transaction impacted the balance of the account</value>
    [DataMember(Name="settled_at", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "settled_at")]
    public string SettledAt { get; set; }

    /// <summary>
    /// Date at which the transaction impacted the authorized balance of the account
    /// </summary>
    /// <value>Date at which the transaction impacted the authorized balance of the account</value>
    [DataMember(Name="emitted_at", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "emitted_at")]
    public string EmittedAt { get; set; }

    /// <summary>
    /// Date at which the transaction was last updated
    /// </summary>
    /// <value>Date at which the transaction was last updated</value>
    [DataMember(Name="updated_at", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "updated_at")]
    public string UpdatedAt { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [DataMember(Name="status", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "status")]
    public string Status { get; set; }

    /// <summary>
    /// Memo added by the user on the transaction
    /// </summary>
    /// <value>Memo added by the user on the transaction</value>
    [DataMember(Name="note", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "note")]
    public string Note { get; set; }

    /// <summary>
    /// Message sent along income, transfer and direct_debit transactions
    /// </summary>
    /// <value>Message sent along income, transfer and direct_debit transactions</value>
    [DataMember(Name="reference", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "reference")]
    public string Reference { get; set; }

    /// <summary>
    /// Amount of VAT filled in on the transaction, in euro cents
    /// </summary>
    /// <value>Amount of VAT filled in on the transaction, in euro cents</value>
    [DataMember(Name="vat_amount_cents", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "vat_amount_cents")]
    public int? VatAmountCents { get; set; }

    /// <summary>
    /// ID of the membership who initiated the transaction
    /// </summary>
    /// <value>ID of the membership who initiated the transaction</value>
    [DataMember(Name="initiator_id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "initiator_id")]
    public string InitiatorId { get; set; }

    /// <summary>
    /// List of labels' id
    /// </summary>
    /// <value>List of labels' id</value>
    [DataMember(Name="label_ids", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "label_ids")]
    public List<string> LabelIds { get; set; }

    /// <summary>
    /// Indicates if the transaction's attachment was lost (default: false)
    /// </summary>
    /// <value>Indicates if the transaction's attachment was lost (default: false)</value>
    [DataMember(Name="attachment_lost", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "attachment_lost")]
    public bool? AttachmentLost { get; set; }

    /// <summary>
    /// Indicates if the transaction's attachment is required (default: true)
    /// </summary>
    /// <value>Indicates if the transaction's attachment is required (default: true)</value>
    [DataMember(Name="attachment_required", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "attachment_required")]
    public bool? AttachmentRequired { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class TransactionTransaction {\n");
      sb.Append("  TransactionId: ").Append(TransactionId).Append("\n");
      sb.Append("  AmountCents: ").Append(AmountCents).Append("\n");
      sb.Append("  AttachmentIds: ").Append(AttachmentIds).Append("\n");
      sb.Append("  LocalAmountCents: ").Append(LocalAmountCents).Append("\n");
      sb.Append("  Side: ").Append(Side).Append("\n");
      sb.Append("  OperationType: ").Append(OperationType).Append("\n");
      sb.Append("  Currency: ").Append(Currency).Append("\n");
      sb.Append("  LocalCurrency: ").Append(LocalCurrency).Append("\n");
      sb.Append("  Label: ").Append(Label).Append("\n");
      sb.Append("  SettledAt: ").Append(SettledAt).Append("\n");
      sb.Append("  EmittedAt: ").Append(EmittedAt).Append("\n");
      sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
      sb.Append("  Status: ").Append(Status).Append("\n");
      sb.Append("  Note: ").Append(Note).Append("\n");
      sb.Append("  Reference: ").Append(Reference).Append("\n");
      sb.Append("  VatAmountCents: ").Append(VatAmountCents).Append("\n");
      sb.Append("  InitiatorId: ").Append(InitiatorId).Append("\n");
      sb.Append("  LabelIds: ").Append(LabelIds).Append("\n");
      sb.Append("  AttachmentLost: ").Append(AttachmentLost).Append("\n");
      sb.Append("  AttachmentRequired: ").Append(AttachmentRequired).Append("\n");
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
