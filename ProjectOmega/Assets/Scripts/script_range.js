#pragma strict
var bullet : GameObject;
var bullet_spawn : Transform;
var bullet_reference : GameObject;
var next_fire_time : float = 0.0;
var reload_time : float = 1.0;
var soldiers = new Array();
var isAttack         : boolean = false;
var isClicked        : boolean = false;
var point            : Vector3;
var tower            : Transform;

function Start () {
    point = Camera.main.WorldToScreenPoint(tower.position);
    if(point.y > 0)
    {
       point.y = Screen.height - point.y; 
    }
}

function Update () {


   if(soldiers.length > 0)
   {
     if(soldiers[0])
     {
      	if(Time.time >= next_fire_time){
     
         	bullet_reference = Instantiate (bullet, bullet_spawn.position, Quaternion.identity);
         	next_fire_time = Time.time + reload_time;
         	bullet_reference.GetComponent(script_bullet).enemy_object = soldiers[0];
      	}
      
      }
      else
      {
         removeSoldier();
      }
    }
}

function OnTriggerEnter (other : Collider){
      
      
      if(other.gameObject.tag == "player")
      {
        addSoldier(other.gameObject);
      }

}

function OnTriggerExit (other : Collider) {
      
      
      if(other.gameObject.tag == "player")
      {
        removeSoldier();
      }
}

function addSoldier(position : GameObject)
{
  soldiers[soldiers.length] = position;
}

function removeSoldier()
{
  soldiers.splice(0,1);
}
function OnMouseDown()
{
  //isAttack = !isAttack;
  isClicked = true;
}
function OnGUI()
{
   if(isClicked)
   {
     if(!isAttack)
     {
      if( GUI.Button(Rect(point.x, point.y, 50, 50),"Utok"))
      {
         isAttack = !isAttack;
         isClicked = false;
      }
     }
     else
     {
      if( GUI.Button(Rect(point.x, point.y, 50, 50),"Neutoc"))
      {
         isAttack = !isAttack;
         isClicked = false;
      }
     }
      if(GUI.Button(Rect(point.x + 60, point.y, 50, 50),"Zrus"))
      {
          isClicked = false;
      }
     
   }
}

