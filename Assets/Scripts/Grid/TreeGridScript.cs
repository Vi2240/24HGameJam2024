using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGridScript : MonoBehaviour
{

    public bool buySawMill = false;

    bool hovering;
    bool boughtOnThisTile = false;


    void Start()
    {
        buySawMill = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (buySawMill && hovering && !boughtOnThisTile)
            {
                TreeGridScript[] myItems = FindObjectsOfType(typeof(TreeGridScript)) as TreeGridScript[];

                foreach (TreeGridScript item in myItems)
                {
                    item.buySawMill = false;
                }

                boughtOnThisTile = true;

                UpgradeTree();
                transform.GetChild(0).gameObject.SetActive(true);
            }
        }

        if(Input.GetMouseButtonDown(2))
        {
            if (buySawMill)
            {
                TreeGridScript[] myItems = FindObjectsOfType(typeof(TreeGridScript)) as TreeGridScript[];

                foreach (TreeGridScript item in myItems)
                {
                    item.buySawMill = false;
                }
            }
        }

        if (!buySawMill && !boughtOnThisTile)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void OnMouseOver()
    {
        hovering = true;
        if (buySawMill)
        {
            if (!boughtOnThisTile)
            {
                transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        else
        {
            gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().material.color = new Color32(255, 255, 255, 100);
        }
    }

    private void OnMouseExit()
    {
        hovering = false;
        if (buySawMill)
        {
            if (!boughtOnThisTile)
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        else
        {
            gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().material.color = new Color32(255, 255, 255, 255);
        }
    }

    public void UpgradeTree()
    {
        gameObject.GetComponent<ResourceTower>().Upgrade();
    }
}
