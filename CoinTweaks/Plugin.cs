using System;
using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;

namespace CoinTweaks
{
    public class Plugin : Plugin<Config, Translations>
    {
        public override string Name => "CoinTweaks";
        public override string Author => "GabiRP";
        public override Version RequiredExiledVersion { get; } = new Version(3, 0, 0);
        
        public EventHandlers EventHandlers;
        public Plugin Instance;

        public override void OnEnabled()
        {
            Instance = this;
            EventHandlers = new EventHandlers(this);
            Player.FlippingCoin += EventHandlers.OnFlippingCoin;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Player.FlippingCoin += EventHandlers.OnFlippingCoin;
            EventHandlers = null;
            Instance = null;
            base.OnDisabled();
        }
    }
}