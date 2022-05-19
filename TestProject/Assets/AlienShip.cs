using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShip : MonoBehaviour
{
    float x = 500;    
    float y = 500;    
    float z = 500;
    void Start()
    {
        StartCoroutine(loop());
        StartCoroutine(shoot());
    }
    void Update()
    {
        transform.Rotate(x * Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime);

        transform.position += (GameObject.Find("Player").transform.position - transform.position) * 0.01f * Time.deltaTime;
    }
    IEnumerator loop()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (UnityEngine.Random.Range(0, 11) > 9)
                x -= x * 2;
            if (UnityEngine.Random.Range(0, 11) > 9)
                y -= y * 2;
            if (UnityEngine.Random.Range(0, 11) > 9)
                z -= z * 2;
        }
    }
    IEnumerator shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            GameObject.Instantiate(Resources.Load<GameObject>("homing"), transform.position, Quaternion.identity);
        }
    }
}
