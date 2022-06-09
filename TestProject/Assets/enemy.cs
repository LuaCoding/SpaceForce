using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    void Update()
    {
        GetComponent<Rigidbody>().AddForce((GameObject.Find("Player").transform.position - transform.position).normalized * 3);
    }
}
