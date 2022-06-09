using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : MonoBehaviour
{
    public float ChargeLeft { get { return _ChargeLeft; } set { _ChargeLeft = value; if (value <= 0) Destroy(gameObject); } }
    float _ChargeLeft = 50;
}
