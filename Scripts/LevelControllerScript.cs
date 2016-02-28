using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Abstract super class for controlling levels, stores collection of checkpoints, start spawn and finish.
    /// </summary>
    abstract class LevelControllerScript : MonoBehaviour
    {
        private static LevelControllerScript _instance;
        /// <summary>
        /// Returns instance of level controller.
        /// </summary>
        /// <returns>Level controller instance</returns>
        public static LevelControllerScript Get()
        {
            return _instance ?? (_instance = FindObjectOfType<LevelControllerScript>());
        }

        [SerializeField] private List<GameObject> _checkpoints = new List<GameObject>();
        /// <summary>
        /// Gets or sets collection of checkpoint objects used by player units.
        /// </summary>
        public List<GameObject> Checkpoints
        {
            get { return _checkpoints; }
            protected set { _checkpoints = value; }
        }

        /// <summary>
        /// Gets or sets starting spawn object of level.
        /// </summary>
        public GameObject StartSpawn { get; set; }

        /// <summary>
        /// Gets or sets finish object of level.
        /// </summary>
        public GameObject Finish { get; set; }

        /// <summary>
        /// Adds checkpoint to specific position of collection or at the end in default.
        /// </summary>
        /// <param name="checkpoint">Checkpoint to be added</param>
        /// <param name="index">Index where to insert checkpoint</param>
        public void AddCheckpoint(GameObject checkpoint, int index = -1)
        {
            if (checkpoint == null)
            {
                throw new ArgumentNullException("checkpoint");
            }
            
            if ((index < 0) || (index >= Checkpoints.Count))
            {
                Checkpoints.Add(checkpoint);
            }
            else
            {
                Checkpoints.Insert(index, checkpoint);
            }

            RecalculateConnections(new List<GameObject>() { checkpoint });
        }

        /// <summary>
        /// Removes checkpoint from specific position in colletion.
        /// </summary>
        /// <param name="index">Index of checkpoint to be removed</param>
        public void RemoveCheckpoint(int index)
        {
            if ((index < 0) || (index >= Checkpoints.Count))
            {
                throw new ArgumentOutOfRangeException("index");
            }

            Checkpoints.RemoveAt(index);
            RecalculateConnections(new List<GameObject>()
            {
                index == 0 ? Checkpoints[0] : Checkpoints[index - 1],
                index == Checkpoints.Count ? Checkpoints[index - 1] : Checkpoints[index]    // TODO: pravdepodobne netreba, skontrolovat a odstranit
            });
        }

        /// <summary>
        /// Finds next checkpoint in colletion for given current checkpoint.
        /// If null returns first checkpoint.
        /// </summary>
        /// <param name="currentCheckpoint">Current checkpoint</param>
        /// <returns>Next checkpoint or finish</returns>
        public GameObject FindNextCheckpoint(GameObject currentCheckpoint = null)
        {
            if (currentCheckpoint == null)
            {
                if (Checkpoints.Count == 0)
                {
                    return Finish;
                }
                return Checkpoints[0];
            }

            for (int i = 0; i < Checkpoints.Count; ++i)
            {
                if (Checkpoints[i] == currentCheckpoint)
                {
                    return i + 1 == Checkpoints.Count ? Finish : Checkpoints[i + 1];
                }
            }
            throw new ArgumentException("Given object could not be found in collection of checkpoints.", "currentCheckpoint");
        }

        /// <summary>
        /// Moves checkpoint from one position to another in collection.
        /// </summary>
        /// <param name="oldIndex">Index of checkpoint to be moved</param>
        /// <param name="newIndex">Index to where will be checkpoint moved</param>
        public void MoveCheckpoint(int oldIndex, int newIndex)
        {
            if ((oldIndex < 0) || (oldIndex >= Checkpoints.Count))
            {
                throw new ArgumentOutOfRangeException("oldIndex");
            }
            if ((newIndex < 0) || (newIndex >= Checkpoints.Count))
            {
                throw new ArgumentOutOfRangeException("newIndex");
            }
            if (oldIndex == newIndex)
            {
                return;
            }

            GameObject movedCheckpoint = Checkpoints[oldIndex];
            int pos = oldIndex;
            int direction = oldIndex <= newIndex ? 1 : -1;
            while (pos != newIndex)
            {
                Checkpoints[pos] = Checkpoints[pos + direction];
                pos += direction;
            }
            Checkpoints[pos] = movedCheckpoint;

            RecalculateConnections(new List<GameObject>() { Checkpoints[oldIndex], Checkpoints[newIndex] });
        }

        /// <summary>
        /// Changes position of checkpoint in scene.
        /// </summary>
        /// <param name="index">Index of checkpoint to be moved in scene</param>
        /// <param name="newPosition">New position of checkpoint</param>
        public void ChangeCheckpointPosition(int index, Vector3 newPosition)
        {
            if ((index < 0) || (index >= Checkpoints.Count))
            {
                throw new ArgumentOutOfRangeException("index");
            }

            Checkpoints[index].transform.position = newPosition;
            RecalculateConnections(new List<GameObject>() { Checkpoints[index] });
        }

        /// <summary>
        /// Checks whether connection between previous, current and next checkpoints, towers, start spawn and finish can be created.
        /// Sets flags for objects which break these connections.
        /// </summary>
        /// <param name="targets">Collection of game objects which connections to others should be checked, checks all if null</param>
        public void RecalculateConnections(List<GameObject> targets = null)
        {
            // TODO: skontrolovat ci sa do cp da dostat z predchadzajuceho cp + ci sa z neho da dostat do dalsieho cp
            // TODO: skontrolovat pristupnost start spawnu a finishu + skontrolovat vsetky veze a ich previous a next cp
            // TODO: nastavit nejaky flag (property) na cp, ktory pokazil nejake spojenia
        }

        /// <summary>
        /// Recalculates rotations of all checkpoints for nicer moving between mini checkpoints with the same index.
        /// Should be called after change of checkpoint positions (in collection or in scene) or when added / deleted checkpoint.
        /// </summary>
        public void RecalculateCheckpointRotations()
        {
            // TODO: prepocitat rotacie vsetkych checkpointov, aby sa dalo normalne presuvat po cestach medzi mini cp
        }
    }
}
