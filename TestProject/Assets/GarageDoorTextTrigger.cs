using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageDoorTextTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, GameObject.Find("Player").transform.position) < 25f)
        {
            Typewritter.tw.queue.Add("This garage door is shut. Maybe a button somewhere can open it");
            Destroy(gameObject);
        }
    }
}
