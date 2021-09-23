using System.ComponentModel;
using Exiled.API.Interfaces;

namespace CoinTweaks
{
    public class Config : IConfig
    {
        [Description("Whether or not this plugin is enabled.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Whether or not debug mode is enabled")]
        public bool Debug { get; set; } = false;
        [Description("Whether broadcast should be replaced with hints")]
        public bool UseHints { get; set; } = true;

        [Description("Chance of dropping a coin while flipping it (set to 0 to disable)")]
        public int DropCoinChance { get; set; } = 20;

        [Description("Duration of drop_coin_message")]
        public ushort DropCoinMessageDuration { get; set; } = 6;

        [Description("Whether a message should be sent or not telling the player his coin flip result (head/tails)")]
        public bool ShowCoinResultMessage { get; set; } = true;

        [Description("Duration of the above hint/message")]
        public ushort CoinResultMessageDuration { get; set; } = 2;
    }
}