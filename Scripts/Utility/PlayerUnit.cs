using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    /// <summary>
    /// Stores name, type and other data (max health, damage, ...) of player unit
    /// </summary>
    [Serializable]
    class PlayerUnit
    {
        [SerializeField] private string _name;
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [SerializeField] private PlayerUnitType _unitType;
        /// <summary>
        /// 
        /// </summary>
        public PlayerUnitType UnitType
        {
            get { return _unitType; }
            set { _unitType = value; }
        }

        [SerializeField] private float _maxHealth;
        /// <summary>
        /// 
        /// </summary>
        public float MaxHealth
        {
            get { return _maxHealth; }
            set { _maxHealth = value; }
        }

        [SerializeField] private float _damage;
        /// <summary>
        /// 
        /// </summary>
        public float Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }

        [SerializeField] private float _armor;
        /// <summary>
        /// 
        /// </summary>
        public float Armor
        {
            get { return _armor; }
            set { _armor = value; }
        }

        [SerializeField] private float _attackSpeed;
        /// <summary>
        /// 
        /// </summary>
        public float AttackSpeed
        {
            get { return _attackSpeed; }
            set { _attackSpeed = value; }
        }

        [SerializeField] private float _moveSpeed;
        /// <summary>
        /// 
        /// </summary>
        public float MoveSpeed
        {
            get { return _moveSpeed; }
            set { _moveSpeed = value; }
        }

        [SerializeField] private float _spawnCooldown;
        /// <summary>
        /// 
        /// </summary>
        public float SpawnCooldown
        {
            get { return _spawnCooldown; }
            set { _spawnCooldown = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public PlayerUnit()
        {
            Name = "N/A";
            UnitType = PlayerUnitType.None;
            MaxHealth = 10f;
            Damage = 1f;
            Armor = 1f;
            AttackSpeed = 1f;
            MoveSpeed = 1f;
            SpawnCooldown = 1f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="unitType"></param>
        /// <param name="maxHealth"></param>
        /// <param name="damage"></param>
        /// <param name="armor"></param>
        /// <param name="attactSpeed"></param>
        /// <param name="moveSpeed"></param>
        /// <param name="spawnCooldown"></param>
        public PlayerUnit(string name, PlayerUnitType unitType, float maxHealth, float damage, float armor, float attactSpeed, float moveSpeed, float spawnCooldown)
        {
            Name = name;
            UnitType = unitType;
            MaxHealth = maxHealth;
            Damage = damage;
            Armor = armor;
            AttackSpeed = attactSpeed;
            MoveSpeed = moveSpeed;
            SpawnCooldown = spawnCooldown;
        }
    }
}
