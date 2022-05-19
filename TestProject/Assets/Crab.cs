using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (GameObject.Find("Player").transform.position - transform.position).normalized * 5 * Time.deltaTime;
        transform.LookAt(GameObject.Find("Player").transform.position, transform.forward);
    }
}
