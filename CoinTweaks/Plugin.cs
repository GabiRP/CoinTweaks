using System;
using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;

namespace CoinTweaks
{
    public class Plugin : Plugin<Config, Translations>
    {
        public override string Name => "CoinTweaks";
        public override string Author => "GabiRP";
        public override Version Version => new Version(1, 0, 8);
        public override Version RequiredExiledVersion => new Version(4,0,0);
        
        EventHandlers EventHandlers;

        public override void OnEnabled()
        {
            EventHandlers = new EventHandlers(this);
            Player.FlippingCoin += EventHandlers.OnFlippingCoin;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Player.FlippingCoin -= EventHandlers.OnFlippingCoin;
            EventHandlers = null;
            base.OnDisabled();
        }
    }
}