using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    /// <summary>
    /// Stores name, type and other data (max health, damage, ...) of player unit.
    /// </summary>
    [Serializable]
    class PlayerUnit
    {
        [SerializeField] private string _name;
        /// <summary>
        /// Gets or sets name of player unit.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [SerializeField] private PlayerUnitType _unitType;
        /// <summary>
        /// Gets or sets type of player unit.
        /// </summary>
        public PlayerUnitType UnitType
        {
            get { return _unitType; }
            set { _unitType = value; }
        }

        [SerializeField] private float _maxHealth;
        /// <summary>
        /// Gets or sets max health of player unit.
        /// </summary>
        public float MaxHealth
        {
            get { return _maxHealth; }
            set { _maxHealth = value; }
        }

        [SerializeField] private float _damage;
        /// <summary>
        /// Gets or sets damage value of player unit.
        /// </summary>
        public float Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }

        [SerializeField] private float _armor;
        /// <summary>
        /// Gets or sets armor value of player unit.
        /// </summary>
        public float Armor
        {
            get { return _armor; }
            set { _armor = value; }
        }

        [SerializeField] private float _attackSpeed;
        /// <summary>
        /// Gets or sets attack speed of player unit.
        /// </summary>
        public float AttackSpeed
        {
            get { return _attackSpeed; }
            set { _attackSpeed = value; }
        }

        [SerializeField] private float _moveSpeed;
        /// <summary>
        /// Gets or sets move speed of player unit.
        /// </summary>
        public float MoveSpeed
        {
            get { return _moveSpeed; }
            set { _moveSpeed = value; }
        }

        [SerializeField] private float _spawnCooldown;
        /// <summary>
        /// Gets or sets spawn cooldown time of player unit.
        /// </summary>
        public float SpawnCooldown
        {
            get { return _spawnCooldown; }
            set { _spawnCooldown = value; }
        }

        /// <summary>
        /// Creates player unit with default values of properties.
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
        /// Creates player unit with specific values of properties.
        /// </summary>
        /// <param name="name">Name of player unit</param>
        /// <param name="unitType">Type of player unit</param>
        /// <param name="maxHealth">Max health of player unit</param>
        /// <param name="damage">Damage of player unit</param>
        /// <param name="armor">Armor of player unit</param>
        /// <param name="attactSpeed">Attack speed of player unit</param>
        /// <param name="moveSpeed">Move speed of player unit</param>
        /// <param name="spawnCooldown">Spawn cooldown time of player unit</param>
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
