using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hiddenbutton : MonoBehaviour
{
    bool pressed = false;
    public GameObject target;
    public GameObject target2;
    public GameObject target3;
    void Update()
    {
        if (pressed == false)
        {
            if (Vector3.Distance(transform.position, GameObject.Find("Player").transform.position) < 10f)
            {
                Typewritter.tw.queue.Add("You press the button...");

                pressed = true;
                Destroy(target);
                Destroy(target2);
                target3.gameObject.SetActive(true);
            }
        }
    }
}
