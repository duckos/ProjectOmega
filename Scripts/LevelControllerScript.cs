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
    /// <typeparam name="T">Generic type for different levels</typeparam>
    abstract class LevelControllerScript<T> : MonoBehaviour
    {
        private static LevelControllerScript<T> _instance;
        /// <summary>
        /// Returns instance of level controller
        /// </summary>
        /// <returns></returns>
        public static LevelControllerScript<T> Get()
        {
            return _instance ?? (_instance = FindObjectOfType<LevelControllerScript<T>>());
        }

        [SerializeField] private List<GameObject> _checkpoints = new List<GameObject>();
        /// <summary>
        /// Gets or sets collection of checkpoint objects used by player units
        /// </summary>
        public List<GameObject> Checkpoints
        {
            get { return _checkpoints; }
            protected set { _checkpoints = value; }
        }

        /// <summary>
        /// Adds checkpoint to specific position of collection or at the end in default
        /// </summary>
        /// <param name="checkpoint">Checkpoint to be added</param>
        /// <param name="position">Position where to insert checkpoint</param>
        public void AddCheckpoint(GameObject checkpoint, int position = -1)
        {
            if (checkpoint == null)
            {
                throw new ArgumentNullException("checkpoint");
            }

            if ((position < 0) || (position >= Checkpoints.Count))
            {
                Checkpoints.Add(checkpoint);
            }
            else
            {
                Checkpoints.Insert(position, checkpoint);
            }
        }

        /// <summary>
        /// Moves checkpoint from one position to another in collection
        /// </summary>
        /// <param name="oldPosition"></param>
        /// <param name="newPosition"></param>
        public void MoveCheckpoint(int oldPosition, int newPosition)
        {
            if ((oldPosition < 0) || (oldPosition >= Checkpoints.Count))
            {
                throw new ArgumentOutOfRangeException("oldPosition");
            }
            if ((newPosition < 0) || (newPosition >= Checkpoints.Count))
            {
                throw new ArgumentOutOfRangeException("newPosition");
            }
            if (oldPosition == newPosition)
            {
                return;
            }

            GameObject movedCheckpoint = Checkpoints[oldPosition];
            int pos = oldPosition;
            int direction = oldPosition <= newPosition ? 1 : -1;
            while (pos != newPosition)
            {
                Checkpoints[pos] = Checkpoints[pos + direction];
                pos += direction;
            }
            Checkpoints[pos] = movedCheckpoint;
        }
    }
}
