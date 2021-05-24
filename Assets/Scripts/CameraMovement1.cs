using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement1 : MonoBehaviour
{
    public float cameraSpeed1;

    void Update()
    {
        transform.position += new Vector3(cameraSpeed1 * Time.deltaTime, 0, 0);


    }
}
