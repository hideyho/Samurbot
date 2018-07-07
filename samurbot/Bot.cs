using System;
using TwitchLib;
using TwitchLib.Client.Models;
using TwitchLib.Client.Events;
using TwitchLib.Api.Models.v5.Users;
using TwitchLib.Client;
using TwitchLib.Client.Extensions;

namespace samurbot
{
    class Bot
    {

        
        TwitchClient client;

        public Bot()
        {
            ConnectionCredentials credentials = new ConnectionCredentials(TwitchInfo.BotUsername, TwitchInfo.BotToken);
            client = new TwitchClient();
            client.Initialize(credentials, TwitchInfo.ChannelName);

            client.OnJoinedChannel += onJoinedChannel;
            client.OnMessageReceived += onMessageReceived;
            client.OnWhisperReceived += onWhisperReceived;
            client.OnConnected += Client_OnConnected;

            client.Connect();
        }
        private void onJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            Console.WriteLine("Joined");
            client.SendMessage(e.Channel, "KonCha");
        }

        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            Console.WriteLine($"Connected to {e.AutoJoinChannel}");
        }

        private void onMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            if (e.ChatMessage.Message.Contains("ban"))
                client.TimeoutUser(e.ChatMessage.Channel, e.ChatMessage.Username, TimeSpan.FromSeconds(5),"smth");
        }


        private void onWhisperReceived(object sender, OnWhisperReceivedArgs e)
        {
            if (e.WhisperMessage.Username == "hideyho119")
                client.SendWhisper(e.WhisperMessage.Username, "Hello my god");
        }

      
    }
}
