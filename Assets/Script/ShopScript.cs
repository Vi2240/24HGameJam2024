using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    ResourceVault resourceVault;

    #region

    [Header("UpgradeVisuals")]

    [SerializeField] GameObject turretUpgradeVisuals;
    [SerializeField] GameObject bankUpgradeVisuals;

    [SerializeField] GameObject stoneMineV2Visuals;
    [SerializeField] GameObject stoneMineV3Visuals;

    [SerializeField] GameObject ironMineV2Visuals;
    [SerializeField] GameObject ironMineV3Visuals;

    [SerializeField] GameObject SawMillUpgrade;

    GameObject objectToUpgrade;
    GameObject VisualsObject = null;

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
            TreeGridScript[] myItems = FindObjectsOfType(typeof(TreeGridScript)) as TreeGridScript[];

            foreach (TreeGridScript item in myItems)
            {
                item.boughtSawMill = true;
            }
        if (resourceVault.items[0] >= 50f)
        {

            resourceVault.items[0] -= 50f;
        }
    }

    public void BuyStoneGrinder()
    {
            StoneGridScript[] myItems = FindObjectsOfType(typeof(StoneGridScript)) as StoneGridScript[];

            foreach (StoneGridScript item in myItems)
            {
                item.boughtStoneGrinder = true;
            }
        if(resourceVault.items[0] >= 75f && resourceVault.items[1] >= 50f)
        {

            resourceVault.items[0] -= 75f;
            resourceVault.items[1] -= 50f;
        }
    }

    public void BuyIronMine()
    {
            IronScript[] myItems = FindObjectsOfType(typeof(IronScript)) as IronScript[];

            foreach (IronScript item in myItems)
            {
                item.boughtIronMine = true;
            }
        if (resourceVault.items[0] >= 100f && resourceVault.items[1] >= 60f && resourceVault.items[2] >= 30f)
        {

            resourceVault.items[0] -= 100f;
            resourceVault.items[1] -= 60f;
            resourceVault.items[2] -= 30f;
        }
    }

    public void BuyBank()
    {
            BasicGridScript[] myItems = FindObjectsOfType(typeof(BasicGridScript)) as BasicGridScript[];

            foreach (BasicGridScript item in myItems)
            {
                item.buyingBank = true;
            }
        if (resourceVault.items[0] >= 30f && resourceVault.items[1] >= 20f)
        {

            resourceVault.items[0] -= 15f;
        }
    }

    #endregion

    #endregion

    #region Upgrades

    #region TurretUpgrade

    public void TurretUpgrade(bool trueOrFalse, GameObject objToUpgrade)
    {
        Vector3 mousePos = Camera.main.ViewportToWorldPoint(Input.mousePosition);
        VisualsObject = turretUpgradeVisuals;
        VisualsObject.transform.position = Camera.main.WorldToViewportPoint(mousePos);

        VisualsObject.transform.position += new Vector3(100, 0, 0);

        VisualsObject.SetActive(trueOrFalse);

        if(trueOrFalse)
        {
            objectToUpgrade = objToUpgrade;
        }
    }

    public void UpgradeTurretButton()
    {
        objectToUpgrade.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        objectToUpgrade.gameObject.transform.GetChild(3).gameObject.SetActive(true);

        objectToUpgrade.gameObject.transform.GetComponent<BasicGridScript>().turretUpgradeIsBought = true;
        if (resourceVault.items[0] >= 50f)
        {

        }
    }

    #endregion

    #region BankUpgrade

    public void UpgradeBank(GameObject objToUpgrade, bool tureorFalse)
    {
        Vector3 mousePos = Camera.main.ViewportToWorldPoint(Input.mousePosition);
        VisualsObject = bankUpgradeVisuals;
        VisualsObject.transform.position = Camera.main.WorldToViewportPoint(mousePos);

        VisualsObject.transform.position += new Vector3(100, 0, 0);

        VisualsObject.SetActive(tureorFalse);

        if(tureorFalse)
        {
            objectToUpgrade = objToUpgrade;
        }
    }

    public void UpgradeBankButton()
    {
        objectToUpgrade.gameObject.GetComponent<ResourceTower>().Upgrade();

        objectToUpgrade.gameObject.GetComponent<BasicGridScript>().bankUpgradeIsBought = true;
        if (resourceVault.items[0] >= 50f)
        {

        }
    }

    #endregion

    #region Stone Upgrade

    public void UpgradeStoneGrinder(GameObject objToUpgrade, bool tureorFalse, int whatVersion)
    {
        Vector3 mousePos = Camera.main.ViewportToWorldPoint(Input.mousePosition);
        if(whatVersion == 0)
        {
            VisualsObject = stoneMineV2Visuals;

            VisualsObject.transform.position = Camera.main.WorldToViewportPoint(mousePos);

            VisualsObject.transform.position += new Vector3(100, 0, 0);

            VisualsObject.SetActive(tureorFalse);
        }

        if(whatVersion == 1)
        {
            VisualsObject = stoneMineV3Visuals;

            VisualsObject.transform.position = Camera.main.WorldToViewportPoint(mousePos);

            VisualsObject.transform.position += new Vector3(100, 0, 0);

            VisualsObject.SetActive(tureorFalse);
        }

        if(whatVersion == 2)
        {

            stoneMineV2Visuals.SetActive(tureorFalse);
            stoneMineV3Visuals.SetActive(tureorFalse);

        }

        if (tureorFalse)
        {
            objectToUpgrade = objToUpgrade;
        }
    }

    public void UpgradeStoneGrinderButton()
    {
        objectToUpgrade.gameObject.GetComponent<ResourceTower>().Upgrade();

        objectToUpgrade.gameObject.GetComponent<StoneGridScript>().howManyUpgrade++;
        if (resourceVault.items[0] >= 50f)
        {

        }
    }

    #endregion

    #region Iron Upgrade

    public void UpgradeIronMine(GameObject objToUpgrade, bool tureorFalse, int whatVersion)
    {
        Vector3 mousePos = Camera.main.ViewportToWorldPoint(Input.mousePosition);
        if (whatVersion == 0)
        {
            VisualsObject = ironMineV2Visuals;

            VisualsObject.transform.position = Camera.main.WorldToViewportPoint(mousePos);

            VisualsObject.transform.position += new Vector3(100, 0, 0);

            VisualsObject.SetActive(tureorFalse);
        }

        if (whatVersion == 1)
        {
            VisualsObject = ironMineV3Visuals;

            VisualsObject.transform.position = Camera.main.WorldToViewportPoint(mousePos);

            VisualsObject.transform.position += new Vector3(100, 0, 0);

            VisualsObject.SetActive(tureorFalse);
        }

        if (whatVersion == 2)
        {

            ironMineV2Visuals.SetActive(tureorFalse);
            ironMineV3Visuals.SetActive(tureorFalse);

        }

        if (tureorFalse)
        {
            objectToUpgrade = objToUpgrade;
        }
    }

    public void UpgradeIronMineButton()
    {
        objectToUpgrade.gameObject.GetComponent<ResourceTower>().Upgrade();

        objectToUpgrade.gameObject.GetComponent<IronScript>().howManyUpgrade++;
        if (resourceVault.items[0] >= 50f)
        {

        }
    }

    #endregion

    #region Tree Upgrades

    public void UpgradeSawMill(GameObject objToUpgrade, bool tureorFalse, int whatVersion)
    {
        Vector3 mousePos = Camera.main.ViewportToWorldPoint(Input.mousePosition);
        if (whatVersion == 0)
        {
            VisualsObject = SawMillUpgrade;

            VisualsObject.transform.position = Camera.main.WorldToViewportPoint(mousePos);

            VisualsObject.transform.position += new Vector3(100, 0, 0);

            VisualsObject.SetActive(tureorFalse);
        }

        if (whatVersion == 1)
        {
            VisualsObject = null;

            VisualsObject.transform.position = Camera.main.WorldToViewportPoint(mousePos);

            VisualsObject.transform.position += new Vector3(100, 0, 0);

            VisualsObject.SetActive(tureorFalse);
        }

        if (whatVersion == 2)
        {

            SawMillUpgrade.SetActive(tureorFalse);
            //ironMineV3Visuanulls.SetActive(tureorFalse);

        }

        if (tureorFalse)
        {
            objectToUpgrade = objToUpgrade;
        }
    }

    public void UpgradeSawMillButton()
    {
        objectToUpgrade.gameObject.GetComponent<ResourceTower>().Upgrade();

        objectToUpgrade.gameObject.GetComponent<TreeGridScript>().howManyUpgrade++;
        if (resourceVault.items[0] >= 50f)
        {

        }
    }

    #endregion

    public void DisapereVisuals()
    {
        if(VisualsObject != null)
        {
            VisualsObject.SetActive(false);
        }
    }

    #endregion
}
