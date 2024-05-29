using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class BasicGridScript : MonoBehaviour
{
    public bool buyingTurret1 = false;

    bool hovering;
    bool boughtOnThisTile = false;


    private void OnMouseOver()
    {
        hovering = true;
        if (buyingTurret1)
        {
            if (!boughtOnThisTile)
            {
                transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().material.color = new Color32(255, 255, 255, 100);
        }
    }

    private void OnMouseExit()
    {
        hovering = false;
        if (buyingTurret1)
        {
            if(!boughtOnThisTile)
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().material.color = new Color32(255, 255, 255, 255);
        }
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(buyingTurret1 && hovering && !boughtOnThisTile)
            {
                BasicGridScript[] myItems = FindObjectsOfType(typeof(BasicGridScript)) as BasicGridScript[];

                foreach (BasicGridScript item in myItems)
                {
                    item.buyingTurret1 = false;
                }

                boughtOnThisTile = true;

                transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
}
