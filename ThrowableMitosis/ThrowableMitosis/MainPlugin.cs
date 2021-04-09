using System;
using System.Collections.Generic;
using Exiled.Events.Handlers;
using Exiled;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events;
using Exiled.Events.EventArgs;
using Exiled.Events.Extensions;

using Map = Exiled.Events.Handlers.Map;
using Player = Exiled.Events.Handlers.Player;

namespace ThrowableMitosis
{
    public class MainPlugin : Plugin<Config>
    {
        private static MainPlugin _singleton = new MainPlugin();

        //public static Dictionary<Player, string> dict = new Dictionary<Player, string>(); 
        
        //creator stuff
        public override string Author { get; } = "Whanos | Whanos#0621 | @WhanosSergal";
        public override string Name { get; } = "ThrowableMitosis";
        public override string Prefix { get; } = "TM";
        public override Version Version { get; } = new Version(1, 0, 0);
        //end of that
        
        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        private MainPlugin()
        {
            
        }
        //it just needs to be here. don't ask
        
        public static MainPlugin Instance => _singleton;

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
            map = new Handlers.MapHandler();

            Map.ExplodingGrenade += map.OnExplodingGrenade;
            Player.ThrowingGrenade += map.OnGrenadeUse;
        }
        
        private void UnregisterEvents()
        {
            Map.ExplodingGrenade -= map.OnExplodingGrenade;
        }
    }
}