using System.Text.Json.Serialization;

namespace Domain.Enum
{
    ///<summary>
    /// 0 = Available 
    ///
    /// 1 = Engaged
    ///
    /// 2 - Broken
    /// 
    /// 3 - Reserved
    ///</summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ChargerStatus
    {
        /// <summary>
        /// Available
        /// </summary>
        Available,

        /// <summary>
        /// Engaged
        /// </summary>
        Engaged,

        /// <summary>
        /// Broken
        /// </summary>
        Broken,

        /// <summary>
        /// Reserved
        /// </summary>
        Reserved
    }
}
