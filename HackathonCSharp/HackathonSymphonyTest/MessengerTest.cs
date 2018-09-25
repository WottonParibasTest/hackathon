using System;
using HackathonSymphony;
using Xunit;

namespace HackathonSymphonyTest
{
    public class MessengerTest
    {
        [Fact]
        public void SendMessage()
        {
            var messenger = new Messenger();
            var bot = new Bot();
            messenger.SendMessageToUser(bot, "emailAddressGoesHere", "hello testing...");
        }
    }
}