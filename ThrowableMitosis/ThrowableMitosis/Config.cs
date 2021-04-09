using System.ComponentModel;
using Exiled.API.Interfaces;

namespace ThrowableMitosis
{
    public sealed class Config : IConfig
    {
        [Description("Plugin enabled or not. Defaults to true.v")]
        public bool IsEnabled { get; set; } = true;

        [Description("The chance for a frag grenade to duplicate on explosion. Use a whole number between 0 and 100.")]
        public int FragGrenadeMitosisChance { get; set; } = 100;

        [Description("Duplicated grenade fuse time. Defaults to 1.5.")]
        public float GrenadeFuseTime { get; set; } = 1.5f;
    }
}