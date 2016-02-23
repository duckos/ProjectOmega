using UnityEngine;
using System.Collections;

public class scr_Checkpoint : MonoBehaviour
{
	[HideInInspector]
	public Transform NextPos;		// referencia na poziciu, kam ma utociaca jednotka ist
	public Transform NextCP;		// referencia na poziciu nasledujuceho CP
	public Transform NextTower;		// referencia na poziciu nasledujucej veze
	public GameObject Range;		// referencia na objekt dostrelu veze

	// Use this for initialization
	void Start ()
	{
		NextPos = NextCP;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if ((NextTower != null) && (Range != null)) 
		{
			if (Range.GetComponent<scr_TowerRange>().TowerIsAttacked)		// utok na vezu, ak sa na nu ma utocit
			{
				NextPos = NextTower;
			}
			else
			{
				NextPos = NextCP;
			}
		}
	}
}
