using System.Text.Json.Serialization;

namespace Domain.Enum
{
    ///<summary>
    /// 0 = Open 
    ///
    /// 1 = Close
    ///
    /// 2 = Terminated
    ///</summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ChargingStationStatus
    {
        /// <summary>
        /// Open
        /// </summary>
        Open,

        /// <summary>
        /// Closed
        /// </summary>
        Closed,

        /// <summary>
        /// Terminated
        /// </summary>
        Terminated
    }
}
