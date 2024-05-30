using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneGridScript : MonoBehaviour
{
    public bool buyStoneGrinder = false;

    bool hovering;
    bool boughtOnThisTile = false;


    void Start()
    {
        buyStoneGrinder = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (buyStoneGrinder && hovering && !boughtOnThisTile)
            {
                StoneGridScript[] myItems = FindObjectsOfType(typeof(StoneGridScript)) as StoneGridScript[];

                foreach (StoneGridScript item in myItems)
                {
                    item.buyStoneGrinder = false;
                }

                boughtOnThisTile = true;

                transform.GetChild(0).gameObject.SetActive(true);
            }
        }

        if(Input.GetMouseButtonDown(2))
        {
            if (buyStoneGrinder)
            {
                StoneGridScript[] myItems = FindObjectsOfType(typeof(StoneGridScript)) as StoneGridScript[];

                foreach (StoneGridScript item in myItems)
                {
                    item.buyStoneGrinder = false;
                }
            }
        }

        if (!buyStoneGrinder && !boughtOnThisTile)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void OnMouseOver()
    {
        hovering = true;
        if (buyStoneGrinder)
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
        if (buyStoneGrinder)
        {
            if (!boughtOnThisTile)
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().material.color = new Color32(255, 255, 255, 255);
        }
    }
}
