using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTower : MonoBehaviour
{
    [Header("ItemID \n Money = 0 \n Wood = 1 \n Stone = 2 \n Iron = 3")]
    [SerializeField] int itemID;

    [Header("ResourceGathering")]
    [Header("1")]
    [SerializeField] float amountOfItem;
    [Header("2 \n 3 \n 5 \n 10")]
    [SerializeField] float produceRate;

    bool timeToGive;

    ResourceVault resourceVault;

    [Header("LvlsThings")]
    [SerializeField] GameObject[] skins;
    [SerializeField] float[] modifyPercentForUpgrade;

    int lvl;

    void Start()
    {
        resourceVault = FindObjectOfType<ResourceVault>();

        StartCoroutine(ProduceRate());
    }

    void Update()
    {
        if(timeToGive == true)
        {
            resourceVault.ModifyItemByID(itemID, amountOfItem * modifyPercentForUpgrade[lvl]);

            StartCoroutine(ProduceRate());
        }
    }

    public void Upgrade()
    {
        skins[lvl].SetActive(false);

        lvl++;

        skins[lvl].SetActive(true);
    }

    IEnumerator ProduceRate()
    {
        timeToGive = false;

        yield return new WaitForSeconds(produceRate);

        timeToGive = true;
    }
}
