using System.ComponentModel;
using Exiled.API.Features.Items;
using Exiled.Events.EventArgs;

namespace CoinTweaks
{
    public class EventHandlers
    {
        private readonly Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        internal void OnFlippingCoin(UsingItemEventArgs ev)
        {
            if (ev.Item.Type != ItemType.Coin) return;
            if (UnityEngine.Random.Range(0, 101) <= plugin.Config.DropCoinChance)
            {
                ev.Item.Owner.DropItem(ev.Item);
                if (plugin.Config.UseHints)
                {
                    ev.Player.ShowHint(plugin.Config.DropCoinMessage, plugin.Config.DropCoinMessageDuration);
                }
                else
                {
                    ev.Player.Broadcast(plugin.Config.DropCoinMessageDuration, plugin.Config.DropCoinMessage, Broadcast.BroadcastFlags.Normal, true);
                }
            }
        }
    }
}