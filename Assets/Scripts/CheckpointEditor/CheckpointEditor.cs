using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class CheckpointEditor : MonoBehaviour {

    private bool IsEdit = false;
    private Ray ray;
    private RaycastHit hit;
    private Rect rect = new Rect(1, 50, 120, 35);
    private GameObject _Spawn;
    private GameObject _Finish;
    //----------------------------------------------
    public GameObject prefab;
    public GameObject terrain;

    void Start ()
    {

    }

    void Update()
    {
        if (IsEdit)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (terrain.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
                {
                    Instantiate(prefab, new Vector3(hit.point.x, hit.point.y + (prefab.transform.localScale.y / 2), hit.point.z), Quaternion.identity);
                    GameObject obj = CheckpointScript.CreateCheckpointObject(new Vector3(hit.point.x, hit.point.y + (prefab.transform.localScale.y / 2), hit.point.z));
                    LevelControllerScript.Get().AddCheckpoint(obj);
                }
            }
        }
    }

    public void EditCheckpoints()
    {
        if (!IsEdit)
        {
            IsEdit = !IsEdit;
        }
        else
        {
            IsEdit = !IsEdit;
        }
    }
}
