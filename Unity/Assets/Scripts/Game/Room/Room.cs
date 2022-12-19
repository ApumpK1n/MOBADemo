using System;
using System.Collections.Generic;


namespace Pumpkin
{
    public class Room
    {
        /// <summary>
        /// 房主Id
        /// </summary>
        public long RoomHolderPlayerId;

        /// <summary>
        /// 房间人数
        /// </summary>
        public int PlayerCount;

        /// <summary>
        /// 房间名
        /// </summary>
        public string RoomName;

        public int PlayerMaxCount = 5;
    }
}
