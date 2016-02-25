using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Utility
{
    /// <summary>
    /// Extension methods
    /// </summary>
    static class Extension
    {
        /// <summary>
        /// Adds new player unit to collection after checking whether it does not contain player unit of that type
        /// </summary>
        /// <param name="collection">Collection of player units</param>
        /// <param name="unit">Player unit to be added</param>
        public static void AddPlayerUnit(this ICollection<PlayerUnit> collection, PlayerUnit unit)
        {
            if (collection.FirstOrDefault(t => t.UnitType == unit.UnitType) != null)
            {
                throw new PlayerUnitAlreadyExistsException(unit.UnitType);
            }
            collection.Add(unit);
        }
    }
}
