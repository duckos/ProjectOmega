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
        public GameObject StartSpawn { get; protected set; }

        /// <summary>
        /// Gets or sets finish object of level.
        /// </summary>
        public GameObject Finish { get; protected set; }

        /// <summary>
        /// Gets collection of all towers in scene.
        /// </summary>
        public List<TowerScript> Towers
        {
            get { return FindObjectsOfType<TowerScript>().ToList(); }
        } 

        /// <summary>
        /// Adds checkpoint to specific position of collection or at the end in default.
        /// </summary>
        /// <param name="checkpoint">Checkpoint to be added</param>
        /// <param name="index">Index where to insert checkpoint, added to the end if null</param>
        public void AddCheckpoint(GameObject checkpoint, int? index = null)
        {
            if (checkpoint == null)
            {
                throw new ArgumentNullException("checkpoint");
            }

            if (index.HasValue)
            {
                Checkpoints.Insert(index.Value, checkpoint);
            }
            else
            {
                Checkpoints.Add(checkpoint);
            }
            
            RecalculateConnections(new List<int>() { index ?? Checkpoints.Count - 1 });
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
            RecalculateConnections(new List<int>()
            {
                index == 0 ? 0 : index - 1,
                index == Checkpoints.Count ? index - 1 : index      // TODO: pravdepodobne netreba, skontrolovat a odstranit
            });
        }

        /// <summary>
        /// Finds next checkpoint in colletion for given current checkpoint.
        /// Returns first checkpoint (or finish when no checkpoint exists) if current checkpoint is null.
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

            RecalculateConnections(new List<int>() { oldIndex, newIndex });
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
            RecalculateConnections(new List<int>() { index });
        }

        /// <summary>
        /// Checks whether connection between previous, current and next checkpoints, towers, start spawn and finish can be created.
        /// Sets flag for objects which break these connections.
        /// </summary>
        /// <param name="targetIndices">Collection of checkpoint indices which connections to others should be checked, checks all if null</param>
        public void RecalculateConnections(List<int> targetIndices = null)
        {
            if (targetIndices == null)
            {
                targetIndices = Enumerable.Range(0, Checkpoints.Count).ToList();
            }

            foreach (int index in targetIndices)
            {
                GameObject before = index == 0 ? StartSpawn : Checkpoints[index - 1];
                GameObject current = Checkpoints[index];
                GameObject after = index + 1 == Checkpoints.Count ? Finish : Checkpoints[index + 1];

                bool connectionBefore = CanCreateConnection(before, current);
                bool connectionAfter = CanCreateConnection(current, after);
                current.GetComponent<CheckpointScript>().HasBrokenConnection = !connectionBefore || !connectionAfter;
            }


            // TODO: skontrolovat vsetky veze a ich previous a next cp
            // TODO: pravdepodobne budu tieto spojenia vytvarane hracom a ulozene v strukture
            // TODO: bude sa kontrolovat ci je cp null a ci je mozne vytvorit spojenie
        }

        /// <summary>
        /// Recalculates rotations of all checkpoints for nicer moving between mini checkpoints with the same index.
        /// Should be called after change of checkpoint positions (in collection or in scene) or when added / deleted checkpoint.
        /// </summary>
        public void RecalculateCheckpointRotations()
        {
            for (int i = 0; i < Checkpoints.Count; ++i)
            {
                Vector3 afterPos = i + 1 == Checkpoints.Count ? Finish.transform.position : Checkpoints[i + 1].transform.position;
                Vector3 currentPos = Checkpoints[i].transform.position;
                Vector3 beforePos = i == 0 ? StartSpawn.transform.position : Checkpoints[i - 1].transform.position;

                Vector3 dir = (afterPos - currentPos).normalized + (currentPos - beforePos).normalized;
                Checkpoints[i].transform.rotation = Quaternion.LookRotation(dir);
            }
        }

        /// <summary>
        /// Calculates whether between two objects is not terrain from scene.
        /// </summary>
        /// <param name="from">Object from which it starts</param>
        /// <param name="to">Object in which it ends</param>
        /// <returns>True if there is no terrain between two objects, false otherwise</returns>
        public bool CanCreateConnection(GameObject from, GameObject to)
        {
            Vector3 fromPos = from.transform.position;
            fromPos.Set(fromPos.x, fromPos.y + CheckpointScript.MiniCheckpointsSize, fromPos.z);
            Vector3 toPos = to.transform.position;
            toPos.Set(toPos.x, toPos.y + CheckpointScript.MiniCheckpointsSize, toPos.z);

            RaycastHit temp;
            Ray ray = new Ray(fromPos, (toPos - fromPos).normalized);
            return !Terrain.activeTerrain.GetComponent<Collider>().Raycast(ray, out temp, Vector3.Distance(fromPos, toPos));
        }
    }
}
