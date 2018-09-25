using System;
using System.Diagnostics;
using HackathonSymphony;
using Xunit;

namespace HackathonSymphonyTest
{
    public class MessengerTest
    {
        private string _emailAddressToTestWith = "FILL THIS IN";
        
        [Fact]
        public void SendMessageToUser()
        {
            var messenger = new Messenger();
            var bot = new Bot();
            messenger.SendMessageToUser(bot, _emailAddressToTestWith, "hello testing...");
        }

        [Fact]
        public void ListenForMessages()
        {
            
            var messenger = new Messenger();
            var bot = new Bot();
            messenger.RecieveMessages(bot, (mArgs) =>
            {
                var m = mArgs.Message;
                Debug.WriteLine(m.Body); 
                Debug.WriteLine("Message was from: {0} on stream {1}", m.FromUserId, m.StreamId);
            });
            
            Debug.WriteLine("End");
        }

        [Fact]
        public void SendMessageToChatRoom()
        {
            var messenger = new Messenger();
            var bot = new Bot();
            messenger.SendMessageToChatRoom(bot, "PQi8eDhTkAGpNzSA8XdcJX___poJU8hUdA", string.Format("This is a message from {0}! Happy days...", bot.UserId));
        }
    }
}