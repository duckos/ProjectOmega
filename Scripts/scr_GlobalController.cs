using UnityEngine;
using System.Collections;
using System;

public class scr_GlobalController : MonoBehaviour
{
	public Unit[] UnitUpgrades = new Unit[Enum.GetNames(typeof(unitTypes)).Length];		// 2D pole statov jednotiek
	private int InShop = 0;																// uchovava stav o otvorenom "okne" upgradu
	private unitTypes UpgradingUnit = unitTypes.none;									// uchovava, ktora jednotka bude upgradovana

	// Use this for initialization
	void Start ()
	{
		GameObject.DontDestroyOnLoad(this.gameObject);

		// prerobit na loadovane zo suboru

		UnitUpgrades [(int)unitTypes.none].Name = unitTypes.none.ToString ();
		UnitUpgrades [(int) unitTypes.none][(int) unitData.maxHP] = 1;
		UnitUpgrades [(int) unitTypes.none][(int) unitData.damage] = 0;
		UnitUpgrades [(int) unitTypes.none][(int) unitData.armor] = 0;
		UnitUpgrades [(int) unitTypes.none][(int) unitData.attackSpeed] = 0;
		UnitUpgrades [(int) unitTypes.none][(int) unitData.moveSpeed] = 0;
		UnitUpgrades [(int) unitTypes.none][(int) unitData.cooldown] = 0;
		
		UnitUpgrades [(int)unitTypes.axeman].Name = unitTypes.axeman.ToString ();
		UnitUpgrades [(int) unitTypes.axeman][(int) unitData.maxHP] = 175;
		UnitUpgrades [(int) unitTypes.axeman][(int) unitData.damage] = 7;
		UnitUpgrades [(int) unitTypes.axeman][(int) unitData.armor] = 7;
		UnitUpgrades [(int) unitTypes.axeman][(int) unitData.attackSpeed] = 4;
		UnitUpgrades [(int) unitTypes.axeman][(int) unitData.moveSpeed] = 4;
		UnitUpgrades [(int) unitTypes.axeman][(int) unitData.cooldown] = 50;
		
		UnitUpgrades [(int)unitTypes.bowman].Name = unitTypes.bowman.ToString ();
		UnitUpgrades [(int) unitTypes.bowman][(int) unitData.maxHP] = 100;
		UnitUpgrades [(int) unitTypes.bowman][(int) unitData.damage] = 5;
		UnitUpgrades [(int) unitTypes.bowman][(int) unitData.armor] = 4;
		UnitUpgrades [(int) unitTypes.bowman][(int) unitData.attackSpeed] = 5;
		UnitUpgrades [(int) unitTypes.bowman][(int) unitData.moveSpeed] = 6;
		UnitUpgrades [(int) unitTypes.bowman][(int) unitData.cooldown] = 25;
		
		UnitUpgrades [(int)unitTypes.crossbowman].Name = unitTypes.crossbowman.ToString ();
		UnitUpgrades [(int) unitTypes.crossbowman][(int) unitData.maxHP] = 100;
		UnitUpgrades [(int) unitTypes.crossbowman][(int) unitData.damage] = 5;
		UnitUpgrades [(int) unitTypes.crossbowman][(int) unitData.armor] = 4;
		UnitUpgrades [(int) unitTypes.crossbowman][(int) unitData.attackSpeed] = 5;
		UnitUpgrades [(int) unitTypes.crossbowman][(int) unitData.moveSpeed] = 6;
		UnitUpgrades [(int) unitTypes.crossbowman][(int) unitData.cooldown] = 25;
		
		UnitUpgrades [(int)unitTypes.knight].Name = unitTypes.knight.ToString ();
		UnitUpgrades [(int) unitTypes.knight][(int) unitData.maxHP] = 250;
		UnitUpgrades [(int) unitTypes.knight][(int) unitData.damage] = 10;
		UnitUpgrades [(int) unitTypes.knight][(int) unitData.armor] = 10;
		UnitUpgrades [(int) unitTypes.knight][(int) unitData.attackSpeed] = 3;
		UnitUpgrades [(int) unitTypes.knight][(int) unitData.moveSpeed] = 3;
		UnitUpgrades [(int) unitTypes.knight][(int) unitData.cooldown] = 50;
		
		UnitUpgrades [(int)unitTypes.spearman].Name = unitTypes.spearman.ToString ();
		UnitUpgrades [(int) unitTypes.spearman][(int) unitData.maxHP] = 150;
		UnitUpgrades [(int) unitTypes.spearman][(int) unitData.damage] = 7;
		UnitUpgrades [(int) unitTypes.spearman][(int) unitData.armor] = 5;
		UnitUpgrades [(int) unitTypes.spearman][(int) unitData.attackSpeed] = 5;
		UnitUpgrades [(int) unitTypes.spearman][(int) unitData.moveSpeed] = 5;
		UnitUpgrades [(int) unitTypes.spearman][(int) unitData.cooldown] = 25;
		
		UnitUpgrades [(int)unitTypes.warrior].Name = unitTypes.warrior.ToString ();
		UnitUpgrades [(int) unitTypes.warrior][(int) unitData.maxHP] = 100;
		UnitUpgrades [(int) unitTypes.warrior][(int) unitData.damage] = 5;
		UnitUpgrades [(int) unitTypes.warrior][(int) unitData.armor] = 5;
		UnitUpgrades [(int) unitTypes.warrior][(int) unitData.attackSpeed] = 5;
		UnitUpgrades [(int) unitTypes.warrior][(int) unitData.moveSpeed] = 5;
		UnitUpgrades [(int) unitTypes.warrior][(int) unitData.cooldown] = 25;
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*if(Input.GetKeyDown(KeyCode.S))
		{
			InShop = 1;
		}*/
	}

