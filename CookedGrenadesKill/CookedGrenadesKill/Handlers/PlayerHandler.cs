using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Exiled;
using Grenades;
using UnityEngine;
using Mirror;

namespace CookedGrenadesKill.Handlers
{
    class PlayerHandler
    {
        public static List<GameObject> CGKGrenades = new List<GameObject>();

        private readonly MainPlugin plugin;
        public void OnDying(DyingEventArgs ev)
        {
            var currentItem = ev.Target.Inventory.curItem;
            if (currentItem == ItemType.GrenadeFlash || currentItem == ItemType.GrenadeFrag ||
                currentItem == ItemType.SCP018) //check is grenade
            {
                switch (currentItem)
                {
                    case ItemType.GrenadeFrag:
                        Grenade grenade = Object.Instantiate(ev.Target.GrenadeManager.availableGrenades[0].grenadeInstance)
                            .GetComponent<Grenade>();
                        grenade.fuseDuration = plugin.Config.FuseTime;
                        grenade.InitData(ev.Target.ReferenceHub.GetComponent<GrenadeManager>(), Vector3.zero, Vector3.zero, 0);
                        CGKGrenades.Add(grenade.gameObject); //add grenade object to list to save and do stuff wit later
                        NetworkServer.Spawn(grenade.gameObject); //actually spawn the grenade
                        break;
                    case ItemType.GrenadeFlash:
                        //TODO - Figure out this ^
                        break;
                    case ItemType.SCP018:
                        //TODO - This ^
                        break;
                }
            }
        }
    }
}