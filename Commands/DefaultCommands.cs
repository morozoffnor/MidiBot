using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MidiBot.Commands
{
    public class DefaultCommands : BaseCommandModule
    {
        [Command("pick")]
        [Description("Picks one option of many ones you specified. \nOptions must be separated with ', '(comma and space) \nExample: !pick <option1>, <option2>, <option3>")]
        public async Task Pick(CommandContext ctx)
        {
            string prefix = "!";
            string fullString = ctx.Message.Content;
            string noCmd = fullString.Replace($"{prefix}pick ", "");
            String[] Options = noCmd.Split(", ");
            await ctx.Channel.SendMessageAsync(Options[new Random().Next(0, Options.Length)]).ConfigureAwait(false);
        }


        [Command("roll")]
        [Description("Rolls a random number between 1 and the number you specify in argument")]
        public async Task Roll(CommandContext ctx, [Description("A number between 1 and 2147483647")]int number=100)
        {
            int rolledNumber = new Random().Next(1, number);
            await ctx.Channel.SendMessageAsync(rolledNumber.ToString()).ConfigureAwait(false);
        }

        [Command("ask")]
        public async Task Ask(CommandContext ctx)
        {
            if (ctx.Message.Content.EndsWith('?'))
            {
                String[] answers = { "YES", "NO" };
                await ctx.Channel.SendMessageAsync(answers[new Random().Next(0, answers.Length)]).ConfigureAwait(false);
            }
            else
            {
                await ctx.Channel.SendMessageAsync("Ask a question please").ConfigureAwait(false);
            }

        }
    }
}
