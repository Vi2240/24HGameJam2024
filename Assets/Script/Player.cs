using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    float floatCameraSpeed = 1.5f;

    public Vector2 minClamp = new Vector2(-20, -31);
    public Vector2 maxClamp = new Vector2(20, 31);


    void Update()
    {        
        if (Input.GetMouseButton(1))
        {
            var mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousepos.z = Camera.main.transform.position.z;
            float Distance = Vector3.Distance(mousepos, Camera.main.transform.position);

            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, mousepos, Distance * floatCameraSpeed * Time.deltaTime);
        }

        Camera.main.transform.position = new Vector3(Mathf.Clamp(Camera.main.transform.position.x, minClamp.x, maxClamp.x), Mathf.Clamp(Camera.main.transform.position.y, minClamp.y, maxClamp.y), -10);

        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
    }
}
