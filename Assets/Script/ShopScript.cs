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

    public void BuyTurret()
    {
        if (resourceVault.items[0] >= 50f)
        {
            BasicGridScript[] myItems = FindObjectsOfType(typeof(BasicGridScript)) as BasicGridScript[];

            foreach (BasicGridScript item in myItems)
            {
                item.buyingTurret1 = true;
            }

            resourceVault.items[0] -= 50f;
        }
    }

    public void BuyTeslaTower()
    {
        if (resourceVault.items[0] >= 125f && resourceVault.items[1] >= 75f && resourceVault.items[2] >= 45)
        {
            BasicGridScript[] myItems = FindObjectsOfType(typeof(BasicGridScript)) as BasicGridScript[];

            foreach (BasicGridScript item in myItems)
            {
                item.buyingTurret1 = true;
            }

            resourceVault.items[0] -= 125f;
            resourceVault.items[1] -= 75f;
            resourceVault.items[2] -= 45f;
        }
    }

    public void BuyMortal()
    {
        if (resourceVault.items[0] >= 150f && resourceVault.items[1] >= 80f && resourceVault.items[2] >= 60 && resourceVault.items[3] >= 40)
        {
            BasicGridScript[] myItems = FindObjectsOfType(typeof(BasicGridScript)) as BasicGridScript[];

            foreach (BasicGridScript item in myItems)
            {
                item.buyingTurret1 = true;
            }

            resourceVault.items[0] -= 150f;
            resourceVault.items[1] -= 80f;
            resourceVault.items[2] -= 60f;
            resourceVault.items[3] -= 40f;
        }
    }

    #endregion

    #region Resources

    public void BuySawMill()
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

    public void BuyStoneGrinder()
    {
        if(resourceVault.items[0] >= 75f && resourceVault.items[1] >= 50f)
        {
            StoneGridScript[] myItems = FindObjectsOfType(typeof(StoneGridScript)) as StoneGridScript[];

            foreach (StoneGridScript item in myItems)
            {
                item.buyStoneGrinder = true;
            }

            resourceVault.items[0] -= 75f;
            resourceVault.items[1] -= 50f;
        }
    }

    public void BuyIronMine()
    {
        if (resourceVault.items[0] >= 100f && resourceVault.items[1] >= 60f && resourceVault.items[2] >= 30f)
        {
            IronScript[] myItems = FindObjectsOfType(typeof(IronScript)) as IronScript[];

            foreach (IronScript item in myItems)
            {
                item.buyIronMine = true;
            }

            resourceVault.items[0] -= 100f;
            resourceVault.items[1] -= 60f;
            resourceVault.items[2] -= 30f;
        }
    }

    public void BuyBank()
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

        objectToUpgrade.gameObject.transform.GetComponent<BasicGridScript>().upgradeBought = true;
        if (resourceVault.items[0] >= 50f)
        {

        }
    }

    #endregion
}
