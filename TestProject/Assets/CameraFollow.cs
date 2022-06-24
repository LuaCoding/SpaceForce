using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    void Start()
    {
        //transform.forward = new Vector3(transform.forward.x, GameObject.Find("Player").transform.forward.y, transform.forward.z);
    }
    void Update()
    {
        Vector3 pos = GameObject.Find("Player").transform.position;
        pos += new Vector3(0, (7.84f - 2.34f), 0);
        pos += -6.15f * GameObject.Find("Player").transform.forward;

        transform.position = pos;

        Vector3 eulerRotation = new Vector3(transform.eulerAngles.x, GameObject.Find("Player").transform.eulerAngles.y, transform.eulerAngles.z);

        transform.rotation = Quaternion.Euler(eulerRotation);

        //transform.rotation = new Quaternion(transform.rotation.x, GameObject.Find("Player").transform.rotation.y, transform.rotation.z, transform.rotation.w);
        //transform.rotation.Set(transform.rotation.x, GameObject.Find("Player").transform.rotation.y, transform.rotation.z, transform.rotation);
        //transform.LookAt(new Vector3(GameObject.Find("Player").transform.position.x, transform.position.y, GameObject.Find("Player").transform.position.z), transform.up);
    }
}
