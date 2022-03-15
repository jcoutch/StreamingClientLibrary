﻿using Newtonsoft.Json;

namespace Twitch.Base.Models.Clients.Chat
{
    /// <summary>
    /// Information about a chat host target packet.
    /// </summary>
    public class ChatHostTargetPacketModel : ChatPacketModelBase
    {
        /// <summary>
        /// The ID of the command for a chat host target.
        /// </summary>
        public const string CommandID = "HOSTTARGET";

        /// <summary>
        /// The name of the channel performing the host.
        /// </summary>
        public string HostingChannel { get; set; }

        /// <summary>
        /// The name of the channel the host is targeting.
        /// </summary>
        public string TargetChannel { get; set; }

        /// <summary>
        /// The number of viewers.
        /// </summary>
        public int ViewerCount { get; set; }

        /// <summary>
        /// Creates a new instance of the ChatHostTargetPacketModel class.
        /// </summary>
        /// <param name="packet">The Chat packet</param>
        public ChatHostTargetPacketModel(ChatRawPacketModel packet)
            : base(packet)
        {
            this.HostingChannel = packet.Parameters.Count > 0 ? packet.Parameters[0] : string.Empty;
            this.TargetChannel = packet.Parameters.Count > 1 ? packet.Parameters[1] : string.Empty;
            if (packet.Parameters.Count > 2 && int.TryParse(packet.Parameters[2], out int viewerCount))
            {
                this.ViewerCount = viewerCount;
            }
        }

        /// <summary>
        /// Indicates whether host mode is starting.
        /// </summary>
        [JsonIgnore]
        public bool IsStartingHostMode { get { return !string.IsNullOrEmpty(this.TargetChannel) && !this.TargetChannel.Equals("-"); } }
    }
}
