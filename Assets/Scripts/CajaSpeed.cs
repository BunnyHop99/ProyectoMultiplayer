using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaSpeed : MonoBehaviour
{
    public float cajaSpeed;

    void Update()
    {
        transform.position += new Vector3(cajaSpeed * Time.deltaTime, -15f, -9.4f);
    }
}
