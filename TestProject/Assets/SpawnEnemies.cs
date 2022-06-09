using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loop());
    }

    List<GameObject> spawned = new List<GameObject>();

    IEnumerator loop()
    {
        while(true)
        {
            yield return new WaitForSeconds(10f);

            if (spawned.Count > 5)
                continue;

            List<Transform> all = new List<Transform>();
            foreach (Transform t in transform)
                all.Add(t);

            int i = UnityEngine.Random.Range(0, all.Count);            
            spawned.Add(Instantiate(Resources.Load<GameObject>("enemy"), all[i].position, Quaternion.identity));
        }
    }
}
