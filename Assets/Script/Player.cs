using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    float floatCameraSpeed = 1.5f;


    void Update()
    {        
        if (Input.GetMouseButton(1))
        {
            var mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousepos.z = Camera.main.transform.position.z;
            float Distance = Vector3.Distance(mousepos, Camera.main.transform.position);

            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, mousepos, Distance * floatCameraSpeed * Time.deltaTime);
        }

        //Camera.main.transform.position = new Vector2(Mathf.Clamp(Camera.main.transform.position.x, -27, 27), Mathf.Clamp(Camera.main.transform.position.y, 36, 36));
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
    }
}
