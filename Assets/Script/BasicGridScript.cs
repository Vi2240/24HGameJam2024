using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class BasicGridScript : BuildingHealthScript
{
    public bool buyingTurret1 = false;
    public bool buyingTeslaTUrret = false;
    public bool buyingBank = false;
    public bool buyMortar = false;
    

    bool hovering;
    bool boughtOnThisTile = false;
    bool isTouchingbase = false;
    bool bankIsBough = false;
    bool turretIsBought = false;

    public bool turretUpgradeIsBought = false;
    public bool bankUpgradeIsBought = false;

    #region Decorations

    float DecorationRandom1 = 0f;
    float DecorationRandom2 = 90f;
    float DecorationRandom3 = 93f;
    float DecorationRandom4 = 98f;
    float DecorationRandom5 = 101f;

    #endregion

    ShopScript shopScript;

    private void Start()
    {
        #region Details Random

        float Number = Random.Range(0, 101);
        if (Number >= DecorationRandom1 && Number < DecorationRandom2)
        {
            if (gameObject.transform.GetChild(1) != null)
            {
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
            }
        }
        if (Number >= DecorationRandom2 && Number < DecorationRandom3)
        {
           if (gameObject.transform.GetChild(1) != null)
           {
                gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.SetActive(true);
           }
        }
        if (Number >= DecorationRandom3 && Number < DecorationRandom4)
        {
            if (gameObject.transform.GetChild(1) != null)
            {
                gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.SetActive(true);
            }
        }
        if (Number >= DecorationRandom4 && Number < DecorationRandom5)
        {
            if (gameObject.transform.GetChild(1) != null)
            {
                gameObject.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.SetActive(true);
            }
        }

        #endregion

        shopScript = FindObjectOfType<ShopScript>();

        turretUpgradeIsBought = false;
        bankUpgradeIsBought = false;
    }

    private void OnMouseOver()
    {
        hovering = true;
        if (buyingTurret1 || buyingBank || buyMortar || buyingTeslaTUrret)
        {
            if (!boughtOnThisTile && !isTouchingbase && buyingTurret1)
            {
                transform.GetChild(0).gameObject.SetActive(true);
            }
            if (!boughtOnThisTile && !isTouchingbase && buyingBank)
            {
                transform.GetChild(2).gameObject.SetActive(true);
            }
            if (!boughtOnThisTile && !isTouchingbase && buyingTeslaTUrret)
            {
                transform.GetChild(5).gameObject.SetActive(true);
            }
            if (!boughtOnThisTile && !isTouchingbase && buyMortar)
            {
                transform.GetChild(6).gameObject.SetActive(true);
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
        if (buyingTurret1 || buyingBank || buyMortar || buyingTeslaTUrret)
        {
            if(!boughtOnThisTile && !isTouchingbase && buyingTurret1)
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
            if (!boughtOnThisTile && !isTouchingbase && buyingBank)
            {
                transform.GetChild(2).gameObject.SetActive(false);
            }
            if (!boughtOnThisTile && !isTouchingbase && buyingTeslaTUrret)
            {
                transform.GetChild(5).gameObject.SetActive(false);
            }
            if (!boughtOnThisTile && !isTouchingbase && buyMortar)
            {
                transform.GetChild(6).gameObject.SetActive(false);
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
            if(hovering && boughtOnThisTile && !isTouchingbase)
            {
                if(bankIsBough && !bankUpgradeIsBought)
                {
                    bool yes = true;

                    shopScript.UpgradeBank(gameObject, yes);
                }

                if (turretIsBought && !turretUpgradeIsBought)
                {
                    bool yes = true;

                    shopScript.TurretUpgrade(yes, gameObject);
                }
            }

            if(!boughtOnThisTile && !isTouchingbase && hovering)
            {
                if (!turretIsBought)
                {
                    StartCoroutine(DisapereDelayRoutine(1));
                }

                if (!bankIsBough)
                {
                    StartCoroutine(DisapereDelayRoutine(2));
                }
            }

            #region Buy

            if (buyingTurret1 && hovering && !boughtOnThisTile && !isTouchingbase)
            {
                BasicGridScript[] myItems = FindObjectsOfType(typeof(BasicGridScript)) as BasicGridScript[];

                foreach (BasicGridScript item in myItems)
                {
                    item.buyingTurret1 = false;
                }

                boughtOnThisTile = true;
                turretIsBought = true;

                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);
            }

            if (buyingBank && hovering && !boughtOnThisTile && !isTouchingbase)
            {
                BasicGridScript[] myItems = FindObjectsOfType(typeof(BasicGridScript)) as BasicGridScript[];

                foreach (BasicGridScript item in myItems)
                {
                    item.buyingBank = false;
                }

                bankIsBough = true;
                boughtOnThisTile = true;

                gameObject.GetComponent<ResourceTower>().Upgrade();
                transform.GetChild(2).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);
            }

            if (buyingTeslaTUrret && hovering && !boughtOnThisTile && !isTouchingbase)
            {
                BasicGridScript[] myItems = FindObjectsOfType(typeof(BasicGridScript)) as BasicGridScript[];

                foreach (BasicGridScript item in myItems)
                {
                    item.buyingTeslaTUrret = false;
                }

                buyingTeslaTUrret = true;
                boughtOnThisTile = true;

                
                transform.GetChild(5).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);
            }

            if (buyMortar && hovering && !boughtOnThisTile && !isTouchingbase)
            {
                BasicGridScript[] myItems = FindObjectsOfType(typeof(BasicGridScript)) as BasicGridScript[];

                foreach (BasicGridScript item in myItems)
                {
                    item.buyMortar = false;
                }

                buyMortar = true;
                boughtOnThisTile = true;


                transform.GetChild(6).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);
            }
            #endregion
        }

        if (Input.GetMouseButtonDown(2))
        {
            if (buyingTurret1 && !isTouchingbase)
            {
                BasicGridScript[] myItems = FindObjectsOfType(typeof(BasicGridScript)) as BasicGridScript[];

                foreach (BasicGridScript item in myItems)
                {
                    item.buyingTurret1 = false;
                }
            }

            if (buyingBank && !isTouchingbase)
            {
                BasicGridScript[] myItems = FindObjectsOfType(typeof(BasicGridScript)) as BasicGridScript[];

                foreach (BasicGridScript item in myItems)
                {
                    item.buyingBank = false;
                }
            }

            if (buyingTeslaTUrret && !isTouchingbase)
            {
                BasicGridScript[] myItems = FindObjectsOfType(typeof(BasicGridScript)) as BasicGridScript[];

                foreach (BasicGridScript item in myItems)
                {
                    item.buyingTeslaTUrret = false;
                }
            }
        }

        if (!buyingTurret1 && !boughtOnThisTile && !isTouchingbase)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
        if (!buyingBank && !boughtOnThisTile && !isTouchingbase)
        {
            transform.GetChild(2).gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isTouchingbase = true;
        }
    }

    IEnumerator DisapereDelayRoutine(int whosAsking)
    {


        yield return new WaitForSeconds(0.1f);

        shopScript.DisapereVisuals();

        //bool no = false;
        //if(whosAsking == 1)
        //{
        //    shopScript.TurretUpgrade(no, gameObject);
        //}
        //if(whosAsking == 2)
        //{
        //    shopScript.UpgradeBank(gameObject, no);
        //}
    }

    public void UpgradeBank()
    {
        gameObject.GetComponent<ResourceTower>().Upgrade();
    }
}
