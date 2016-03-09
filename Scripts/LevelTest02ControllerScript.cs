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
    class LevelTest02ControllerScript : LevelControllerScript
    {
        /// <summary>
        /// Start method of unity script.
        /// </summary>
        public void Start()
        {
            this.gameObject.name = "LevelTest02Controller";

            InitTest02();
        }

        private void InitTest02()
        {
            StartSpawn = StartSpawnScript.CreateStartSpawnObject(new Vector3(14f, 5f, 475f));
            Finish = FinishScript.CreateFinishObject(new Vector3(322f, 5f, 304f), new Vector3(10f, 10f, 10f));
            
            AddCheckpoint(CheckpointScript.CreateCheckpointObject(new Vector3(45f, 5f, 393f)));
            AddCheckpoint(CheckpointScript.CreateCheckpointObject(new Vector3(115f, 5f, 290f)));
            AddCheckpoint(CheckpointScript.CreateCheckpointObject(new Vector3(26f, 5f, 223f)));
            AddCheckpoint(CheckpointScript.CreateCheckpointObject(new Vector3(98f, 5f, 178f)));
            AddCheckpoint(CheckpointScript.CreateCheckpointObject(new Vector3(228f, 5f, 196f)));
            AddCheckpoint(CheckpointScript.CreateCheckpointObject(new Vector3(516f, 5f, 92f)));

            RecalculateCheckpointRotations();
        }
    }
}
