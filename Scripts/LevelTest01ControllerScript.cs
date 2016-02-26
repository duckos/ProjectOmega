using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Level controller for Test 01.
    /// </summary>
    class LevelTest01ControllerScript : LevelControllerScript<LevelTest01ControllerScript>
    {
        /// <summary>
        /// Start method of unity script.
        /// </summary>
        public void Start()
        {
            InitTest01();
        }

        private void InitTest01()
        {
            AddCheckpoint(new GameObject("test01-1"));
            AddCheckpoint(new GameObject("test01-2"));
            AddCheckpoint(new GameObject("test01-3"));
            AddCheckpoint(new GameObject("test01-4"));
        }
    }
}
