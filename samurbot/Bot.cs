using System;
using TwitchLib;
using TwitchLib.Client.Models;
using TwitchLib.Client.Events;
using TwitchLib.Api.Models.v5.Users;
using TwitchLib.Client;
using TwitchLib.Client.Extensions;
using samurbot.DAL.Repositories;
using samurbot.DAL.Entities;
using samurbot.services;

namespace samurbot
{
    class Bot
    {

        
        TwitchClient client;
        UserRepository userService = new UserRepository();

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
            client.SendWhisper("hideyho119", "KonCha");
        }

        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            Console.WriteLine($"Connected to {e.AutoJoinChannel}");
           

        }

        private void onMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            var user =  userService.Get(e.ChatMessage.Username);
           
            if (user == null)
            {
                user = new DAL.Entities.User { Id = e.ChatMessage.Username, TempTime = DateTime.Now.TimeOfDay };
                userService.Create(user);
            }
            string rank = user.Role;
            user = MessageRecieved.Up(user);
            userService.Update(user);
            if (rank != user.Role) client.SendMessage(TwitchInfo.ChannelName,"Поздравляю @" + e.ChatMessage.Username+ ", вы теперь "+ user.Role);

            

                
           
        }


        private void onWhisperReceived(object sender, OnWhisperReceivedArgs e)
        {
            if (e.WhisperMessage.Username == "hideyho119") {
                switch (e.WhisperMessage.Message)
                {
                    case "add":
                        {
                            var user = new DAL.Entities.User { Id = e.WhisperMessage.Username, Role = Resources.Ranks.r1, Points = 1, Credits = 1, TempTime = DateTime.Now.TimeOfDay };
                            userService.Create(user);
                            client.SendWhisper(e.WhisperMessage.Username, "Added");
                            break;
                        }

                    case "view":
                        {
                            var users = userService.GetAll();
                            foreach (var i in users)
                                client.SendWhisper(e.WhisperMessage.Username, i.Id);
                            break;
                        }
                    case "up":
                        {
                            var user = userService.Get(e.WhisperMessage.Username);
                            user.Points += (int)(DateTime.Now.TimeOfDay - user.TempTime).TotalMinutes;
                            switch (user.Points)
                            {
                                case 1:
                                    {
                                        user.Role = Resources.Ranks.r1;
                                        break;
                                    }
                                case 3:
                                    {
                                        user.Role = Resources.Ranks.r2;
                                        break;
                                    }
                                default: break;
                            }
                            userService.Update(user);
                            break;
                        }
                   
                }
               
               
            }
        }

      
    }
}
