using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Manages GUI shown on screen.
    /// </summary>
    class ScreenManagerScript : MonoBehaviour
    {
        /// <summary>
        /// OnGUI method of unity script.
        /// </summary>
        public void OnGUI()
        {
            StartSpawnScript startSpawn = LevelControllerScript.Get().StartSpawn.GetComponent<StartSpawnScript>();
            if (startSpawn.PlayerUnitCooldowns[PlayerUnitType.Axeman] <= 0f)
            {
                if (GUI.Button(new Rect(1, 50, 70, 22), "Axeman"))
                {
                    startSpawn.SpawnPlayerUnit(PlayerUnitType.Axeman);
                }
            }
            if (startSpawn.PlayerUnitCooldowns[PlayerUnitType.Bowman] <= 0f)
            {
                if (GUI.Button(new Rect(1, 80, 70, 22), "Bowman"))
                {
                    startSpawn.SpawnPlayerUnit(PlayerUnitType.Bowman);
                }
            }
            if (startSpawn.PlayerUnitCooldowns[PlayerUnitType.Crossbowman] <= 0f)
            {
                if (GUI.Button(new Rect(1, 110, 70, 22), "Crossbowman"))
                {
                    startSpawn.SpawnPlayerUnit(PlayerUnitType.Crossbowman);
                }
            }
            if (startSpawn.PlayerUnitCooldowns[PlayerUnitType.Knight] <= 0f)
            {
                if (GUI.Button(new Rect(1, 140, 70, 22), "Knight"))
                {
                    startSpawn.SpawnPlayerUnit(PlayerUnitType.Knight);
                }
            }
            if (startSpawn.PlayerUnitCooldowns[PlayerUnitType.Spearman] <= 0f)
            {
                if (GUI.Button(new Rect(1, 170, 70, 22), "Spearman"))
                {
                    startSpawn.SpawnPlayerUnit(PlayerUnitType.Spearman);
                }
            }
            if (startSpawn.PlayerUnitCooldowns[PlayerUnitType.Warrior] <= 0f)
            {
                if (GUI.Button(new Rect(1, 200, 70, 22), "Warrior"))
                {
                    startSpawn.SpawnPlayerUnit(PlayerUnitType.Warrior);
                }
            }
        }
    }
}
