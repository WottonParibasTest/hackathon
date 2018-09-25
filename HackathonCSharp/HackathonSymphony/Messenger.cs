using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using SymphonyOSS.RestApiClient.Authentication;
using SymphonyOSS.RestApiClient.Entities;
using SymphonyOSS.RestApiClient.Factories;
using SymphonyOSS.RestApiClient.MessageML;

namespace HackathonSymphony
{
    public class Messenger
    {
        
        string PodUri => "https://develop2.symphony.com/pod";
        string KeyManagerUri =>  "https://develop2-api.symphony.com:8444/keyauth";
        string AgentUri => "https://develop2.symphony.com/agent";
        string SessionUri => "https://develop2-api.symphony.com:8444/sessionauth";
        
        public void SendMessageToUser(Bot bot, string userEmailAddress, string message)
        {
            var certificate = new X509Certificate2(bot.Certificate, bot.Password);

            var sessionManager = new UserSessionManager(SessionUri, KeyManagerUri, certificate);
            
            
            var podApiFactory = new PodApiFactory(PodUri);
            var usersApi = podApiFactory.CreateUsersApi(sessionManager);
            var streamsApi = podApiFactory.CreateStreamsApi(sessionManager);

            var userId = usersApi.GetUserId(userEmailAddress);
            
             var streamId = streamsApi.CreateStream(new List<long> {userId});
             var body = new MessageBuilder().Text(message).ToString();
             var messagesApi = new AgentApiFactory(AgentUri).CreateMessagesApi(sessionManager);
           
            messagesApi.PostMessage(new Message(streamId, body));
        }
    }
}