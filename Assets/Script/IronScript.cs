using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronScript : MonoBehaviour
{
    public bool buyIronMine = false;

    bool hovering;
    bool boughtOnThisTile = false;

    // Start is called before the first frame update
    void Start()
    {
        buyIronMine = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (buyIronMine && hovering && !boughtOnThisTile)
            {
                IronScript[] myItems = FindObjectsOfType(typeof(IronScript)) as IronScript[];

                foreach (IronScript item in myItems)
                {
                    item.buyIronMine = false;
                }

                boughtOnThisTile = true;

                transform.GetChild(0).gameObject.SetActive(true);
            }
        }

        if (Input.GetMouseButtonDown(2))
        {
            if (buyIronMine)
            {
                IronScript[] myItems = FindObjectsOfType(typeof(IronScript)) as IronScript[];

                foreach (IronScript item in myItems)
                {
                    item.buyIronMine = false;
                }
            }
        }

        if (!buyIronMine && !boughtOnThisTile)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void OnMouseOver()
    {
        hovering = true;
        if (buyIronMine)
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
        if (buyIronMine)
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
