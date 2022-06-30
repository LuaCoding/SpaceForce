using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moonend : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(GameObject.Find("Player").transform.position, transform.position) < 80)
        {
            GameObject.Find("Canvas").transform.Find("end").gameObject.SetActive(true);
            Destroy(this);
        }
    }
}
