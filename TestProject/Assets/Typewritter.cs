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

        queue.Add("We need to repair our shuttle to get to space");
        queue.Add("Collect all parts (green glow)");
        queue.Add("If you run out of power, you will slow down to a crawl");
        queue.Add("Use coils (yellow glow) to recharge");

        StartCoroutine(queuewait());
    }

    IEnumerator queuewait()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
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
                yield return new WaitForSeconds(0.015f);
                t.text += remaining[0];
                remaining = remaining.Remove(0,1);
            }
            yield return new WaitForSeconds(1f);
            while(t.text.Length>0)
            {
                yield return new WaitForSeconds(0.005f);
                t.text = t.text.Remove(t.text.Length - 1,1);
            }
            yield return new WaitForSeconds(0.5f);
            active = false;
        }
    }
}
