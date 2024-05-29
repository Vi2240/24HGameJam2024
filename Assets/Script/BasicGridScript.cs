using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class BasicGridScript : MonoBehaviour
{



    private void OnMouseOver()
    {
        gameObject.GetComponent<SpriteRenderer>().material.color = new Color32(255, 255, 255, 100);
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().material.color = new Color32(255, 255, 255, 255);
    }
}
