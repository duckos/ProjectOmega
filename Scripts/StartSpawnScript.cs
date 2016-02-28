using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Spawns new player units and sets their first checkpoint or finish path if no checkpoint exists.
    /// </summary>
    class StartSpawnScript : MonoBehaviour
    {
        private Dictionary<PlayerUnitType, float> _playerUnitCooldowns = new Dictionary<PlayerUnitType, float>();
        /// <summary>
        /// Gets or sets remaining cooldown spawn time of player units.
        /// </summary>
        public Dictionary<PlayerUnitType, float> PlayerUnitCooldowns
        {
            get { return _playerUnitCooldowns; }
            protected set { _playerUnitCooldowns = value; }
        }

        private int _pathIndex = 0;

        /// <summary>
        /// Start method of unity script.
        /// </summary>
        public void Start()
        {
            this.gameObject.name = "StartSpawn";
            foreach (PlayerUnit playerUnit in GlobalControllerScript.Get().PlayerUnitStats)
            {
                PlayerUnitCooldowns.Add(playerUnit.UnitType, 0f);
            }
        }

        /// <summary>
        /// Update method of unity script.
        /// </summary>
        public void Update()
        {
            List<PlayerUnitType> keys = PlayerUnitCooldowns.Keys.ToList();
            foreach (PlayerUnitType key in keys)
            {
                if (PlayerUnitCooldowns[key] > 0f)
                {
                    PlayerUnitCooldowns[key] -= Time.deltaTime;
                }
            }
        }

        /// <summary>
        /// Spawns new player unit of specific type and sets spawn cooldown for next player unit of that type.
        /// </summary>
        /// <param name="unitType">Type of player unit to be spawned</param>
        public void SpawnPlayerUnit(PlayerUnitType unitType)
        {
            if (PlayerUnitCooldowns[unitType] > 0f)
            {
                throw new Exception("Could not spawn player unit, cooldown has not finished yet.");
            }

            GameObject prefab = GlobalControllerScript.Get().GetPlayerUnitPrefab(unitType);
            PlayerUnit playerUnit = GlobalControllerScript.Get().FindPlayerUnit(unitType);
            PlayerUnitCooldowns[unitType] = playerUnit.SpawnCooldown;

            GameObject instance = (GameObject) Instantiate(prefab, this.gameObject.transform.position, Quaternion.identity);
            PlayerUnitScript playerUnitScript = instance.AddComponent<PlayerUnitScript>();

            playerUnitScript.UnitType = unitType;
            playerUnitScript.Health = playerUnit.MaxHealth;
            playerUnitScript.Damage = playerUnit.Damage;
            playerUnitScript.Armor = playerUnit.Armor;
            playerUnitScript.AttackSpeed = playerUnit.AttackSpeed;
            playerUnitScript.MoveSpeed = playerUnit.MoveSpeed;

            playerUnitScript.PathIndex = _pathIndex;
            _pathIndex = (_pathIndex + 1) % CheckpointScript.MiniCheckpointsCount;

            playerUnitScript.MoveToward(LevelControllerScript.Get().FindNextCheckpoint());
        }
    }
}
