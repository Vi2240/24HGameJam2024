using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class BasicGridScript : MonoBehaviour
{
    public bool buyingTurret1 = false;
    

    bool hovering;
    bool boughtOnThisTile = false;
    bool isTouchingbase = false;

    float DecorationRandomFalse1 = 0f;
    float DecorationRandomFalse2 = 90f;
    float DecorationRandomTrue = 101f;

    private void Start()
    {
        float Number = Random.Range(0, 101);
        if (Number >= DecorationRandomFalse1 && Number < DecorationRandomFalse2)
        {
            if (gameObject.transform.GetChild(1) != null)
            {
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
            }
        }
        if (Number >= DecorationRandomFalse2 && Number < DecorationRandomTrue)
        {
           if (gameObject.transform.GetChild(1) != null)
           {
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
            }
        }
    }

    private void OnMouseOver()
    {
        hovering = true;
        if (buyingTurret1)
        {
            if (!boughtOnThisTile && !isTouchingbase)
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
            if(!boughtOnThisTile && !isTouchingbase)
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
            if(buyingTurret1 && hovering && !boughtOnThisTile && !isTouchingbase)
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
        }

        if (!buyingTurret1 && !boughtOnThisTile && !isTouchingbase)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isTouchingbase = true;
        }
    }
}
