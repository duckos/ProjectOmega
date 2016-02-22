using UnityEngine;
using System.Collections;

public class scr_Bullet : MonoBehaviour
{
	[HideInInspector]
	public GameObject Attacking = null;		// referencia na objekt, na ktory bol projektil vystreleny
	[HideInInspector]
	public bool AttackingPlayer;			// true - zranuje hracove jednotky; false - zranuje nepriatelove NPC jednotky
	public float Damage; 					// volkost sposobeneho poskodenia projektilu
	public float Speed; 					// rychlost projektilu

	// Use this for initialization
	void Start ()
	{
		Damage = 30;
		Speed = 10;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Attacking != null) 		// pohyb smerom k objektu, na ktory bol projektil vystreleny
		{
			gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Attacking.transform.position, Speed * Time.deltaTime);
		}
		else 			// dany ciel uz neexistuje, znicenie projektilu
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (AttackingPlayer) 		// cielom je hracova jednotka
		{
			if (other.gameObject.tag == "player")		// projektil zasiahol hracovu jednotku
			{
				other.gameObject.GetComponent<scr_PlayerUnit>().Life -= Damage;
				Destroy(gameObject);
			}
		}
		else 			// cielom je nepriatelova NPC jednotka
		{
			// dokoncenie skriptu
		}
	}
}
