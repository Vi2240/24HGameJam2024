using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGridScript : MonoBehaviour
{

    public bool boughtSawMill = false;

    bool hovering;
    bool boughtOnThisTile = false;

    public int howManyUpgrade = 0;

    ShopScript shopScript;


    void Start()
    {
        boughtSawMill = false;

        shopScript = FindObjectOfType<ShopScript>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (boughtSawMill && hovering && !boughtOnThisTile)
            {
                TreeGridScript[] myItems = FindObjectsOfType(typeof(TreeGridScript)) as TreeGridScript[];

                foreach (TreeGridScript item in myItems)
                {
                    item.boughtSawMill = false;
                }

                boughtOnThisTile = true;

                UpgradeTree();
                transform.GetChild(0).gameObject.SetActive(true);
            }

            if (hovering && boughtOnThisTile)
            {
                if (howManyUpgrade == 0)
                {
                    bool yes = true;

                    shopScript.UpgradeSawMill(gameObject, yes, howManyUpgrade);

                }
            }

            if (!boughtOnThisTile && hovering)
            {
                if (!boughtSawMill)
                {
                    StartCoroutine(DisapereDelayRoutine(2));
                }
            }
        }

        if(Input.GetMouseButtonDown(2))
        {
            if (boughtSawMill)
            {
                TreeGridScript[] myItems = FindObjectsOfType(typeof(TreeGridScript)) as TreeGridScript[];

                foreach (TreeGridScript item in myItems)
                {
                    item.boughtSawMill = false;
                }
            }
        }

        if (!boughtSawMill && !boughtOnThisTile)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void OnMouseOver()
    {
        hovering = true;
        if (boughtSawMill)
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
        if (boughtSawMill)
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

    IEnumerator DisapereDelayRoutine(int whatVersion)
    {


        yield return new WaitForSeconds(0.1f);

        shopScript.DisapereVisuals();

    }
}
