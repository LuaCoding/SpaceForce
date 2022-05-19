using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    void Update()
    {
        if (transform.childCount == 0)
        {
            StartCoroutine(goose());
            IEnumerator goose()
            {
                Typewritter.tw.queue.Add("Congratulations, now lets get to the moon");
                yield return new WaitForSeconds(3);
                UnityEngine.SceneManagement.SceneManager.LoadScene("Space");
            }
        }
        GameObject.Find("HUD").transform.Find("Remaining").GetComponent<TMPro.TMP_Text>().text = "Parts remaining: " + transform.childCount;
    }
}
