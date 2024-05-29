using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void BuyTurret(int Price)
    {
        BasicGridScript[] myItems = FindObjectsOfType(typeof(BasicGridScript)) as BasicGridScript[];

        foreach (BasicGridScript item in myItems)
        {
            item.buyingTurret1 = true;
        }
    }
}
