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

    int whatVersionToUpgrade;

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
                item.boughtSawMill = true;
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
                item.boughtStoneGrinder = true;
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
                item.boughtIronMine = true;
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
        if (resourceVault.items[0] >= 75f && resourceVault.items[1] >= 40)
        {
            objectToUpgrade.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            objectToUpgrade.gameObject.transform.GetChild(3).gameObject.SetActive(true);

            objectToUpgrade.gameObject.transform.GetComponent<BasicGridScript>().turretUpgradeIsBought = true;

            resourceVault.items[0] -= 75f;
            resourceVault.items[1] -= 40f;
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
        if (resourceVault.items[0] >= 50f && resourceVault.items[1] >= 35f && resourceVault.items[2] >= 10f)
        {
            objectToUpgrade.gameObject.GetComponent<ResourceTower>().Upgrade();

            objectToUpgrade.gameObject.GetComponent<BasicGridScript>().bankUpgradeIsBought = true;

            resourceVault.items[0] -= 50;
            resourceVault.items[1] -= 35;
            resourceVault.items[2] -= 10;
        }
    }

    #endregion

    #region Stone Upgrade

    public void UpgradeStoneGrinder(GameObject objToUpgrade, bool tureorFalse, int whatVersion)
    {
        Vector3 mousePos = Camera.main.ViewportToWorldPoint(Input.mousePosition);
        whatVersionToUpgrade = whatVersion;

        if(whatVersionToUpgrade == 0)
        {
            VisualsObject = stoneMineV2Visuals;

            VisualsObject.transform.position = Camera.main.WorldToViewportPoint(mousePos);

            VisualsObject.transform.position += new Vector3(100, 0, 0);

            VisualsObject.SetActive(tureorFalse);
        }

        if(whatVersionToUpgrade == 1)
        {
            VisualsObject = stoneMineV3Visuals;

            VisualsObject.transform.position = Camera.main.WorldToViewportPoint(mousePos);

            VisualsObject.transform.position += new Vector3(100, 0, 0);

            VisualsObject.SetActive(tureorFalse);
        }

        if(whatVersionToUpgrade == 2)
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


        if (whatVersionToUpgrade == 0)
        {
            if (resourceVault.items[0] >= 100f && resourceVault.items[1] >= 35 && resourceVault.items[2] >= 10)
            {


                resourceVault.items[0] -= 100;
                resourceVault.items[1] -= 35;
                resourceVault.items[2] -= 10;
            }
        }

        if (whatVersionToUpgrade == 1)
        {
            if (resourceVault.items[0] >= 150f && resourceVault.items[1] >= 50 && resourceVault.items[2] >= 25 && resourceVault.items[3] >= 5)
            {


                resourceVault.items[0] -= 150;
                resourceVault.items[1] -= 50f;
                resourceVault.items[2] -= 25;
                resourceVault.items[0] -= 5;
            }
        }
    }

    #endregion

    #region Iron Upgrade

    public void UpgradeIronMine(GameObject objToUpgrade, bool tureorFalse, int whatVersion)
    {
        Vector3 mousePos = Camera.main.ViewportToWorldPoint(Input.mousePosition);

        whatVersionToUpgrade = whatVersion;

        if (whatVersionToUpgrade == 0)
        {
            VisualsObject = ironMineV2Visuals;

            VisualsObject.transform.position = Camera.main.WorldToViewportPoint(mousePos);

            VisualsObject.transform.position += new Vector3(100, 0, 0);

            VisualsObject.SetActive(tureorFalse);
        }

        if (whatVersionToUpgrade == 1)
        {
            VisualsObject = ironMineV3Visuals;

            VisualsObject.transform.position = Camera.main.WorldToViewportPoint(mousePos);

            VisualsObject.transform.position += new Vector3(100, 0, 0);

            VisualsObject.SetActive(tureorFalse);
        }

        if (whatVersionToUpgrade == 2)
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

        if (whatVersionToUpgrade == 0)
        {
            if (resourceVault.items[0] >= 150f && resourceVault.items[1] >= 75 && resourceVault.items[2] >= 30 && resourceVault.items[3] >= 15)
            {
                objectToUpgrade.gameObject.GetComponent<ResourceTower>().Upgrade();

                objectToUpgrade.gameObject.GetComponent<IronScript>().howManyUpgrade++;

                resourceVault.items[0] -= 150;
                resourceVault.items[1] -= 75;
                resourceVault.items[2] -= 30;
                resourceVault.items[3] -= 15;
            }
        }

        if(whatVersionToUpgrade == 1)
        {
            if (resourceVault.items[0] >= 200f && resourceVault.items[1] >= 100 && resourceVault.items[2] >= 50 && resourceVault.items[3] >= 25)
            {
                objectToUpgrade.gameObject.GetComponent<ResourceTower>().Upgrade();

                objectToUpgrade.gameObject.GetComponent<IronScript>().howManyUpgrade++;

                resourceVault.items[0] -= 200f;
                resourceVault.items[1] -= 100f;
                resourceVault.items[2] -= 50;
                resourceVault.items[0] -= 25;
            }
        }
    }

    #endregion

    #region SawMill Upgrades

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
        if (resourceVault.items[0] >= 75f && resourceVault.items[1] >= 40)
        {

            objectToUpgrade.gameObject.GetComponent<ResourceTower>().Upgrade();

            objectToUpgrade.gameObject.GetComponent<TreeGridScript>().howManyUpgrade++;

            resourceVault.items[1] -= 40;
            resourceVault.items[0] -= 75;
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
