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
  public class AttachmentAttachment {
    /// <summary>
    /// Timestamp of the file upload
    /// </summary>
    /// <value>Timestamp of the file upload</value>
    [DataMember(Name="created_at", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "created_at")]
    public string CreatedAt { get; set; }

    /// <summary>
    /// Name of the file
    /// </summary>
    /// <value>Name of the file</value>
    [DataMember(Name="file_name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "file_name")]
    public string FileName { get; set; }

    /// <summary>
    /// Size of the file (Max size of Qonto files is 10Mo)
    /// </summary>
    /// <value>Size of the file (Max size of Qonto files is 10Mo)</value>
    [DataMember(Name="file_size", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "file_size")]
    public int? FileSize { get; set; }

    /// <summary>
    /// MIME type of the file
    /// </summary>
    /// <value>MIME type of the file</value>
    [DataMember(Name="file_content_type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "file_content_type")]
    public string FileContentType { get; set; }

    /// <summary>
    /// URL to download the file (Expires after 30 minutes)
    /// </summary>
    /// <value>URL to download the file (Expires after 30 minutes)</value>
    [DataMember(Name="url", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "url")]
    public string Url { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AttachmentAttachment {\n");
      sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
      sb.Append("  FileName: ").Append(FileName).Append("\n");
      sb.Append("  FileSize: ").Append(FileSize).Append("\n");
      sb.Append("  FileContentType: ").Append(FileContentType).Append("\n");
      sb.Append("  Url: ").Append(Url).Append("\n");
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
