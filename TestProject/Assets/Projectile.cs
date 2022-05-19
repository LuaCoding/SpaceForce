using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 dir;
    void Update()
    {
        transform.position += dir * 80 * Time.deltaTime;
        GameObject.Destroy(gameObject, 10);

        if (GameObject.Find("Alien") == null == false)
        {
            if (Vector3.Distance(transform.position, GameObject.Find("Alien").transform.position) < 6)
            {
                GameObject.Find("Canvas").transform.Find("EnemyHealth").GetComponent<TMPro.TMP_Text>().text = "Enemy Ship Integrity: " + System.Convert.ToString(System.Convert.ToSingle(GameObject.Find("Canvas").transform.Find("EnemyHealth").GetComponent<TMPro.TMP_Text>().text.Remove(0, 22)) - 1f);
                if (System.Convert.ToSingle(GameObject.Find("Canvas").transform.Find("EnemyHealth").GetComponent<TMPro.TMP_Text>().text.Remove(0, 22)) <= 0f)
                {
                    GameObject.Find("Canvas").transform.Find("EnemyHealth").GetComponent<TMPro.TMP_Text>().text = "";
                    Destroy(GameObject.Find("Alien"));
                }
                Destroy(gameObject);
            }
        }
    }
}
