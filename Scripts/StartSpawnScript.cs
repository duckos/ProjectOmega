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
        private static StartSpawnScript _instance;
        /// <summary>
        /// Returns instance of start spawn.
        /// </summary>
        /// <returns>Start spawn instance</returns>
        public static StartSpawnScript Get()
        {
            return _instance ?? (_instance = FindObjectOfType<StartSpawnScript>());
        }
        
        private Dictionary<PlayerUnitType, float> _playerUnitCooldowns = new Dictionary<PlayerUnitType, float>();
        /// <summary>
        /// Gets or sets remaining cooldown spawn time of player units.
        /// </summary>
        public Dictionary<PlayerUnitType, float> PlayerUnitCooldowns
        {
            get { return _playerUnitCooldowns; }
            protected set { _playerUnitCooldowns = value; }
        }

        /// <summary>
        /// Start method of unity script.
        /// </summary>
        public void Start()
        {
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
                return;
            }

            GameObject prefab = GlobalControllerScript.Get().GetPlayerUnitPrefab(unitType);
            PlayerUnitCooldowns[unitType] = GlobalControllerScript.Get().FindPlayerUnit(unitType).SpawnCooldown;
            GameObject instance = (GameObject) Instantiate(prefab, this.gameObject.transform.position, Quaternion.identity);

            // TODO: ziskanie skriptu instancie a nastavenie properties
        }
    }
}
