using System.ComponentModel;
using Exiled.API.Interfaces;

namespace CookedGrenadesKill
{
    public sealed class Config : IConfig
    {
        [Description("Plugin enabled or not. Defaults to true.")]
        public bool IsEnabled { get; set; } = true; // true by default = plugin on by default.

        [Description("The fuse time (in seconds) of dropped grenades. Defaults to 1.5seconds.")]
        public float FuseTime { get; set; } = 1.5f;
    }
}