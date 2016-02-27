using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Stores global data passed between different scenes (unit upgrades / stats, prefab references, ...).
    /// </summary>
    class GlobalControllerScript : MonoBehaviour
    {
        private static GlobalControllerScript _instance;
        /// <summary>
        /// Returns instance of global controller.
        /// </summary>
        /// <returns>Global controller instance</returns>
        public static GlobalControllerScript Get()
        {
            return _instance ?? (_instance = FindObjectOfType<GlobalControllerScript>());
        }

        [SerializeField] private List<PlayerUnit> _playerUnitStats = new List<PlayerUnit>();
        /// <summary>
        /// Gets or sets collection of stats / upgrades information about player units.
        /// </summary>
        public List<PlayerUnit> PlayerUnitStats
        {
            get { return _playerUnitStats; }
            protected set { _playerUnitStats = value; }
        }

        [SerializeField] private GameObject _warrior;
        [SerializeField] private GameObject _spearman;
        [SerializeField] private GameObject _axeman;
        [SerializeField] private GameObject _knight;
        [SerializeField] private GameObject _crossbowman;
        [SerializeField] private GameObject _bowman;

        /// <summary>
        /// Start method of unity script.
        /// </summary>
        public void Start()
        {
            DontDestroyOnLoad(this.gameObject);

            // for testing, will be loaded from file
            LoadTestStats();

            // testovanie funkcnosti level controllerov
            TestLevelControllers();
        }

        /// <summary>
        /// Returns reference on player unit prefab of specific type.
        /// </summary>
        /// <param name="unitType">Type of player unit prefab to be found</param>
        /// <returns></returns>
        public GameObject GetPlayerUnitPrefab(PlayerUnitType unitType)
        {
            switch (unitType)
            {
                case PlayerUnitType.Warrior:
                    return _warrior;
                case PlayerUnitType.Spearman:
                    return _spearman;
                case PlayerUnitType.Axeman:
                    return _axeman;
                case PlayerUnitType.Knight:
                    return _knight;
                case PlayerUnitType.Crossbowman:
                    return _crossbowman;
                case PlayerUnitType.Bowman:
                    return _bowman;
                default:
                    throw new PlayerUnitPrefabNotFoundException(unitType);
            }
        }

        /// <summary>
        /// Sets reference on player unit prefab of specific type.
        /// </summary>
        /// <param name="unitType">Player unit type of prefab to be set</param>
        /// <param name="prefab">Reference on prefab</param>
        public void SetPlayerUnitPrefab(PlayerUnitType unitType, GameObject prefab)
        {
            if (prefab == null)
            {
                throw new ArgumentNullException("prefab");
            }

            switch (unitType)
            {
                case PlayerUnitType.Warrior:
                    _warrior = prefab;
                    break;
                case PlayerUnitType.Spearman:
                    _spearman = prefab;
                    break;
                case PlayerUnitType.Axeman:
                    _axeman = prefab;
                    break;
                case PlayerUnitType.Knight:
                    _knight = prefab;
                    break;
                case PlayerUnitType.Crossbowman:
                    _crossbowman = prefab;
                    break;
                case PlayerUnitType.Bowman:
                    _bowman = prefab;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("unitType", unitType, "Unknown player unit type " + unitType + ".");
            }
        }

        /// <summary>
        /// Updates name of player unit of specific type.
        /// </summary>
        /// <param name="unitType">Type of player unit to be updated</param>
        /// <param name="newName">New name of player unit</param>
        public void UpdatePlayerUnitName(PlayerUnitType unitType, string newName)
        {
            PlayerUnit unit = FindPlayerUnit(unitType);
            unit.Name = newName;
        }

        /// <summary>
        /// Updates max health of player unit of specific type.
        /// </summary>
        /// <param name="unitType">Type of player unit to be updated</param>
        /// <param name="newMaxHealth">New max health of player unit</param>
        public void UpdatePlayerUnitMaxHealth(PlayerUnitType unitType, float newMaxHealth)
        {
            PlayerUnit unit = FindPlayerUnit(unitType);
            unit.MaxHealth = newMaxHealth;
        }

        /// <summary>
        /// Updates damage value of player unit of specific type.
        /// </summary>
        /// <param name="unitType">Type of player unit to be updated</param>
        /// <param name="newDamage">New damage of player unit</param>
        public void UpdatePlayerUnitDamage(PlayerUnitType unitType, float newDamage)
        {
            PlayerUnit unit = FindPlayerUnit(unitType);
            unit.Damage = newDamage;
        }

        /// <summary>
        /// Updates armor value of player unit od specific type.
        /// </summary>
        /// <param name="unitType">Type of player unit to be updated</param>
        /// <param name="newArmor">New armor of player unit</param>
        public void UpdatePlayerUnitArmor(PlayerUnitType unitType, float newArmor)
        {
            PlayerUnit unit = FindPlayerUnit(unitType);
            unit.Armor = newArmor;
        }

        /// <summary>
        /// Updates attack speed of player unit od specific type.
        /// </summary>
        /// <param name="unitType">Type of player unit to be updated</param>
        /// <param name="newAttackSpeed">New attack speed of player unit</param>
        public void UpdatePlayerUnitAttactSpeed(PlayerUnitType unitType, float newAttackSpeed)
        {
            PlayerUnit unit = FindPlayerUnit(unitType);
            unit.AttackSpeed = newAttackSpeed;
        }

        /// <summary>
        /// Updates move speed of player unit of specific type.
        /// </summary>
        /// <param name="unitType">Type of player unit to be updated</param>
        /// <param name="newMoveSpeed">New move speed of player unit</param>
        public void UpdatePlayerUnitMoveSpeed(PlayerUnitType unitType, float newMoveSpeed)
        {
            PlayerUnit unit = FindPlayerUnit(unitType);
            unit.MoveSpeed = newMoveSpeed;
        }

        /// <summary>
        /// Updates spawn cooldown time of player unit of specific type.
        /// </summary>
        /// <param name="unitType">Type of player unit to be updated</param>
        /// <param name="newSpawnCooldown">New spawn cooldown time of player unit</param>
        public void UpdatePlayerUnitSpawnCooldown(PlayerUnitType unitType, float newSpawnCooldown)
        {
            PlayerUnit unit = FindPlayerUnit(unitType);
            unit.SpawnCooldown = newSpawnCooldown;
        }

        /// <summary>
        /// Finds and returns player unit of specific type.
        /// </summary>
        /// <param name="unitType">Type of player unit to be found</param>
        /// <returns>Player unit of given type</returns>
        public PlayerUnit FindPlayerUnit(PlayerUnitType unitType)
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
            PlayerUnitStats.AddPlayerUnit(new PlayerUnit("Axeman", PlayerUnitType.Axeman, 175f, 7f, 7f, 4f, 4f, 1.5f));
            PlayerUnitStats.AddPlayerUnit(new PlayerUnit("Bowman", PlayerUnitType.Bowman, 100f, 5f, 4f, 5f, 6f, 1f));
            PlayerUnitStats.AddPlayerUnit(new PlayerUnit("Crossbowman", PlayerUnitType.Crossbowman, 100f, 5f, 4f, 5f, 6f, 1f));
            PlayerUnitStats.AddPlayerUnit(new PlayerUnit("Knight", PlayerUnitType.Knight, 250f, 10f, 10f, 3f, 3f, 2.5f));
            PlayerUnitStats.AddPlayerUnit(new PlayerUnit("Spearman", PlayerUnitType.Spearman, 150f, 7f, 5f, 5f, 5f, 1.25f));
            PlayerUnitStats.AddPlayerUnit(new PlayerUnit("Warrior", PlayerUnitType.Warrior, 100f, 5f, 5f, 5f, 5f, 1.1f));
        }

        private void TestLevelControllers()
        {
            //GameObject test01 = new GameObject("test01");
            //test01.AddComponent<LevelTest01ControllerScript>();
            GameObject test02 = new GameObject("test02");
            test02.AddComponent<LevelTest02ControllerScript>();
        }
    }
}
