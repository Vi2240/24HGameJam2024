using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceVault : MonoBehaviour
{
    [Header("ItemID \n Money = 0 \n Wood = 1 \n Stone = 2 \n Iron = 3")]
    [SerializeField] float[] items;

    [Header("Text \n Money = 0 \n Wood = 1 \n Stone = 2 \n Iron = 3")]
    [SerializeField] TextMeshProUGUI[] text;

    private void Start()
    {
        for(int i = 0; i < 4; i++)
        {
            text[i].text = items[i].ToString();
        }
    }

    public void ModifyItemByID(int id, float amount)
    {
        items[id] += amount;

        text[id].text = items[id].ToString();
    }
}
