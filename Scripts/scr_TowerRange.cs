using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class scr_TowerRange : MonoBehaviour
{
	public GameObject BulletObject;										// referencia objektu projektilu, podla ktorej budu vytvarane dalsie
	public Transform BulletSpawnPoint;									// referencia na poziciu, kde sa budu vytvarat projektily
	private GameObject CreatedBulletInstance;							// referencia na projektil vytvoreny pri vystrele
	public float TimeToFire;											// cas do dalsieho vystrelu
	public float ReloadTime;											// cas reloadu
	public Transform Tower;												// referencia na "matersku" vezu
	private Vector3 ScreenPoint;										// suradnice veze na obrazovke
	[HideInInspector]
	public bool TowerIsClicked = false;									// true - bolo kliknute na instanciu objektu
	[HideInInspector]
	public bool TowerIsAttacked = false;								// true - hracove jednotky utocia na vezu
	[HideInInspector]
	public List<GameObject> AttackingList = new List<GameObject> ();	// list referencii na objekty, na ktore veza utoci
	
	// Use this for initialization
	void Start ()
	{
		TimeToFire = Time.time;//(float) 0.0;
		ReloadTime = (float) 1.0;

		ScreenPoint = Camera.main.WorldToScreenPoint (Tower.position);
		Vector3 temp = ScreenPoint;
		temp.y = Screen.height - ScreenPoint.y;
		ScreenPoint = temp;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (AttackingList.Count > 0) 
		{
			if (AttackingList[0] != null)		// vystrelenie projektilu na prvu hracovu jednotku v liste ak existuje
			{
				if (Time.time >= TimeToFire)		// vystrelenie, ak je reloadnute
				{
					CreatedBulletInstance = (GameObject) Instantiate(BulletObject, BulletSpawnPoint.position, Quaternion.identity);
					TimeToFire = Time.time + ReloadTime;
					CreatedBulletInstance.GetComponent<scr_Bullet>().Attacking = AttackingList[0];
					CreatedBulletInstance.GetComponent<scr_Bullet>().AttackingPlayer = true;
					// pripadne dalsie nastavovania projektilu
				}
			}
			else 			// odstranenie null referencie na uz znicenu hracovu jednotku na indexe 0
			{
				AttackingList.RemoveAt(0);
			}
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "player") 		// pridanie hracovej jednotky do listu
		{
			AttackingList.Add(other.gameObject);
		}
	}

	void OnTriggerExit (Collider other)
	{
		AttackingList.RemoveAt(0);			// odstranenie prvej hracovej jednotky z listu
	}

	void OnMouseDown ()
	{
		TowerIsClicked = true;		// bolo kliknute na vezicku
	}

	void OnGUI ()
	{
		if (TowerIsClicked) 		// bolo kliknute na vezicku
		{
			if (!TowerIsAttacked)		// na vezu sa neutoci
			{
				if ( GUI.Button(new Rect(ScreenPoint.x, ScreenPoint.y, 50, 50), "Utok") )		// bolo stlacene tlacidlo na utok
				{
					TowerIsAttacked = true;
					TowerIsClicked = false;
				}
			}
			else 			// na vezu sa utoci
			{
				if ( GUI.Button(new Rect(ScreenPoint.x, ScreenPoint.y, 50, 50), "Neutoc") )		// bolo stlacene tlacidlo na neutocenie
				{
					TowerIsAttacked = false;
					TowerIsClicked = false;
				}
			}

			if ( GUI.Button(new Rect(ScreenPoint.x + 60, ScreenPoint.y, 50, 50), "Zrus") )		// bolo stlacene tlacidlo na zrusenie vyberu
			{
				TowerIsClicked = false;
			}
		}
	}
}
