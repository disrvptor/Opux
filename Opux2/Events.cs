﻿using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace Opux2
{
    class Events
    {
        internal static Task DiscordClient_Disconnected(Exception arg)
        {
            return Task.CompletedTask;
        }

        internal static Task DiscordClient_Ready()
        {
            return Task.CompletedTask;
        }

        internal static async Task DiscordClient_HandleCommand(SocketMessage messageParam)
        {

            var message = messageParam as SocketUserMessage;
            if (message == null) return;

            int argPos = 0;

            if (!(message.HasCharPrefix(Convert.ToChar(Base.Configuration.GetSection("trigger").Value), ref argPos) || message.HasMentionPrefix(Base.DiscordClient.CurrentUser, ref argPos))) return;

            var context = new CommandContext(Base.DiscordClient, message);

            var result = await Base.Commands.ExecuteAsync(context, argPos, Base.ServiceCollection);
        }
    }
}