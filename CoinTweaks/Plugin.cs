using System;
using Exiled.API.Features;
using Exiled.API.Interfaces;

namespace CoinTweaks
{
    public class Plugin : Plugin<Config>
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
            base.OnEnabled();
        }
    }
}