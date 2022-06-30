using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectScript : MonoBehaviour
{
    private void Start()
    {
        GameObject.Find("HUD").transform.Find("CollectPrompt").gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.E) == false)
            GameObject.Find("HUD").transform.Find("CollectPrompt").Find("Slider").GetComponent<UnityEngine.UI.Slider>().value = 1f;

        if (Vector3.Distance(transform.position, GameObject.Find("Player").transform.position) < 3)
        {
            GameObject.Find("HUD").transform.Find("CollectPrompt").gameObject.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {
                GameObject.Find("HUD").transform.Find("CollectPrompt").Find("Slider").GetComponent<UnityEngine.UI.Slider>().value
                    =
                GameObject.Find("HUD").transform.Find("CollectPrompt").Find("Slider").GetComponent<UnityEngine.UI.Slider>().value - 0.5f * Time.deltaTime;
            }
            if (GameObject.Find("HUD").transform.Find("CollectPrompt").Find("Slider").GetComponent<UnityEngine.UI.Slider>().value <= 0f)
            {
                GameObject.Find("HUD").transform.Find("CollectPrompt").gameObject.SetActive(false);
                Destroy(gameObject);
            }

            StartCoroutine(checkIfLeft());
            IEnumerator checkIfLeft()
            {
                while(true)
                {
                    yield return new WaitForSeconds(0.1f);
                    if (Vector3.Distance(transform.position, GameObject.Find("Player").transform.position) > 3)
                    {
                        GameObject.Find("HUD").transform.Find("CollectPrompt").gameObject.SetActive(false);
                        yield break;
                    }
                }
            }
        }
    }
}
