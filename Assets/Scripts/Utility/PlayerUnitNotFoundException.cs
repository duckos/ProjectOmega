using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Utility
{
    /// <summary>
    /// Thrown when player unit of specific type could not be found in collection.
    /// </summary>
    class PlayerUnitNotFoundException : Exception
    {
        private readonly PlayerUnitType _unitType;

        /// <summary>
        /// Creates expcetion instance.
        /// </summary>
        /// <param name="unitType">Type of not found player unit</param>
        public PlayerUnitNotFoundException(PlayerUnitType unitType)
        {
            _unitType = unitType;
        }

        public override string Message
        {
            get { return "Player unit of type " + _unitType + " could not be found."; }
        }
    }
}
