using UnityEngine;
using System.Collections;

public class scr_PlayerUnit : MonoBehaviour 
{
	public float Life = 1;									// zivot jednotky
	public unitTypes UnitType = unitTypes.none;				// typ jednotky
	public scr_GlobalController GlobalController = null;	// referencia na skript globalneho objektu
	private Transform NextPos = null;						// referencia na poziciu bodu, ku ktoremu ma ist
	public short Route;										// urcuje, po ktorej ceste sa jednotka vyda, napr. po zniceni veze

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () 
	{
		if (Life <= 0) 
		{
			Destroy(gameObject);
		}
		
		if (NextPos != null) 		// pohyb smerom k nasledujucemu CP alebo k vezi
		{
			transform.position = Vector3.MoveTowards(transform.position, NextPos.transform.position, 2 * Time.deltaTime);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		switch (other.gameObject.tag) 
		{
			case "checkpoint": NextPos = other.gameObject.GetComponent<scr_Checkpoint>().NextPos;		// vyberie referenciu na poziciu nasledujuceho bodu
							   break;
			case "tower": NextPos = other.gameObject.GetComponent<scr_Tower>().NextPosAfterTowerDeath;		// vyberie referenciu na poziciu dalsieho bodu po zniceni veze
						  break;
			case "spawn": scr_Spawn otherSpawnScript = other.gameObject.GetComponent<scr_Spawn>();		// referencia na skript spawnu
						  NextPos = otherSpawnScript.NextPos[otherSpawnScript.Route];		// vyberie referenciu na poziciu prveho CP
						  Route = otherSpawnScript.Route;			// ulozi si cislo cesty, po ktorej bude chodit
						  otherSpawnScript.Route = (short) ((otherSpawnScript.Route + 1) % otherSpawnScript.NextPos.Length);	// inkrementacia cisla cesty a modulo pocet ciest, modifikacia pre dalsie spawnute instancie						  
						  
						  if( (GlobalController == null) && (UnitType != unitTypes.none) )		// ziskanie referencie na skript globalneho objektu a nastavenie zivota jednotke
						  {
						  	  GlobalController = otherSpawnScript.GlobalController.GetComponent<scr_GlobalController>();		// skript globalneho objektu
						  	  Life = /*GlobalController*/otherSpawnScript.GlobalController.GetComponent<scr_GlobalController>().UnitUpgrades[(int) UnitType][(int) unitData.maxHP];
						  }						
						  break;
			case "finish": Destroy(gameObject);
						   break;
		}
	}
}
