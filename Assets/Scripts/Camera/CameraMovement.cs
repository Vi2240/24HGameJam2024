using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] float floatCameraSpeed = 1.5f;

    [SerializeField] GameObject MinimapCameraGraphic;

    public Vector2 minClamp = new Vector2(-27, -36);
    public Vector2 maxClamp = new Vector2(27, 36);


    void Update()
    {        
        if (Input.GetMouseButton(1))
        {
            var mousepos = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousepos.z = UnityEngine.Camera.main.transform.position.z;
            float Distance = Vector3.Distance(mousepos, UnityEngine.Camera.main.transform.position);

            UnityEngine.Camera.main.transform.position = Vector3.MoveTowards(UnityEngine.Camera.main.transform.position, mousepos, Distance * floatCameraSpeed * Time.deltaTime);
        }

        UnityEngine.Camera.main.transform.position = new Vector3(Mathf.Clamp(UnityEngine.Camera.main.transform.position.x, minClamp.x, maxClamp.x), Mathf.Clamp(UnityEngine.Camera.main.transform.position.y, minClamp.y, maxClamp.y), -10);

        //MinimapCameraGraphic.transform.position = new Vector3(Mathf.Clamp(UnityEngine.Camera.main.transform.position.x, minClamp.x, maxClamp.x), Mathf.Clamp(UnityEngine.Camera.main.transform.position.y, minClamp.y, maxClamp.y), -10);
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
    }
}
