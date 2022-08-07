using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoguelandsDiscordBot
{
	[System.Serializable]
	public class ChannelList
    {
		public ulong id;
		public string name;
		public ulong serverId;
		public enum Types {User, Channel, Server};
		public Types WhatType;

		public ChannelList(string name, ulong id, ulong serverid, Types type)
		{
			this.name =name;
			
			this.id = id;
			this.WhatType = type;
			this.serverId = serverid;

		}

		public ChannelList(ChannelList c)
        {
			c.id = id;
			c.name = name;
			c.WhatType = WhatType;
			c.serverId = serverId;
        }

    }

    static class Datas
    {
		public static List<ChannelList> Channels = new List<ChannelList>
		{
			new ChannelList("me",0, 0,ChannelList.Types.User),
			new ChannelList("chat",0,0,ChannelList.Types.Channel),
			new ChannelList("a",0,0,ChannelList.Types.User),
			new ChannelList("b",0,0,ChannelList.Types.User),
			new ChannelList("c",0,0,ChannelList.Types.Channel),
			new ChannelList("d",0,0,ChannelList.Types.User),
			new ChannelList("e",0,0,ChannelList.Types.User),
			new ChannelList("f",0,0,ChannelList.Types.User),
			new ChannelList("g",0,0,ChannelList.Types.User),
			new ChannelList("h",0,0,ChannelList.Types.Server),

		};


	}
}
