using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Abstract super class for controlling levels, stores collection of checkpoints
    /// </summary>
    abstract class LevelControllerScript
    {
        [SerializeField] private List<GameObject> _checkpoints;
        /// <summary>
        /// Gets or sets collection of checkpoint objects used by player units
        /// </summary>
        public List<GameObject> Checkpoints
        {
            get { return _checkpoints; }
            protected set { _checkpoints = value; }
        } 
    }
}
