using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Typewritter : MonoBehaviour
{
    public static Typewritter tw;
    TMPro.TMP_Text t => GetComponent<TMPro.TMP_Text>();
    void Start()
    {
        t.text = "";
        tw = this;

        queue.Add("We need to repair this spaceship to get to space");
        queue.Add("Collect all ship parts");

        StartCoroutine(queuewait());
    }

    IEnumerator queuewait()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            if (active == false && queue.Count>0)
            {
                message(queue[0]);
                queue.RemoveAt(0);
            }
        }
    }
    public List<string> queue = new List<string>();
    bool active;
    void message(string text)
    {
        string remaining = text;

        StartCoroutine(loop());
        IEnumerator loop()
        {
            active = true;
            t.text = "";
            while(remaining.Length > 0)
            {
                yield return new WaitForSeconds(0.03f);
                t.text += remaining[0];
                remaining = remaining.Remove(0,1);
            }
            yield return new WaitForSeconds(2);
            while(t.text.Length>0)
            {
                yield return new WaitForSeconds(0.01f);
                t.text = t.text.Remove(t.text.Length - 1,1);
            }
            yield return new WaitForSeconds(0.5f);
            active = false;
        }
    }
}
