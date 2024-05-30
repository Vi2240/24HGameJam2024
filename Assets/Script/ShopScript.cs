using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{


    private void Start()
    {

    }

    #region BuyStuff

    public void BuyTurret(int Price)
    {
        BasicGridScript[] myItems = FindObjectsOfType(typeof(BasicGridScript)) as BasicGridScript[];

        foreach (BasicGridScript item in myItems)
        {
            item.buyingTurret1 = true;
        }
    }

    public void BuySawMill(int Price)
    {
        TreeGridScript[] myItems = FindObjectsOfType(typeof(TreeGridScript)) as TreeGridScript[];

        foreach (TreeGridScript item in myItems)
        {
            item.buySawMill = true;
        }
    }

    public void BuyStoneGrinder(int Price)
    {
        StoneGridScript[] myItems = FindObjectsOfType(typeof(StoneGridScript)) as StoneGridScript[];

        foreach (StoneGridScript item in myItems)
        {
            item.buyStoneGrinder = true;
        }
    }

    public void BuyIronMine(int Price)
    {
        IronScript[] myItems = FindObjectsOfType(typeof(IronScript)) as IronScript[];

        foreach (IronScript item in myItems)
        {
            item.buyIronMine = true;
        }
    }

    public void BuyBank(int price)
    {
        BasicGridScript[] myItems = FindObjectsOfType(typeof(BasicGridScript)) as BasicGridScript[];

        foreach (BasicGridScript item in myItems)
        {
            item.buyingBank = true;
        }
    }

    #endregion
}
