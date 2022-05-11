using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectScript : MonoBehaviour
{
    void Update()
    {
        if (Vector3.Distance(transform.position, GameObject.Find("Player").transform.position) < 2)
            Destroy(gameObject);
    }
}
