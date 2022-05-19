using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
    public Vector3 velocity = new Vector3(0,0.02f,0);

    private void Start()
    {
        GameObject.Destroy(gameObject, 10f);
    }
    void Update()
    {
        velocity += (GameObject.Find("Player").transform.position - transform.position) * 0.005f * Time.deltaTime;
        transform.position += velocity;

        if (Vector3.Distance(transform.position, GameObject.Find("Player").transform.position) < 5)
        {
            GameObject.Find("Canvas").transform.Find("Health").GetComponent<TMPro.TMP_Text>().text = "Ship Integriyty: " + System.Convert.ToString(System.Convert.ToInt32(GameObject.Find("Canvas").transform.Find("Health").GetComponent<TMPro.TMP_Text>().text.Remove(0, 17)) - 1);
            if (GameObject.Find("Canvas").transform.Find("Health").GetComponent<TMPro.TMP_Text>().text == "Ship Integriyty: 0")
                GameObject.Find("Canvas").transform.Find("GameOver").gameObject.SetActive(true);
            GameObject.Destroy(gameObject);
        }
    }
}
