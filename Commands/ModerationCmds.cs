using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
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
        [Description("Bans A User")]
        [RequireRoles(RoleCheckMode.Any, "admin", "server manager", "founder")]
        public async Task BanAsync(int delete_message_days = 0, string reason = null)
        {
                
        }

       


    }

}
