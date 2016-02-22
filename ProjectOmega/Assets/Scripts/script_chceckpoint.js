#pragma strict

var chceckPoint : GameObject;
var nexPos : Transform;
var tower  : GameObject;
var range  : GameObject;


function Start () {

}

function Update () {
  if((tower != null) && (range != null))
  {
    if(range.GetComponent(script_range).isAttack == true)
    {
       nexPos = tower.transform;    
    }
    else
    {
      nexPos = chceckPoint.transform;
    }
  }

}