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
            GameObject startSpawn = new GameObject();
            startSpawn.AddComponent<StartSpawnScript>();
            StartSpawn = startSpawn;

            GameObject finish = GameObject.CreatePrimitive(PrimitiveType.Cube);
            finish.name = "Finish";
            finish.transform.localScale = new Vector3(10f, 10f, 10f);
            finish.transform.position = new Vector3(150f, 5f, 187f);
            finish.AddComponent<FinishScript>();
            Finish = finish;

            AddCheckpoint(new GameObject("test01-1"));
            AddCheckpoint(new GameObject("test01-2"));
            AddCheckpoint(new GameObject("test01-3"));
            AddCheckpoint(new GameObject("test01-4"));

            Checkpoints[0].transform.position = new Vector3(150f, 0f, 190f);
        }
    }
}
