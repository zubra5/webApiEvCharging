using System.Text.Json.Serialization;

namespace Domain.Enum
{
    ///<summary>
    /// 0 = Yazaki 
    ///
    /// 1 = Mennekes
    ///
    ///</summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ConnectorType
    {
        /// <summary>
        /// Yazaki.
        /// </summary>
        Yazaki,

        /// <summary>
        /// Mennekes.
        /// </summary>
        Mennekes
    }
}
