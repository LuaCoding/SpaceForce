using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    float amount = 0;
    void Update()
    {
        float s = 5f;

        // movement
        if (Input.GetKey(KeyCode.LeftShift))
            s *= 2f;

        Rigidbody rb = GetComponent<Rigidbody>();

        
        if (Input.GetKey(KeyCode.W))
            transform.position += transform.forward * s * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            transform.position += -transform.forward * s * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            transform.position += transform.right * s * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
            transform.position += -transform.right * s * Time.deltaTime;

        // jump
        if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(transform.position, Vector3.down, 1.5f))
            GetComponent<Rigidbody>().AddForce(Vector3.up * 8, ForceMode.Impulse);

        // body
        if (Input.GetAxis("Mouse X") > 0)
            transform.Rotate(0, (600 * Mathf.Abs(Input.GetAxis("Mouse X")) * Time.deltaTime), 0);
        if (Input.GetAxis("Mouse X") < 0)
            transform.Rotate(0, -(600 * Mathf.Abs(Input.GetAxis("Mouse X")) * Time.deltaTime), 0);


        // cam
        Transform cam = transform.Find("Main Camera");

        if (Input.GetAxis("Mouse Y") < 0)
        {
            cam.Rotate((600 * Mathf.Abs(Input.GetAxis("Mouse Y")) * Time.deltaTime), 0, 0);
            amount += (600 * Mathf.Abs(Input.GetAxis("Mouse Y")) * Time.deltaTime);
        }
        if (Input.GetAxis("Mouse Y") > 0)
        {
            cam.Rotate(-(600 * Mathf.Abs(Input.GetAxis("Mouse Y")) * Time.deltaTime), 0, 0);
            amount += -(600 * Mathf.Abs(Input.GetAxis("Mouse Y")) * Time.deltaTime);
        }

        if (amount > 30)
        {
            cam.Rotate(-(amount - 30), 0, 0);
            amount -= amount - 30;
        }
        if (amount < -30)
        {
            cam.Rotate(Mathf.Abs(amount) - 30, 0, 0);
            amount += Mathf.Abs(amount) - 30;
        }
    }
}
