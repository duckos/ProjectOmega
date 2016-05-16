using UnityEngine;
using System.Collections;

public class CameraMovementScript : MonoBehaviour {

    private float speed = 100.0f;
    private float rotationSpeed = 50.0f;

    void Update ()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Camera.main.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Camera.main.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Camera.main.transform.Translate(new Vector3(0, 1, 1) * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Camera.main.transform.Translate(new Vector3(0, -1, -1) * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * rotationSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed, Space.World);
        }
        Camera.main.fieldOfView += (float)(Input.GetAxis("Mouse ScrollWheel") * -5);

    }
}
