using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHandler : MonoBehaviour
{
    // public Rigidbody rb;
    public static float speed = 0.02f;
    // Start is called before the first frame update
    // void Start()
    // {
    //     rb = GetComponent<Rigidbody>();
    // }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.up * -speed);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0,0,speed*10);
        }
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * speed);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0,0,-speed*10);
        }
        if(Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(speed*10,0,0, Space.Self);
        }
        if(Input.GetKey(KeyCode.E))
        {
            transform.Rotate(-speed*10,0,0, Space.Self);
        }
    }
}