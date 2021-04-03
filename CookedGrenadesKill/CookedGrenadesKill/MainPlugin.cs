using System;
using Exiled.API.Features;
using Exiled.API.Enums;
using Exiled.Events.Handlers;
using Exiled;
using Exiled.Events;
using Exiled.Events.EventArgs;
using Exiled.Events.Extensions;

using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;
using Map = Exiled.Events.Handlers.Map;


namespace CookedGrenadesKill
{
    public class MainPlugin : Plugin<Config>
    {

        private static MainPlugin _singleton = new MainPlugin();
        // what?
        
        //creator stuff
        public override string Author { get; } = "Whanos | Whanos#0621 | @WhanosSergal";
        public override string Name { get; } = "CookedGrenadesKill";
        public override string Prefix { get; } = "CGK";
        public override Version Version { get; } = new Version(1, 1, 0);
        //end of that
        
        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        private MainPlugin()
        {
            
        }

        public static MainPlugin Instance => _singleton;

        private Handlers.PlayerHandler player;
        private Handlers.MapHandler map;
        public override void OnEnabled()
        {
            RegisterEvents();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
        }

        private void RegisterEvents()
        {
            player = new Handlers.PlayerHandler();
            map = new Handlers.MapHandler();

            Player.Dying += player.OnDying;
            Map.ExplodingGrenade += map.OnExplodingGrenade;
        }
        
        private void UnregisterEvents()
        {
            Player.Dying -= player.OnDying;
            Map.ExplodingGrenade -= map.OnExplodingGrenade;
        }
    }
}