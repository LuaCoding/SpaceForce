using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndText : MonoBehaviour
{
    void Start()
    {
        string text = GetComponent<TMPro.TMP_Text>().text;
        GetComponent<TMPro.TMP_Text>().text = "";
        StartCoroutine(loop());
        IEnumerator loop()
        {
            yield return new WaitForSeconds(1);
            while(text.Length>0)
            {
                yield return new WaitForSeconds(0.01f);
                GetComponent<TMPro.TMP_Text>().text += text[0];
                text = text.Remove(0, 1);
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            UnityEngine.SceneManagement.SceneManager.LoadScene("Space");
    }
}
