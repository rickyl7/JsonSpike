using System;
using System.Collections.Generic;
using System.Text;

namespace JsonSpike
{
    public class Character
    {
        public string Name { get; set; }
        public IEnumerable<RoleEnum> Roles { get; set; }

        public enum RoleEnum
        {
            Defense,
            Purge,
            Utility,
            AOE,
            Burst,
        }
    }
}
