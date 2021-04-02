using Exiled.API.Interfaces;

namespace CookedGrenadesKill
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true; // true by default = plugin on by default.
    }
}