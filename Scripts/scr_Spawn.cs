using UnityEngine;
using System.Collections;

public class scr_Spawn : MonoBehaviour
{
	[HideInInspector]
	public short Route = 0;					// cislo cesty, ktora bude najblizsie priradena
	public Transform[] NextPos;				// pole pozicii prvych checkpointov
	[HideInInspector]
	public GameObject GlobalController;		// referencia na globalny objekt

	// Use this for initialization
	void Start () 
	{
		GlobalController = GameObject.Find("globalController");
	}
	
	// Update is called once per frame
	void Update () {}
}
