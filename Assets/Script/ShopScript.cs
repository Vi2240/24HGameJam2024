using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    ResourceVault resourceVault;

    #region

    [SerializeField] GameObject turretUpgradeVisuals;

    GameObject objectToUpgrade;

    #endregion

    private void Start()
    {
        resourceVault = FindObjectOfType<ResourceVault>();

        turretUpgradeVisuals.SetActive(false);
    }

    #region BuyStuff

    #region Defense

    public void BuyTurret(int Price)
    {
        BasicGridScript[] myItems = FindObjectsOfType(typeof(BasicGridScript)) as BasicGridScript[];

        foreach (BasicGridScript item in myItems)
        {
            item.buyingTurret1 = true;
        }
        if (resourceVault.items[0] >= 50f)
        {

        }
    }

    public void BuyTeslaTower(int Price)
    {
        BasicGridScript[] myItems = FindObjectsOfType(typeof(BasicGridScript)) as BasicGridScript[];

        foreach (BasicGridScript item in myItems)
        {
            item.buyingTurret1 = true;
        }
        if (resourceVault.items[0] >= 50f)
        {

        }
    }

    public void BuyMortal(int Price)
    {
        BasicGridScript[] myItems = FindObjectsOfType(typeof(BasicGridScript)) as BasicGridScript[];

        foreach (BasicGridScript item in myItems)
        {
            item.buyingTurret1 = true;
        }
        if (resourceVault.items[0] >= 50f)
        {

        }
    }

    #endregion

    #region Resources

    public void BuySawMill(int Price)
    {
        if (resourceVault.items[0] >= 50f)
        {
            TreeGridScript[] myItems = FindObjectsOfType(typeof(TreeGridScript)) as TreeGridScript[];

            foreach (TreeGridScript item in myItems)
            {
                item.buySawMill = true;
            }

            resourceVault.items[0] -= 50f;
        }
    }

    public void BuyStoneGrinder(int Price)
    {
        if(resourceVault.items[0] >= 75f && resourceVault.items[1] >= 50f)
        {
            StoneGridScript[] myItems = FindObjectsOfType(typeof(StoneGridScript)) as StoneGridScript[];

            foreach (StoneGridScript item in myItems)
            {
                item.buyStoneGrinder = true;
            }

            resourceVault.items[0] -= 60f;
        }
    }

    public void BuyIronMine(int Price)
    {
        IronScript[] myItems = FindObjectsOfType(typeof(IronScript)) as IronScript[];

        foreach (IronScript item in myItems)
        {
            item.buyIronMine = true;
        }
        if (resourceVault.items[0] >= 50f)
        {

        }
    }

    public void BuyBank(int price)
    {
        if (resourceVault.items[0] >= 30f && resourceVault.items[1] >= 20f)
        {
            BasicGridScript[] myItems = FindObjectsOfType(typeof(BasicGridScript)) as BasicGridScript[];

            foreach (BasicGridScript item in myItems)
            {
                item.buyingBank = true;
            }

            resourceVault.items[0] -= 15f;
        }
    }

    #endregion

    #endregion

    #region Upgrades

    public void TurretUpgrade(bool trueOrFalse, GameObject objToUpgrade)
    {
        Vector3 mousePos = Camera.main.ViewportToWorldPoint(Input.mousePosition);
        turretUpgradeVisuals.transform.position = Camera.main.WorldToViewportPoint(mousePos);

        turretUpgradeVisuals.transform.position += new Vector3(100, 0, 0);

        turretUpgradeVisuals.SetActive(trueOrFalse);

        if(trueOrFalse)
        {
            objectToUpgrade = objToUpgrade;
        }
    }

    public void UpgradeTurretButton()
    {
        objectToUpgrade.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        objectToUpgrade.gameObject.transform.GetChild(3).gameObject.SetActive(true);
        if (resourceVault.items[0] >= 50f)
        {

        }
    }

    #endregion
}
