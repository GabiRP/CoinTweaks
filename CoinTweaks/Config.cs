using System.ComponentModel;
using Exiled.API.Interfaces;

namespace CoinTweaks
{
    public class Config : IConfig
    {
        [Description("Whether or not this plugin is enabled.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Whether broadcast should be replaced with hints")]
        public bool UseHints { get; set; } = true;

        [Description("Chance of dropping a coin when flipping it")]
        public int DropCoinChance { get; set; } = 20;

        [Description("Dropping coin broadcast/hint")]
        public string DropCoinMessage { get; set; } = "You accidentaly dropped your coin while flipping it";

        [Description("Duration of drop_coin_message")]
        public ushort DropCoinMessageDuration { get; set; } = 6;
    }
}