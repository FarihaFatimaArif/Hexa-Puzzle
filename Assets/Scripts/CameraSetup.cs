using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetup : MonoBehaviour
{
    float width = 6f;
    float cameraAspectRatio;
    float OrthoSize;
    [SerializeField] Camera MianCam;
    // Start is called before the first frame update
    void Start()
    {
        cameraAspectRatio = 1/ MianCam.aspect;
        OrthoSize=(cameraAspectRatio*width)/2;
        MianCam.orthographicSize = OrthoSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
