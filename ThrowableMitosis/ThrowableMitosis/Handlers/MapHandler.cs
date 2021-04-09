using Exiled.Events.EventArgs;
using UnityEngine;
using System;
using System.Linq;
using Grenades;
using Mirror;
using Exiled.API.Features;
using Exiled;
using Object = UnityEngine.Object;
using Random = System.Random;

namespace ThrowableMitosis.Handlers
{
    public class MapHandler
    {
        private static Random randomGen = new Random();
        private readonly MainPlugin plugin;

        public void OnGrenadeUse(ThrowingGrenadeEventArgs ev)
        {
            var player = ev.Player;
            var grenade = ev.GrenadeManager.rb;
        }
        public void OnExplodingGrenade(ExplodingGrenadeEventArgs ev)
        {
            if (ev.IsFrag)
            {
                var randint = randomGen.Next(0, 100);
                if (randint < plugin.Config.FragGrenadeMitosisChance)
                {
                    ev.Thrower.Hurt(10f, DamageTypes.Grenade, "Chungus");
                    /*Grenade grenade = Object.Instantiate(ev.Thrower.GrenadeManager.availableGrenades[0].grenadeInstance)
                        .GetComponent<Grenade>();
                    grenade.fuseDuration = plugin.Config.GrenadeFuseTime;
                    grenade.InitData(ev.Thrower.ReferenceHub.GetComponent<GrenadeManager>(), Vector3.zero, Vector3.zero, 0);
                    NetworkServer.Spawn(grenade.gameObject); //actually spawn the grenade*/
                }
            }
        }
    }
}