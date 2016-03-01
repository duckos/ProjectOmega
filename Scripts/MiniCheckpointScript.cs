using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Mini checkpoint for collisions with player units on path of specific index.
    /// </summary>
    class MiniCheckpointScript : MonoBehaviour
    {
        [SerializeField] private int _index;
        /// <summary>
        /// Gets or sets index number (index in collection in parent checkpoint) of mini checkpoint.
        /// </summary>
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        /// <summary>
        /// Start method of unity script.
        /// </summary>
        public void Start()
        {
            this.gameObject.name = "MiniCheckpoint";
            this.gameObject.GetComponent<Renderer>().enabled = false;
            this.gameObject.GetComponent<Collider>().isTrigger = true;
        }
    }
}
