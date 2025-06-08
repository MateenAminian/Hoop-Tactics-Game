using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAspect : MonoBehaviour
{
  public float aspectNeeded = 16.0f / 11.0f;
  public Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        mainCam.aspect = aspectNeeded;
    }
}
