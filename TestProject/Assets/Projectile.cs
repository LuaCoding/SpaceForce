using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 dir;
    void Update()
    {
        transform.position += dir * 50 * Time.deltaTime;
    }
}
