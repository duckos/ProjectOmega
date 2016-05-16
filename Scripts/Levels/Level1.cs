using UnityEngine;
using System.Collections;
using Assets.Scripts;

class Level1 : LevelControllerScript
{ 
    void Start()
    {
        var _Spawn = GameObject.Find("spawn");
        var _Finish = GameObject.Find("finish");
        StartSpawn = _Spawn;
        Finish = _Finish;
    }
}
