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
            if (StartSpawnScript.Get().PlayerUnitCooldowns[PlayerUnitType.Axeman] <= 0f)
            {
                if (GUI.Button(new Rect(1, 50, 70, 22), "Axeman"))
                {
                    StartSpawnScript.Get().SpawnPlayerUnit(PlayerUnitType.Axeman);
                }
            }
            if (StartSpawnScript.Get().PlayerUnitCooldowns[PlayerUnitType.Bowman] <= 0f)
            {
                if (GUI.Button(new Rect(1, 80, 70, 22), "Bowman"))
                {
                    StartSpawnScript.Get().SpawnPlayerUnit(PlayerUnitType.Bowman);
                }
            }
            if (StartSpawnScript.Get().PlayerUnitCooldowns[PlayerUnitType.Crossbowman] <= 0f)
            {
                if (GUI.Button(new Rect(1, 110, 70, 22), "Crossbowman"))
                {
                    StartSpawnScript.Get().SpawnPlayerUnit(PlayerUnitType.Crossbowman);
                }
            }
            if (StartSpawnScript.Get().PlayerUnitCooldowns[PlayerUnitType.Knight] <= 0f)
            {
                if (GUI.Button(new Rect(1, 140, 70, 22), "Knight"))
                {
                    StartSpawnScript.Get().SpawnPlayerUnit(PlayerUnitType.Knight);
                }
            }
            if (StartSpawnScript.Get().PlayerUnitCooldowns[PlayerUnitType.Spearman] <= 0f)
            {
                if (GUI.Button(new Rect(1, 170, 70, 22), "Spearman"))
                {
                    StartSpawnScript.Get().SpawnPlayerUnit(PlayerUnitType.Spearman);
                }
            }
            if (StartSpawnScript.Get().PlayerUnitCooldowns[PlayerUnitType.Warrior] <= 0f)
            {
                if (GUI.Button(new Rect(1, 200, 70, 22), "Warrior"))
                {
                    StartSpawnScript.Get().SpawnPlayerUnit(PlayerUnitType.Warrior);
                }
            }
        }
    }
}
