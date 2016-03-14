using UnityEngine;
using System.Collections;

public class CheckpointEditor : MonoBehaviour {

    private bool IsEdit = false;
    private Ray ray;
    private RaycastHit hit;
    public GameObject prefab;
    public GameObject terrain;
    private Rect rect = new Rect(1, 50, 120, 35);
    private float speed = 100.0f;
    private float rotationSpeed = 50.0f;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            //transform.position += Vector3.right * speed * Time.deltaTime;
            Camera.main.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //transform.position += Vector3.left * speed * Time.deltaTime;
            Camera.main.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            //transform.position += Vector3.forward * speed * Time.deltaTime;
            Camera.main.transform.Translate(new Vector3(0,1,1) * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //transform.position += Vector3.back * speed * Time.deltaTime;
            Camera.main.transform.Translate(new Vector3(0, -1, -1) * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * rotationSpeed,Space.World);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed, Space.World);
        }
        Camera.main.fieldOfView +=(float) (Input.GetAxis("Mouse ScrollWheel") * -5);

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (IsEdit)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && !ShouldIPlaceCkeckpoint())
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (terrain.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
                {
                    GameObject obj = Instantiate(prefab, new Vector3(hit.point.x, hit.point.y + (prefab.transform.localScale.y / 2), hit.point.z), Quaternion.identity) as GameObject;
                }
            }
        }
    }

    void OnGUI()
    {
        if (!IsEdit)
        {
            if (GUI.Button(rect, "Edit checkpoints"))
            {
                IsEdit = !IsEdit;
            }
        }
        else
        {
            if (GUI.Button(rect, "Finish editing"))
            {
                IsEdit = !IsEdit;
            }
        }
        
    }

    private bool ShouldIPlaceCkeckpoint()
    {
        Vector2 position = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
        return rect.Contains(position);
    }
}
