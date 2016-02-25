using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Utility
{
    /// <summary>
    /// Thrown when player unit of specific type already exists in collection
    /// </summary>
    class PlayerUnitAlreadyExistsException : Exception
    {
        private readonly PlayerUnitType _unitType;

        /// <summary>
        /// Creates exception instance
        /// </summary>
        /// <param name="unitType">Type of already existing player unit</param>
        public PlayerUnitAlreadyExistsException(PlayerUnitType unitType)
        {
            _unitType = unitType;
        }

        public override string Message
        {
            get { return "Player unit of type " + _unitType + " already exists."; }
        }
    }
}
