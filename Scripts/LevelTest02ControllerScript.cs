using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Level controller for Test 02.
    /// </summary>
    class LevelTest02ControllerScript : LevelControllerScript<LevelTest02ControllerScript>
    {
        /// <summary>
        /// Start method of unity script.
        /// </summary>
        public void Start()
        {
            InitTest02();
        }

        private void InitTest02()
        {
            GameObject startSpawn = new GameObject("StartSpawn");
            startSpawn.AddComponent<StartSpawnScript>();

            GameObject finish = new GameObject("Finish");

            AddCheckpoint(new GameObject("test02-1"));
            AddCheckpoint(new GameObject("test02-2"));
            AddCheckpoint(new GameObject("test02-3"));
            AddCheckpoint(new GameObject("test02-4"));
            AddCheckpoint(new GameObject("test02-5"));
            AddCheckpoint(new GameObject("test02-6"));
            AddCheckpoint(new GameObject("test02-7"));
            AddCheckpoint(new GameObject("test02-8"));

            MoveCheckpoint(3, 1);
            MoveCheckpoint(5, 7);
            MoveCheckpoint(6, 3);
        }
    }
}
