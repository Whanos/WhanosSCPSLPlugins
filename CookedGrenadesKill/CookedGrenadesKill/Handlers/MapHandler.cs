using Exiled.Events.EventArgs;
using UnityEngine;

namespace CookedGrenadesKill.Handlers
{
    public class MapHandler
    {
        public void OnExplodingGrenade(ExplodingGrenadeEventArgs ev)
        {
            if (PlayerHandler.CGKGrenades.Contains(ev.Grenade))
            {
                Object.Destroy(ev.Grenade); //get outta here, fixes dumb duplication issue
                PlayerHandler.CGKGrenades.Remove(ev.Grenade);
            }
        }
    }
}