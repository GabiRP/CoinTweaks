using System.ComponentModel;
using Exiled.API.Interfaces;

namespace CoinTweaks
{
    public class Translations : ITranslation
    {
        [Description("Coin result broadcast/hint (if the above config is true) %result% will be replaced with the flip result")]
        public string CoinResultMessage { get; set; } = "Coin result:";

        [Description("Dropping coin broadcast/hint")]
        public string DropCoinMessage { get; set; } = "You accidentaly dropped your coin while flipping it";

        [Description("Heads translation")] 
        public string HeadsTranslation { get; set; } = "Heads";
        [Description("Tails translation")]
        public string TailsTranslation { get; set; } = "Tails";
    }
}