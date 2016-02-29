using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Player unit object.
    /// </summary>
    class PlayerUnitScript : MonoBehaviour
    {
        [SerializeField] private PlayerUnitType _unitType = PlayerUnitType.None;
        /// <summary>
        /// Gets or sets type of player unit.
        /// </summary>
        public PlayerUnitType UnitType
        {
            get { return _unitType; }
            set { _unitType = value; }
        }

        [SerializeField] private float _health = 10f;
        /// <summary>
        /// Gets or sets health of player unit.
        /// </summary>
        public float Health
        {
            get { return _health; }
            set { _health = value; }
        }

        [SerializeField] private float _damage = 1f;
        /// <summary>
        /// Gets or sets damage value of player unit.
        /// </summary>
        public float Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }

        [SerializeField] private float _armor = 1f;
        /// <summary>
        /// Gets or sets armor value of player unit.
        /// </summary>
        public float Armor
        {
            get { return _armor; }
            set { _armor = value; }
        }

        [SerializeField] private float _attackSpeed = 1f;
        /// <summary>
        /// Gets or sets attack speed of player unit.
        /// </summary>
        public float AttackSpeed
        {
            get { return _attackSpeed; }
            set { _attackSpeed = value; }
        }

        [SerializeField] private float _moveSpeed = 1f;
        /// <summary>
        /// Gets or sets move speed of player unit.
        /// </summary>
        public float MoveSpeed
        {
            get { return _moveSpeed; }
            set { _moveSpeed = value; }
        }

        [SerializeField] private int _pathIndex = 0;
        /// <summary>
        /// Gets or sets path index / index of mini checkpoint path.
        /// </summary>
        public int PathIndex
        {
            get { return _pathIndex; }
            set { _pathIndex = value; }
        }

        /// <summary>
        /// Gets or sets destination object to which is player unit moving.
        /// </summary>
        public GameObject Destination { get; protected set; }

        /// <summary>
        /// Start method of unity script.
        /// </summary>
        public void Start()
        {
            this.gameObject.name = "PlayerUnit";
        }

        /// <summary>
        /// Update method of unity script.
        /// </summary>
        public void Update()
        {
            if (Health <= 0f)
            {
                Destroy(this.gameObject);
            }

            if (Destination != null)
            {
                this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, Destination.name == "Checkpoint" 
                    ? Destination.GetComponent<CheckpointScript>().MiniCheckpoints[PathIndex].transform.position 
                    : Destination.transform.position, MoveSpeed * Time.deltaTime);
            }
        }

        /// <summary>
        /// OnTriggerEnter method of unity script.
        /// </summary>
        /// <param name="other">Other collider</param>
        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "MiniCheckpoint-" + PathIndex)
            {
                MoveToward(LevelControllerScript.Get().FindNextCheckpoint(other.gameObject.transform.parent.gameObject));
            }
            else if (other.gameObject.name == "Finish")
            {
                Destroy(this.gameObject);
            }
        }

        public void MoveToward(GameObject destination)
        {
            if (destination == null)
            {
                throw new ArgumentNullException("destination");
            }

            Destination = destination;
        }
    }
}
