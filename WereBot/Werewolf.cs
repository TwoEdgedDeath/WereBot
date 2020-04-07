using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;

namespace WereBot
{
    class Werewolf
    {
        public static List<DiscordRole> roles1 = new List<DiscordRole>();
        public static List<string> roles = new List<string>();
        public static List<DiscordMember> players = new List<DiscordMember>();

        //Adds one role to the list of roles for the current game
        public static int AddRoles(CommandContext ctx, string role)
        {
            role = role.Replace(" ", String.Empty);
            role = role.ToLower();
            switch (role)
            {
                case "villager":
                    roles1.Add(ctx.Guild.GetRole(696196440166498424));
                    roles.Add("Villager");
                    break;
                case "werewolf":
                    roles1.Add(ctx.Guild.GetRole(696197036625625120));
                    roles.Add("Werewolf");
                    break;
                case "cultleader":
                    roles1.Add(ctx.Guild.GetRole(696208012649693245));
                    roles.Add("Cult Leader");
                    break;
                case "mason":
                    roles1.Add(ctx.Guild.GetRole(696208803414147182));
                    roles.Add("Mason");
                    break;
                case "tanner":
                    roles1.Add(ctx.Guild.GetRole(696208931311321090));
                    roles.Add("Tanner");
                    break;
                case "bodyguard":
                    roles1.Add(ctx.Guild.GetRole(696209233514856470));
                    roles.Add("Bodyguard");
                    break;
                case "toughguy":
                    roles1.Add(ctx.Guild.GetRole(696209359088123996));
                    roles.Add("Tough Guy");
                    break;
                case "cupid":
                    roles1.Add(ctx.Guild.GetRole(696209574373621860));
                    roles.Add("Cupid");
                    break;
                case "prince":
                    roles1.Add(ctx.Guild.GetRole(696222968975458355));
                    roles.Add("Prince");
                    break;
                case "spellcaster":
                    roles1.Add(ctx.Guild.GetRole(696223044854611998));
                    roles.Add("Spellcaster");
                    break;
                case "hunter":
                    roles1.Add(ctx.Guild.GetRole(696223103394775110));
                    roles.Add("Hunter");
                    break;
                case "pacifist":
                    roles1.Add(ctx.Guild.GetRole(696223148038815765));
                    roles.Add("Pacifist");
                    break;
                case "villageidiot":
                    roles1.Add(ctx.Guild.GetRole(696223417975701554));
                    roles.Add("Village Idiot");
                    break;
                case "mayor":
                    roles1.Add(ctx.Guild.GetRole(696224063542263898));
                    roles.Add("Mayor");
                    break;
                case "diseased":
                    roles1.Add(ctx.Guild.GetRole(696224127949865071));
                    roles.Add("Diseased");
                    break;
                case "ghost":
                    roles1.Add(ctx.Guild.GetRole(696225909761638451));
                    roles.Add("Ghost");
                    break;
                case "minion":
                    roles1.Add(ctx.Guild.GetRole(696226107455963227));
                    roles.Add("Minion");
                    break;
                case "wolfcub":
                    roles1.Add(ctx.Guild.GetRole(696226628136599593));
                    roles.Add("Wolf Cub");
                    break;
                case "alphawolf":
                    roles1.Add(ctx.Guild.GetRole(696226693999886347));
                    roles.Add("Alpha Wolf");
                    break;
                case "lonewolf":
                    roles1.Add(ctx.Guild.GetRole(696227793163255848));
                    roles.Add("Lone Wolf");
                    break;
                case "cursed":
                    roles1.Add(ctx.Guild.GetRole(696228255866290198));
                    roles.Add("Cursed");
                    break;
                case "sorceress":
                    roles1.Add(ctx.Guild.GetRole(696228297909993493));
                    roles.Add("Sorceress");
                    break;
                case "vampire":
                    roles1.Add(ctx.Guild.GetRole(696235084084281405));
                    roles.Add("Vampire");
                    break;
                case "seer":
                    roles1.Add(ctx.Guild.GetRole(696229820526231574));
                    roles.Add("Seer");
                    break;
                case "apprenticeseer":
                case "apprentice":
                    roles1.Add(ctx.Guild.GetRole(696230306063319040));
                    roles.Add("Apprentice Seer");
                    break;
                case "auraseer":
                    roles1.Add(ctx.Guild.GetRole(696234567698219049));
                    roles.Add("Aura Seer");
                    break;
                case "mysticSeer":
                    roles1.Add(ctx.Guild.GetRole(696234631284129874));
                    roles.Add("Mystic Seer");
                    break;
                case "witch":
                    roles1.Add(ctx.Guild.GetRole(696234689685487616));
                    roles.Add("Witch");
                    break;
                case "lycan":
                    roles1.Add(ctx.Guild.GetRole(696237558836756511));
                    roles.Add("Lycan");
                    break;
                case "hoodlum":
                    roles1.Add(ctx.Guild.GetRole(696237433586450463));
                    roles.Add("Hoodlum");
                    break;
                case "drunk":
                    roles1.Add(ctx.Guild.GetRole(696237895001964605));
                    roles.Add("Drunk");
                    break;
                case "oldhag":
                    roles1.Add(ctx.Guild.GetRole(696237964727943240));
                    roles.Add("Old Hag");
                    break;
                case "doppelganger":
                    roles1.Add(ctx.Guild.GetRole(696238015420301353));
                    roles.Add("Doppelganger");
                    break;
                case "troublemaker":
                    roles1.Add(ctx.Guild.GetRole(696251917516668978));
                    roles.Add("Troublemaker");
                    break;
                case "pi":
                case "p.i.":
                    roles1.Add(ctx.Guild.GetRole(696238140049850369));
                    roles.Add("Private Investigator");
                    break;
                case "priest":
                    roles1.Add(ctx.Guild.GetRole(696238253438926858));
                    roles.Add("Priest");
                    break;
                case "huntress":
                    roles1.Add(ctx.Guild.GetRole(696238310485393450));
                    roles.Add("Huntress");
                    break;
                case "madbomber":
                    roles1.Add(ctx.Guild.GetRole(696238363522367541));
                    roles.Add("Mad Bomber");
                    break;
                case "revealer":
                    roles1.Add(ctx.Guild.GetRole(696238448595435560));
                    roles.Add("Revealer");
                    break;
                case "mentalist":
                    roles1.Add(ctx.Guild.GetRole(696238543592488980));
                    roles.Add("Mentalist");
                    break;
                default:
                    return 1;
            }
            return 0;
        }

