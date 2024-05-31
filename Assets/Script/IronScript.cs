using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronScript : BuildingHealthScript
{
    public bool boughtIronMine = false;

    bool hovering;
    bool boughtOnThisTile = false;

    public int howManyUpgrade = 0;

    ShopScript shopScript;

    void Start()
    {
        boughtIronMine = false;

        shopScript = FindObjectOfType<ShopScript>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (boughtIronMine && hovering && !boughtOnThisTile)
            {
                IronScript[] myItems = FindObjectsOfType(typeof(IronScript)) as IronScript[];

                foreach (IronScript item in myItems)
                {
                    item.boughtIronMine = false;
                }

                boughtOnThisTile = true;

                gameObject.GetComponent<ResourceTower>().Upgrade();
                transform.GetChild(0).gameObject.SetActive(true);
            }

            if (hovering && boughtOnThisTile)
            {
                if (howManyUpgrade == 0)
                {
                    bool yes = true;

                    shopScript.UpgradeIronMine(gameObject, yes, howManyUpgrade);

                }

                if (boughtOnThisTile && howManyUpgrade == 1)
                {
                    bool yes = true;

                    shopScript.UpgradeIronMine(gameObject, yes, howManyUpgrade);

                }
            }

            if (!boughtOnThisTile && hovering)
            {
                if (!boughtIronMine)
                {
                    StartCoroutine(DisapereDelayRoutine(2));
                }
            }
        }

        if (Input.GetMouseButtonDown(2))
        {
            if (boughtIronMine)
            {
                IronScript[] myItems = FindObjectsOfType(typeof(IronScript)) as IronScript[];

                foreach (IronScript item in myItems)
                {
                    item.boughtIronMine = false;
                }
            }
        }

        if (!boughtIronMine && !boughtOnThisTile)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void OnMouseOver()
    {
        hovering = true;
        if (boughtIronMine)
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
        if (boughtIronMine)
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

    public void UpgradeIronMine()
    {
        gameObject.GetComponent<ResourceTower>().Upgrade();
    }

    IEnumerator DisapereDelayRoutine(int whatVersion)
    {


        yield return new WaitForSeconds(0.1f);

        //bool no = false;
        //Debug.Log("DISAPERE");
        //shopScript.UpgradeStoneGrinder(gameObject, no ,whatVersion);
        shopScript.DisapereVisuals();

    }
}
