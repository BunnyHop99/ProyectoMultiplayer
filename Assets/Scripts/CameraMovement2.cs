using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement2 : MonoBehaviour
{
    public float cameraSpeed2;

    void Update()
    {
        transform.position += new Vector3(cameraSpeed2 * Time.deltaTime, 0, 0);
    }
}