        //Method to get list of roles currently set up for game
        public static String GetRoles()
        {
            int numRoles = 1;
            StringBuilder roleList = new StringBuilder("Roles: ");
            foreach (string i in roles)
            {
                roleList.AppendLine();
                roleList.Append(numRoles + ": " + i);
                numRoles++;
            }

            return roleList.ToString();
        }

        public static void RemoveRole(int roleNum)
        {
            roles.RemoveAt(roleNum - 1);
            roles1.RemoveAt(roleNum - 1);
            return;
        }

        //Adds one user to the list of active players
        public static void AddPlayer(DiscordMember user)
        {
            players.Add(user);

            return;
        }

        //Method to get list of players currently signed up for game
        public static String GetPlayers()
        {
            StringBuilder playerList = new StringBuilder("Players: ");
            foreach (DiscordMember i in players)
            {
                playerList.AppendLine();
                playerList.Append(i.Username);
            }

            return playerList.ToString();
        }

        public static int StartGame()
        {
            if(players.Count() != roles1.Count())
            {
                ///well fuckery
                return 1;
            }

            roles1.Shuffle();
            players.Shuffle();

            for (int i = 0; i < players.Count(); i++)
            {
                DiscordMember member = players[i];
                member.GrantRoleAsync(roles1[i]);
            }

            return 0;
        }


        public static int EndGame(CommandContext ctx)
        {
            for (int i = 0; i < players.Count(); i++)
            {
                DiscordMember member = players[i];
                member.RevokeRoleAsync(roles1[i]);
                member.RevokeRoleAsync(ctx.Guild.GetRole(696224345457950781));
            }

            roles = new List<string>();
            roles1 = new List<DiscordRole>();
            players = new List<DiscordMember>();

            return 0;
        }
    }
}
public static class ThreadSafeRandom
{
    [ThreadStatic] private static Random Local;

    public static Random ThisThreadsRandom
    {
        get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
    }
}
static class MyExtensions
{
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}



