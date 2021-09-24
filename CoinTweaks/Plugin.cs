using System;
using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;

namespace CoinTweaks
{
    public class Plugin : Plugin<Config, Translations>
    {
        public override string Name => "CoinTweaks";
        public override string Author => "GabiRP";
        public override Version RequiredExiledVersion { get; } = new Version(3, 0, 0);
        
        public EventHandlers EventHandlers;

        public override void OnEnabled()
        {
            EventHandlers = new EventHandlers(this);
            Player.FlippingCoin += EventHandlers.OnFlippingCoin;
            Server.RoundStarted += EventHandlers.OnRoundStarted;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Player.FlippingCoin -= EventHandlers.OnFlippingCoin;
            Server.RoundStarted -= EventHandlers.OnRoundStarted;
            EventHandlers = null;
            base.OnDisabled();
        }
    }
}