using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace normality.Commands
{
    class ModerationCmds : BaseCommandModule

    {
        [Command("ban")]
        [Description("Ban user from this server.")]
        [RequirePermissions(Permissions.BanMembers)]
        [Hidden]
        public async Task Ban(CommandContext ctx,
            [Description("User banned")] DiscordMember member,
            [Description("How many days will ban take?")] int days,
            [RemainingText, Description("Reason")] string reason)
        {
            await ctx.TriggerTypingAsync();
            DiscordGuild guild = member.Guild;

            try
            {
                await guild.BanMemberAsync(member, days, reason);
                await ctx.RespondAsync($"User @{member.Username}#{member.Discriminator} was banned by {ctx.User.Username}");
            }
            catch (Exception)
            {
                await ctx.RespondAsync($"User {member.Username} cannot be banned");
            }
        }




    }

}
