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
        private Dictionary<string, bool> coinDropped = new Dictionary<string, bool>();
        
        internal void OnFlippingCoin(FlippingCoinEventArgs ev)
        {
            Log.Debug($"{ev.Player.Nickname}: {coinDropped[ev.Player.RawUserId]}");
            if (!coinDropped.ContainsKey(ev.Player.RawUserId))
            {
                coinDropped.Add(ev.Player.RawUserId, false);
            }
            else
            {
                coinDropped[ev.Player.RawUserId] = false;
            }
            if (plugin.Config.DropCoinChance != 0 && UnityEngine.Random.Range(1, 101) <= plugin.Config.DropCoinChance)
            {
                coinDropped[ev.Player.RawUserId] = true;
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
            if (plugin.Config.ShowCoinResultMessage && !coinDropped[ev.Player.RawUserId])
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
            coinDropped.Clear();
        }
    }
}