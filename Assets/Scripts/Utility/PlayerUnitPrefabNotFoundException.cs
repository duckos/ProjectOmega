using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Utility
{
    /// <summary>
    /// Thrown when player unit prefab of specific type could not be found.
    /// </summary>
    class PlayerUnitPrefabNotFoundException : Exception
    {
        private readonly PlayerUnitType _unitType;

        /// <summary>
        /// Creates expcetion instance.
        /// </summary>
        /// <param name="unitType">Type of not found player unit prefab</param>
        public PlayerUnitPrefabNotFoundException(PlayerUnitType unitType)
        {
            _unitType = unitType;
        }

        public override string Message
        {
            get { return "Player unit prefab of type " + _unitType + " could not be found."; }
        }
    }
}