	void OnGUI ()
	{
		if(InShop == 0)
		{
			if( GUI.Button(new Rect(10, 10, 80, 30), "Upgrade") )
			{
				InShop = 1;
			}
		}
		else if(InShop == 1)
		{			
			if( GUI.Button(new Rect(150, 10, 150, 20), "Upgrade warrior") )
			{
				UpgradingUnit = (unitTypes.warrior);
				InShop = 2;
			}
			if( GUI.Button(new Rect(150, 40, 150, 20), "Upgrade spearman") )
			{
				UpgradingUnit = (unitTypes.spearman);
				InShop = 2;
			}
			if( GUI.Button(new Rect(150, 70, 150, 20), "Upgrade axeman") )
			{
				UpgradingUnit = (unitTypes.axeman);
				InShop = 2;
			}
			if( GUI.Button(new Rect(150, 100, 150, 20), "Upgrade knight") )
			{
				UpgradingUnit = (unitTypes.knight);
				InShop = 2;
			}
			if( GUI.Button(new Rect(150, 130, 150, 20), "Upgrade crossbowman") )
			{
				UpgradingUnit = (unitTypes.crossbowman);
				InShop = 2;
			}
			if( GUI.Button(new Rect(150, 160, 150, 20), "Upgrade bowman") )
			{
				UpgradingUnit = (unitTypes.bowman);
				InShop = 2;
			}
			if( GUI.Button(new Rect(150, 190, 150, 20), "Cancel") )
			{
				InShop = 0;
			}
		}
		else if(InShop == 2)
		{
			if( GUI.Button(new Rect(150, 10, 150, 20), "Max HP") )
			{
				UpgradeUnitStat(unitData.maxHP);
			}
			if( GUI.Button(new Rect(150, 40, 150, 20), "Damage") )
			{
				UpgradeUnitStat(unitData.damage);
			}
			if( GUI.Button(new Rect(150, 70, 150, 20), "Armor") )
			{
				UpgradeUnitStat(unitData.armor);
			}
			if( GUI.Button(new Rect(150, 100, 150, 20), "Attack speed") )
			{
				UpgradeUnitStat(unitData.attackSpeed);
			}
			if( GUI.Button(new Rect(150, 130, 150, 20), "Movement speed") )
			{
				UpgradeUnitStat(unitData.moveSpeed);
			}
			if( GUI.Button(new Rect(150, 160, 150, 20), "Back") )
			{
				InShop = 1;
				UpgradingUnit = unitTypes.none;
			}
		}
	}

	private void UpgradeUnitStat(unitData stat)
	{
		UnitUpgrades [(int) UpgradingUnit][(int)stat] *= (float) 1.25;
		InShop = 0;
		UpgradingUnit = unitTypes.none;
	}
}

public enum unitTypes
{
	none,
	warrior,
	spearman,
	axeman,
	knight,
	crossbowman,
	bowman
}

public enum unitData
{
	maxHP,
	damage,
	armor,
	attackSpeed,
	moveSpeed,
	cooldown
}

[System.Serializable]
public class Unit		// trieda obsahujuca info o max HP, damage, armor, attack speed a move speed konkretneho typu jednotky aj s jej menom
{
	[HideInInspector]
	public string Name;																// pomenovanie typu jednotky
	public float[] Data = new float[Enum.GetNames(typeof(unitData)).Length];		// data o jednotke

	public float this[int index]
	{
		get { return Data[index]; }
		set { Data [index] = value; }
	}

	public int Length
	{
		get { return Data.Length; }
	}

	public long LongLength
	{
		get { return Data.LongLength; }
	}
}
