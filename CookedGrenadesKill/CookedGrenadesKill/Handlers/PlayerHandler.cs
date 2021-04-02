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
        public void OnDying(DyingEventArgs ev)
        {
            var currentItem = ev.Target.Inventory.curItem;
            if (currentItem == ItemType.GrenadeFlash || currentItem == ItemType.GrenadeFrag ||
                currentItem == ItemType.SCP018)
            {
                switch (currentItem)
                {
                    case ItemType.GrenadeFrag:
                        Grenade grenade = Object.Instantiate(ev.Target.GrenadeManager.availableGrenades[0].grenadeInstance)
                            .GetComponent<Grenade>();
                        grenade.fuseDuration = 1.5f;
                        grenade.InitData(ev.Target.ReferenceHub.GetComponent<GrenadeManager>(), Vector3.zero, Vector3.zero, 0);
                        NetworkServer.Spawn(grenade.gameObject);
                        break;
                    case ItemType.GrenadeFlash:
                        break;
                }
            }
        }
    }
}