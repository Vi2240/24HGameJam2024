using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneGridScript : MonoBehaviour
{
    public bool boughtStoneGrinder = false;

    bool hovering;
    bool boughtOnThisTile = false;

    public int howManyUpgrade = 0;

    ShopScript shopScript;


    void Start()
    {
        boughtStoneGrinder = false;

        shopScript = FindObjectOfType<ShopScript>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (boughtStoneGrinder && hovering && !boughtOnThisTile)
            {
                StoneGridScript[] myItems = FindObjectsOfType(typeof(StoneGridScript)) as StoneGridScript[];

                foreach (StoneGridScript item in myItems)
                {
                    item.boughtStoneGrinder = false;
                }

                boughtOnThisTile = true;

                gameObject.GetComponent<ResourceTower>().Upgrade();
                transform.GetChild(0).gameObject.SetActive(true);
            }

            if (hovering && boughtOnThisTile)
            {
                if ( howManyUpgrade == 0)
                {
                    bool yes = true;
  
                    shopScript.UpgradeStoneGrinder(gameObject, yes, howManyUpgrade);

                }

                if (boughtOnThisTile && howManyUpgrade == 1)
                {
                    bool yes = true;

                    shopScript.UpgradeStoneGrinder(gameObject, yes, howManyUpgrade);

                }
            }

            if (!boughtOnThisTile && hovering)
            {
                if (!boughtStoneGrinder)
                {
                    StartCoroutine(DisapereDelayRoutine(2));
                }
            }
        }

        if(Input.GetMouseButtonDown(2))
        {
            if (boughtStoneGrinder)
            {
                StoneGridScript[] myItems = FindObjectsOfType(typeof(StoneGridScript)) as StoneGridScript[];

                foreach (StoneGridScript item in myItems)
                {
                    item.boughtStoneGrinder = false;
                }
            }
        }

        if (!boughtStoneGrinder && !boughtOnThisTile)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    #region MouseOver&Exit

    private void OnMouseOver()
    {
        hovering = true;
        if (boughtStoneGrinder)
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
        if (boughtStoneGrinder)
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

    #endregion

    public void StoneUpgrade()
    {
        gameObject.GetComponent<ResourceTower>().Upgrade();
    }

    IEnumerator DisapereDelayRoutine(int whatVersion)
    {


        yield return new WaitForSeconds(0.1f);

        shopScript.DisapereVisuals();
 
    }
}
