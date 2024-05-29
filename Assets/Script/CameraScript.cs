using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour

{
    float cameraSize = 10;

    float maxCameraSize = 17f;
    // Start is called before the first frame update
    void Start()
    {
        Camera.main.orthographicSize = cameraSize;
    }

    // Update is called once per frame
    void Update()
    {

        if (cameraSize > 1 && cameraSize < maxCameraSize)
        {
            Camera.main.orthographicSize -= Input.mouseScrollDelta.y;
        }
        
        if(cameraSize >= maxCameraSize)
        {
            Camera.main.orthographicSize = maxCameraSize - 0.0001f;
            cameraSize = 14.0000009f;
        }
        if(cameraSize <= 1)
        {
            Camera.main.orthographicSize = 1.0000001f;
            cameraSize = 1.0000001f;
        }

        cameraSize = Camera.main.orthographicSize;
    }
}
