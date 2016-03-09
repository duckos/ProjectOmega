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
    class LevelTest01ControllerScript : LevelControllerScript
    {
        /// <summary>
        /// Start method of unity script.
        /// </summary>
        public void Start()
        {
            this.gameObject.name = "LevelTest01Controller";

            InitTest01();
        }

        private void InitTest01()
        {
            StartSpawn = StartSpawnScript.CreateStartSpawnObject(Vector3.zero);
            Finish = FinishScript.CreateFinishObject(new Vector3(150f, 5f, 187f), new Vector3(10f, 10f, 10f));

            AddCheckpoint(CheckpointScript.CreateCheckpointObject(Vector3.zero));
            AddCheckpoint(CheckpointScript.CreateCheckpointObject(Vector3.zero));
            AddCheckpoint(CheckpointScript.CreateCheckpointObject(Vector3.zero));
            AddCheckpoint(CheckpointScript.CreateCheckpointObject(Vector3.zero));

            ChangeCheckpointPosition(0, new Vector3(150f, 0f, 190f));
            RecalculateCheckpointRotations();
        }
    }
}
