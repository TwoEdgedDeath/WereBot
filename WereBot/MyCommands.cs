using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;


namespace WereBot
{
    public class MyCommands
    {
        //player signup to add to game
        [Command("signup")]
        public async Task Signup(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            Werewolf.AddPlayer(ctx.Member);
            await ctx.RespondAsync($"{ctx.User.Mention} added to upcoming game!");
        }
        //Starts round
        [Command("start")]
        public async Task Start(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"Starting game of Ultimate Werewolf!");
            int error = Werewolf.StartGame();
            if (error != 0 )
            {
                await ctx.RespondAsync($"Something went wrong!");
            }
            await ctx.RespondAsync($"Roles assigned! Have fun!");
        }

        //End round
        [Command("end")]
        public async Task End(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"Ending game of Ultimate Werewolf!");
            int error = Werewolf.EndGame(ctx);
            if (error != 0)
            {
                await ctx.RespondAsync($"Something went wrong!");
            }
            await ctx.RespondAsync($"Roles unassigned! Thanks for playing!");
        }

        //Displays all current players
        [Command("players")]
        public async Task Players(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"List of players signed up!");
            await ctx.RespondAsync($"{Werewolf.GetPlayers()}");
        }
        //Displays all current roles
        [Command("currentroles")]
        public async Task Roles(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"List of roles in current game!");
            await ctx.RespondAsync($"{Werewolf.GetRoles()}");
        }

        [Command("removeroles")]
        public async Task RemoveRole(CommandContext ctx, int roleNum)
        {
            await ctx.TriggerTypingAsync();
            Werewolf.RemoveRole(roleNum);

            await ctx.RespondAsync($"Updated list of roles in current game!");
            await ctx.RespondAsync($"{Werewolf.GetRoles()}");
        }



        //public async Task ChangeNickname(CommandContext ctx, [Description("Member to change the nickname for.")] DiscordMember member, [RemainingText, Description("The nickname to give to that user.")] string new_nickname)

        //Werewolf.AddRoles();


        [Command("roles")]
        public async Task AddRole(CommandContext ctx)
        {
            int numRoles = 0;
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"{ctx.User.Mention}, how many roles would you like to add to this round? Please just the number :)");

            var interactivity = ctx.Client.GetInteractivityModule();
            var msg = await interactivity.WaitForMessageAsync(xm => xm.Author.Id == ctx.User.Id, TimeSpan.FromMinutes(1));
            if (msg != null)
            {
                numRoles = Int32.Parse(msg.Message.Content);
                await ctx.RespondAsync($"Adding {numRoles} to the game!");
                for (int i = 1; i <= numRoles; i++)
                {
                    await ctx.RespondAsync($"What is role number {i}?");
                    var role = await interactivity.WaitForMessageAsync(xm => xm.Author.Id == ctx.User.Id, TimeSpan.FromMinutes(1));
                    int temp = Werewolf.AddRoles(ctx, role.Message.Content);
                    while(temp != 0)
                    {
                        await ctx.RespondAsync($"Sorry, that role wasn't found! What is role number {i}?");
                        role = await interactivity.WaitForMessageAsync(xm => xm.Author.Id == ctx.User.Id, TimeSpan.FromMinutes(1));
                        temp = Werewolf.AddRoles(ctx, role.Message.Content);
                    }
                }
                await ctx.RespondAsync($"Thanks! The following roles were added: {Werewolf.GetRoles()}");
            }

        }

        [Command("testrole")]
        public async Task TestRole(CommandContext ctx, DiscordMember member)
        {
            DiscordRole role = ctx.Guild.GetRole(696197036625625120);
            await ctx.TriggerTypingAsync();
            try
            {
                await member.GrantRoleAsync(role);

                await ctx.RespondAsync($"{member.Mention} is now {role.Name}");
            }
            catch (Exception)
            {
                // oh no, something failed, let the invoker now
                var emoji = DiscordEmoji.FromName(ctx.Client, ":-1:");
                await ctx.RespondAsync(emoji);
            }
        }

        [Command("vote"), Description("Start a daily vote for the town trial.")]
        public async Task TestVote(CommandContext ctx, [Description("How long should the poll last.")] TimeSpan duration, [Description("What options should people have.")] params DiscordEmoji[] options)
        {
            // first retrieve the interactivity module from the client
            var interactivity = ctx.Client.GetInteractivityModule();
            var poll_options = options.ToString(); // = options.Select(xe => xe.ToString());

            // then let's present the poll
            var embed = new DiscordEmbedBuilder
            {
                Title = "Poll time!",
                Description = string.Join(" ", poll_options)
            };
            var msg = await ctx.RespondAsync(embed: embed);

            // add the options as reactions
            for (var i = 0; i < options.Length; i++)
                await msg.CreateReactionAsync(options[i]);
        }

        ///[Command("roleid")]
        ///public async Task GetRoleID(CommandContext ctx, DiscordRole new_role)
        ///{

        ///    await ctx.TriggerTypingAsync();
           
            
        ///    await ctx.RespondAsync($"{new_role.Id}");

        ///}
    }
}
