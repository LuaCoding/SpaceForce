using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    void Update()
    {
        if (transform.childCount == 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Space");
        }
    }
}
