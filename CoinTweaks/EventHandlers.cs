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
        private List<string> coinDroppedUserIds = new List<string>();

        internal void OnFlippingCoin(FlippingCoinEventArgs ev)
        {
            if (!coinDroppedUserIds.Contains(ev.Player.RawUserId))
            {
                coinDroppedUserIds.Add(ev.Player.RawUserId);
            }
            else
            {
                coinDroppedUserIds.Remove(ev.Player.RawUserId);
            }
            if (plugin.Config.DropCoinChance != 0 && UnityEngine.Random.Range(1, 101) <= plugin.Config.DropCoinChance)
            {
                coinDroppedUserIds.Add(ev.Player.RawUserId);
                var coin = ev.Player.Items.First(x => x.Type == ItemType.Coin);
                Timing.CallDelayed(1f, () =>
                {
                    ev.Player.DropItem(coin);
                    if (plugin.Config.UseHints) 
                        ev.Player.ShowHint(plugin.Translation.DropCoinMessage, plugin.Config.DropCoinMessageDuration);
                    
                    else
                        ev.Player.Broadcast(plugin.Config.DropCoinMessageDuration, plugin.Translation.DropCoinMessage, Broadcast.BroadcastFlags.Normal, true);
                });
            }
            if (plugin.Config.ShowCoinResultMessage && !coinDroppedUserIds.Contains(ev.Player.RawUserId))
            {
                Timing.CallDelayed(1.8f, () =>
                {
                    if (!plugin.Config.UseHints)
                        ev.Player.Broadcast(plugin.Config.CoinResultMessageDuration, plugin.Translation.CoinResultMessage.Replace("{result}", ev.IsTails ? plugin.Translation.TailsTranlation : plugin.Translation.HeadsTranslation), Broadcast.BroadcastFlags.Normal, true);
                    else
                        ev.Player.ShowHint(plugin.Translation.CoinResultMessage.Replace("{result}", ev.IsTails ? plugin.Translation.TailsTranlation : plugin.Translation.HeadsTranslation), plugin.Config.CoinResultMessageDuration);
                });
            }
        }

        internal void OnRoundStarted()
        {
            coinDroppedUserIds.Clear();
        }
    }
}