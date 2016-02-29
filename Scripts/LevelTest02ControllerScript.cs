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
            GameObject startSpawn = new GameObject("StartSpawn");
            startSpawn.transform.position = new Vector3(14f, 5f, 475f);
            startSpawn.AddComponent<StartSpawnScript>();
            StartSpawn = startSpawn;

            GameObject finish = GameObject.CreatePrimitive(PrimitiveType.Cube);
            finish.transform.localScale = new Vector3(10f, 10f, 10f);
            finish.transform.position = new Vector3(322f, 5f, 304f);
            finish.AddComponent<FinishScript>();
            Finish = finish;

            GameObject cp = new GameObject();
            cp.transform.position = new Vector3(45f, 5f, 393f);
            cp.AddComponent<CheckpointScript>();
            AddCheckpoint(cp);

            cp = new GameObject();
            cp.transform.position = new Vector3(115f, 5f, 290f);
            cp.AddComponent<CheckpointScript>();
            AddCheckpoint(cp);

            cp = new GameObject();
            cp.transform.position = new Vector3(26f, 5f, 223f);
            cp.AddComponent<CheckpointScript>();
            AddCheckpoint(cp);

            cp = new GameObject();
            cp.transform.position = new Vector3(98f, 5f, 178f);
            cp.AddComponent<CheckpointScript>();
            AddCheckpoint(cp);

            cp = new GameObject();
            cp.transform.position = new Vector3(228f, 5f, 196f);
            cp.AddComponent<CheckpointScript>();
            AddCheckpoint(cp);
        }
    }
}
