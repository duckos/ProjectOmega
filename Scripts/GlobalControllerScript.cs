using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Stores global data passed between different scenes (unit upgrades / stats, prefab references, ...)
    /// </summary>
    class GlobalControllerScript : MonoBehaviour
    {
        [SerializeField] private List<PlayerUnit> _playerUnitStats = new List<PlayerUnit>();
        /// <summary>
        /// Gets or sets collection of stat / upgrade information about player units
        /// </summary>
        public List<PlayerUnit> PlayerUnitStats
        {
            get { return _playerUnitStats; }
            protected set { _playerUnitStats = value; }
        }

        public void Start()
        {
            DontDestroyOnLoad(this.gameObject);

            // for testing, will be loaded from file
            LoadTestStats();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitType"></param>
        /// <param name="newName"></param>
        public void UpdatePlayerUnitName(PlayerUnitType unitType, string newName)
        {
            PlayerUnit unit = FindPlayerUnit(unitType);
            unit.Name = newName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitType"></param>
        /// <param name="newMaxHealth"></param>
        public void UpdatePlayerUnitMaxHealth(PlayerUnitType unitType, float newMaxHealth)
        {
            PlayerUnit unit = FindPlayerUnit(unitType);
            unit.MaxHealth = newMaxHealth;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitType"></param>
        /// <param name="newDamage"></param>
        public void UpdatePlayerUnitDamage(PlayerUnitType unitType, float newDamage)
        {
            PlayerUnit unit = FindPlayerUnit(unitType);
            unit.Damage = newDamage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitType"></param>
        /// <param name="newArmor"></param>
        public void UpdatePlayerUnitArmor(PlayerUnitType unitType, float newArmor)
        {
            PlayerUnit unit = FindPlayerUnit(unitType);
            unit.Armor = newArmor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitType"></param>
        /// <param name="newAttackSpeed"></param>
        public void UpdatePlayerUnitAttactSpeed(PlayerUnitType unitType, float newAttackSpeed)
        {
            PlayerUnit unit = FindPlayerUnit(unitType);
            unit.AttackSpeed = newAttackSpeed;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitType"></param>
        /// <param name="newMoveSpeed"></param>
        public void UpdatePlayerUnitMoveSpeed(PlayerUnitType unitType, float newMoveSpeed)
        {
            PlayerUnit unit = FindPlayerUnit(unitType);
            unit.MoveSpeed = newMoveSpeed;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitType"></param>
        /// <param name="newSpawnCooldown"></param>
        public void UpdatePlayerUnitSpawnCooldown(PlayerUnitType unitType, float newSpawnCooldown)
        {
            PlayerUnit unit = FindPlayerUnit(unitType);
            unit.SpawnCooldown = newSpawnCooldown;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitType"></param>
        /// <returns></returns>
        private PlayerUnit FindPlayerUnit(PlayerUnitType unitType)
        {
            PlayerUnit unit = PlayerUnitStats.FirstOrDefault(t => t.UnitType == unitType);
            if (unit == null)
            {
                throw new PlayerUnitNotFoundException(unitType);
            }
            return unit;
        }

        private void LoadTestStats()
        {
            PlayerUnitStats.AddPlayerUnit(new PlayerUnit("Axeman", PlayerUnitType.Axeman, 175f, 7f, 7f, 4f, 4f, 50f));
            PlayerUnitStats.AddPlayerUnit(new PlayerUnit("Bowman", PlayerUnitType.Bowman, 100f, 5f, 4f, 5f, 6f, 25f));
            PlayerUnitStats.AddPlayerUnit(new PlayerUnit("Crossbowman", PlayerUnitType.Crossbowman, 100f, 5f, 4f, 5f, 6f, 25f));
            PlayerUnitStats.AddPlayerUnit(new PlayerUnit("Knight", PlayerUnitType.Knight, 250f, 10f, 10f, 3f, 3f, 50f));
            PlayerUnitStats.AddPlayerUnit(new PlayerUnit("Spearman", PlayerUnitType.Spearman, 150f, 7f, 5f, 5f, 5f, 25f));
            PlayerUnitStats.AddPlayerUnit(new PlayerUnit("Warrior", PlayerUnitType.Warrior, 100f, 5f, 5f, 5f, 5f, 25f));
        }
    }
}
