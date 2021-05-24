using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAll : MonoBehaviour
{
    public GameObject objectToFind;
    public GameObject p2;
    public GameObject bg;

    public CameraMovement cameraMovement;
    public CameraMovement cameraMovementP2;
    public CameraMovement cameraMovementBg;

    void Start()
    {
        cameraMovement = objectToFind.GetComponent<CameraMovement>();
        cameraMovementP2 = p2.GetComponent<CameraMovement>();
        cameraMovementBg = bg.GetComponent<CameraMovement>();

    }

    void Update()
    {
      
    }

    public void On()
    {
        cameraMovement.cameraSpeed = 10f;
        cameraMovementP2.cameraSpeed = 10f;
        cameraMovementBg.cameraSpeed = 10f;
    }
}
