#pragma strict

var spawn : Transform;
var hrac : GameObject;
//var myCounter : float = 3.0;
//var mySetTime : float = 2.5;

function Start () {

}

function Update () {

}

function OnGUI () {

  //if (myCounter >= mySetTime) 
  //{

  	if (GUI.Button (Rect(10, 30, 80, 30), "Pajac"))
  	{
  
  	   
    	Instantiate (hrac, spawn.position, Quaternion.identity);
    	
       
    //	myCounter = 0.0;
  	}
  
  //myCounter += Time.deltaTime;
}
