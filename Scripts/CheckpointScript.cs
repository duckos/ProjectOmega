﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Checkpoint parent object containing multiple mini checkpoints for different paths.
    /// </summary>
    class CheckpointScript : MonoBehaviour
    {
        private static readonly int _miniCheckpointsCount = 3;
        /// <summary>
        /// Number of mini checkpoint child objects.
        /// </summary>
        public static int MiniCheckpointsCount 
        {
            get { return _miniCheckpointsCount; }
        }

        private static readonly float _miniCheckpointsSize = 5f;
        /// <summary>
        /// Size of mini checkpoint cube.
        /// </summary>
        public static float MiniCheckpointsSize
        {
            get { return _miniCheckpointsSize; }
        }

        [SerializeField] private List<GameObject> _miniCheckpoints = new List<GameObject>();
        /// <summary>
        /// Gets or sets collection of mini checkpoint objects.
        /// </summary>
        public List<GameObject> MiniCheckpoints
        {
            get { return _miniCheckpoints; }
            protected set { _miniCheckpoints = value; }
        }

        [SerializeField] private bool _hasBrokenConnection = false;
        /// <summary>
        /// Gets or sets flag about broken connection to other checkpoint(s).
        /// </summary>
        public bool HasBrokenConnection
        {
            get { return _hasBrokenConnection; }
            set { _hasBrokenConnection = value; }
        }

        /// <summary>
        /// Start method of unity script.
        /// </summary>
        public void Start()
        {
            this.gameObject.name = "Checkpoint";
            float offset = -1 * (MiniCheckpointsCount - 1) * MiniCheckpointsSize;
            for (int i = 0; i < MiniCheckpointsCount; ++i)
            {
                GameObject miniCp = GameObject.CreatePrimitive(PrimitiveType.Cube);
                MiniCheckpointScript miniCpScript = miniCp.AddComponent<MiniCheckpointScript>();
                miniCpScript.Index = i;
                
                miniCp.transform.localScale = new Vector3(MiniCheckpointsSize, MiniCheckpointsSize, MiniCheckpointsSize);
                miniCp.transform.parent = this.gameObject.transform;
                miniCp.transform.localPosition = new Vector3(offset, 0f, 0f);

                MiniCheckpoints.Add(miniCp);
                offset += 2 * MiniCheckpointsSize;
            }
        }

        /// <summary>
        /// Creates new checkpoint unity object at specific position.
        /// </summary>
        /// <param name="position">Position where to create checkpoint</param>
        /// <returns>Instance of checkpoint unity object</returns>
        public static GameObject CreateCheckpointObject(Vector3 position)
        {
            GameObject checkpoint = new GameObject();
            checkpoint.transform.position = position;
            checkpoint.AddComponent<CheckpointScript>();
            return checkpoint;
        }
    }
}
