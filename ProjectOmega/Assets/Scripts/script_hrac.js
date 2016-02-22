#pragma strict

var chceck : Transform = null;
var life : float = 100;
var route: short;

function Start () {
    
  
}

function Update () {
    if(chceck != null)
    { 
      transform.position = Vector3.MoveTowards(transform.position, chceck.position, 2*Time.deltaTime);
    }
    if(life < 1)
    {
      Destroy(gameObject);
    }
}

function OnTriggerEnter (other : Collider){

      if(other.gameObject.tag == "chceckpoint") 
      {
       chceck = other.gameObject.GetComponent(script_chceckpoint).nexPos;
        
      } 
      else if(other.gameObject.tag == "spawn") 
      {
       this.route = other.gameObject.GetComponent(script_spawn).route;
       other.gameObject.GetComponent(script_spawn).route = (other.gameObject.GetComponent(script_spawn).route + 1) % 3 ;
       chceck = other.gameObject.GetComponent(script_spawn).nexPos[route];
        
      } 
      else if(other.gameObject.tag == "finish")
      {
        Destroy (gameObject);      
      }
      else if (other.gameObject.tag == "tower")
      {
        chceck = other.gameObject.GetComponent(script_tower).nextCpAfterDeath;
      }
      
}