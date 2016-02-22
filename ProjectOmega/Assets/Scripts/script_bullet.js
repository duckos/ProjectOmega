#pragma strict

var enemy_object : GameObject = null;
var tower : GameObject = null;
var damage : float = 30.0;
var speed : float = 10.0;


function Start () {
   
}

function Update () {
     
     if(enemy_object != null)
     {
       transform.position = Vector3.MoveTowards(transform.position, enemy_object.transform.position, speed*Time.deltaTime);
     }
     else
     {
       Destroy(this.gameObject);
     }
     
     
}

function OnTriggerEnter (other : Collider){
      
      
      if(other.gameObject.tag == "player")
      {
        other.gameObject.GetComponent(script_hrac).life -= damage;
        Destroy (gameObject);
      }

}




