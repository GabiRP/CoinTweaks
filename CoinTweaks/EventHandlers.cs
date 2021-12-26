using Exiled.API.Features;
using Exiled.Events.Commands.Show;
using Exiled.Events.EventArgs;
using MEC;

namespace CoinTweaks
{
    public class EventHandlers
    {
        private Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        internal void OnFlippingCoin(FlippingCoinEventArgs ev)
        {
            if (plugin.Config.DropCoinChance > 0 && UnityEngine.Random.Range(1, 100) <= plugin.Config.DropCoinChance)
            {
                Timing.CallDelayed(plugin.Config.DropCoinTime, () =>
                {
                    ev.Player.DropItem(ev.Player.CurrentItem);
                    if (plugin.Config.UseHints) 
                        ev.Player.ShowHint(plugin.Translation.DropCoinMessage, plugin.Config.DropCoinMessageDuration);
                    else
                        ev.Player.Broadcast(plugin.Config.DropCoinMessageDuration, plugin.Translation.DropCoinMessage, shouldClearPrevious: true);
                });
                return;
            }
            if (plugin.Config.ShowCoinResultMessage)
            {
                Timing.CallDelayed(plugin.Config.CoinResultTime, () =>
                {
                    if (plugin.Config.UseHints)
                        ev.Player.ShowHint($"{plugin.Translation.CoinResultMessage} {(ev.IsTails ? plugin.Translation.TailsTranslation : plugin.Translation.HeadsTranslation)}", plugin.Config.CoinResultMessageDuration);
                    else
                        ev.Player.Broadcast(plugin.Config.CoinResultMessageDuration, $"{plugin.Translation.CoinResultMessage} {(ev.IsTails ? plugin.Translation.TailsTranslation : plugin.Translation.HeadsTranslation)}");
                });
            }
        }
    }
}