using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;

namespace CoinTweaks
{
    public class EventHandlers
    {
        private readonly Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        internal void OnFlippingCoin(FlippingCoinEventArgs ev)
        {
            if (plugin.Config.DropCoinChance != 0 && UnityEngine.Random.Range(1, 101) <= plugin.Config.DropCoinChance)
            {
                var coin = ev.Player.Items.First(x => x.Type == ItemType.Coin);
                Timing.CallDelayed(plugin.Config.DropCoinTime, () =>
                {
                    ev.Player.DropItem(coin);
                    if (plugin.Config.UseHints) 
                        ev.Player.ShowHint(plugin.Translation.DropCoinMessage, plugin.Config.DropCoinMessageDuration);
                    
                    else
                        ev.Player.Broadcast(plugin.Config.DropCoinMessageDuration, plugin.Translation.DropCoinMessage, Broadcast.BroadcastFlags.Normal, true);
                });
                return;
            }
            if (plugin.Config.ShowCoinResultMessage)
            {
                Timing.CallDelayed(plugin.Config.CoinResultTime, () =>
                {
                    if (!plugin.Config.UseHints)
                        ev.Player.Broadcast(plugin.Config.CoinResultMessageDuration, plugin.Translation.CoinResultMessage.Replace("%result%", ev.IsTails ? plugin.Translation.TailsTranslation : plugin.Translation.HeadsTranslation), Broadcast.BroadcastFlags.Normal, true);
                    else
                        ev.Player.ShowHint(plugin.Translation.CoinResultMessage.Replace("%result%", ev.IsTails ? plugin.Translation.TailsTranslation : plugin.Translation.HeadsTranslation), plugin.Config.CoinResultMessageDuration);
                });
            }
        }
    }
}