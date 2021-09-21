using System.Linq;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using UnityEngine;

namespace CoinTweaks
{
    public class EventHandlers
    {
        private readonly Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;
        private bool coinDropped = false;

        internal void OnFlippingCoin(FlippingCoinEventArgs ev)
        {
            if(coinDropped)
                coinDropped = false;
            if (Random.Range(0, 101) <= plugin.Config.DropCoinChance && plugin.Config.DropCoinChance != 0)
            {
                coinDropped = true;
                Log.Debug("Dropping coin", plugin.Config.Debug);
                var coin = ev.Player.Items.First(x => x.Type == ItemType.Coin);
                Timing.CallDelayed(1f, () =>
                {
                    ev.Player.DropItem(coin);
                    if (plugin.Config.UseHints)
                    {
                        ev.Player.ShowHint(plugin.Translation.DropCoinMessage, plugin.Config.DropCoinMessageDuration);
                    }
                    else
                    {
                        ev.Player.Broadcast(plugin.Config.DropCoinMessageDuration, plugin.Translation.DropCoinMessage,
                            Broadcast.BroadcastFlags.Normal, true);
                    }
                });
            }
            if (plugin.Config.ShowCoinResultMessage && !coinDropped)
            {
                Timing.CallDelayed(1.8f, () =>
                {
                    if (!plugin.Config.UseHints)
                        ev.Player.Broadcast(plugin.Config.CoinResultMessageDuration,
                            plugin.Translation.CoinResultMessage.Replace("{result}", ev.IsTails ? plugin.Translation.TailsTranlation : plugin.Translation.HeadsTranslation),
                            Broadcast.BroadcastFlags.Normal, true);
                    else
                        ev.Player.ShowHint(
                            plugin.Translation.CoinResultMessage.Replace("{result}", ev.IsTails ? plugin.Translation.TailsTranlation : plugin.Translation.HeadsTranslation),
                            plugin.Config.CoinResultMessageDuration);
                });

            }
        }
    }
}