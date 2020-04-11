using System;
using System.Collections.Generic;

namespace Chat_Core
{
    public class Chat
    {
        public string Identifier { get; private set; }
        public List<Client> AuthenticatedMembers { get; private set; }

        public Chat()
        {

        }

    }
}
