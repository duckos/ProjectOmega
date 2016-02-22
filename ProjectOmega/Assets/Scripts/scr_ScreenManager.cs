using UnityEngine;
using System.Collections;
using System;

public class scr_ScreenManager : MonoBehaviour
{
	public Transform SpawnPosition;														// referencia na poziciu spawnu
	public GameObject PlayerUnitObject;													// referencia na objekt hracovej jednotky
	private GameObject CreatedUnitObject;												// referencia na vytvorenu instanciu jednotky
	private float[] Cooldowns = new float[Enum.GetNames(typeof(unitTypes)).Length];		// cooldown spawnovania jednotiek
	private scr_GlobalController GlobalController;										// referencia na skript glovalneho objektu

	// Use this for initialization
	void Start () 
	{
		GlobalController = GameObject.Find ("globalController").GetComponent<scr_GlobalController>();

		for(int i = 0; i < Cooldowns.Length; ++i)
		{
			Cooldowns[i] = 0;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		for(int i = 0; i < Cooldowns.Length; ++i)
		{
			if(Cooldowns[i] > 0)
			{
				Cooldowns[i] -= 1;
			}
		}
	}

	void OnGUI ()
	{
		if(Cooldowns[(int) unitTypes.warrior] <= 0)
		{
			if ( GUI.Button(new Rect(1, 50, 70, 22), "Warrior") )
			{
				CreatedUnitObject = (GameObject) Instantiate(PlayerUnitObject, SpawnPosition.position, Quaternion.identity);
				CreatedUnitObject.GetComponent<scr_PlayerUnit>().UnitType = unitTypes.warrior;
				Cooldowns[(int) unitTypes.warrior] = GlobalController.UnitUpgrades[(int) unitTypes.warrior][(int) unitData.cooldown];
			}
		}
		if(Cooldowns[(int) unitTypes.spearman] <= 0)
		{
			if ( GUI.Button(new Rect(1, 80, 70, 22), "Spearman") )
			{
				CreatedUnitObject = (GameObject) Instantiate(PlayerUnitObject, SpawnPosition.position, Quaternion.identity);
				CreatedUnitObject.GetComponent<scr_PlayerUnit>().UnitType = unitTypes.spearman;
				Cooldowns[(int) unitTypes.spearman] = GlobalController.UnitUpgrades[(int) unitTypes.spearman][(int) unitData.cooldown];
			}
		}
		if(Cooldowns[(int) unitTypes.axeman] <= 0)
		{
			if ( GUI.Button(new Rect(1, 110, 70, 22), "Axeman") )
			{
				CreatedUnitObject = (GameObject) Instantiate(PlayerUnitObject, SpawnPosition.position, Quaternion.identity);
				CreatedUnitObject.GetComponent<scr_PlayerUnit>().UnitType = unitTypes.axeman;
				Cooldowns[(int) unitTypes.axeman] = GlobalController.UnitUpgrades[(int) unitTypes.axeman][(int) unitData.cooldown];
			}
		}
		if(Cooldowns[(int) unitTypes.knight] <= 0)
		{
			if ( GUI.Button(new Rect(1, 140, 70, 22), "Knight") )
			{
				CreatedUnitObject = (GameObject) Instantiate(PlayerUnitObject, SpawnPosition.position, Quaternion.identity);
				CreatedUnitObject.GetComponent<scr_PlayerUnit>().UnitType = unitTypes.knight;
				Cooldowns[(int) unitTypes.knight] = GlobalController.UnitUpgrades[(int) unitTypes.knight][(int) unitData.cooldown];
			}
		}
		if(Cooldowns[(int) unitTypes.crossbowman] <= 0)
		{
			if ( GUI.Button(new Rect(1, 170, 70, 22), "Crossbowman") )
			{
				CreatedUnitObject = (GameObject) Instantiate(PlayerUnitObject, SpawnPosition.position, Quaternion.identity);
				CreatedUnitObject.GetComponent<scr_PlayerUnit>().UnitType = unitTypes.crossbowman;
				Cooldowns[(int) unitTypes.crossbowman] = GlobalController.UnitUpgrades[(int) unitTypes.crossbowman][(int) unitData.cooldown];
			}
		}
		if(Cooldowns[(int) unitTypes.bowman] <= 0)
		{
			if ( GUI.Button(new Rect(1, 200, 70, 22), "Bowman") )
			{
				CreatedUnitObject = (GameObject) Instantiate(PlayerUnitObject, SpawnPosition.position, Quaternion.identity);
				CreatedUnitObject.GetComponent<scr_PlayerUnit>().UnitType = unitTypes.bowman;
				Cooldowns[(int) unitTypes.bowman] = GlobalController.UnitUpgrades[(int) unitTypes.bowman][(int) unitData.cooldown];
			}
		}
	}
}
