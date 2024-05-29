using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    int gridX = 100;
    int gridY = 100;

    int maxX = 10;
    int maxY = 10;

    int howManyUppNegative = 0;
    int howManyDownNegative = 0;
    int howManyUppPosetive = 0;
    int howManyDownPosetive = 0;

    bool complete = false;

    public GameObject gridPiece;

    private void Start()
    {
        while (true)
        {
            gridX = maxX;
            while (true)
            {
                GameObject spawnedPiece = Instantiate(gridPiece);

                spawnedPiece.transform.position = new Vector2(gridX, howManyUppPosetive);

                gridX--;

                if (gridX < 0)
                {
                    howManyUppPosetive++;
                    break;
                }
            }
            gridX = maxX;

            gridX = maxX;
            while (true)
            {
                GameObject spawnedPiece = Instantiate(gridPiece);

                spawnedPiece.transform.position = new Vector2(gridX, howManyDownPosetive);

                gridX--;

                if (gridX < 0)
                {
                    howManyDownPosetive--;
                    break;
                }
            }

            gridX = -maxX;

            while (true)
            {
                GameObject spawnedPiece = Instantiate(gridPiece);

                spawnedPiece.transform.position = new Vector2(gridX, howManyUppNegative);

                gridX++;

                if (gridX >= 0)
                {
                    howManyUppNegative++;
                    break;
                }
            }

            gridX = -maxX;

            while (true)
            {
                GameObject spawnedPiece = Instantiate(gridPiece);

                spawnedPiece.transform.position = new Vector2(gridX, howManyDownNegative);

                gridX++;

                if (gridX >= 0)
                {
                    howManyDownNegative--;
                    break;
                }
            }

            if (howManyUppPosetive >= 100)
            {
                break;
            }
        }
    }

    private void Update()
    {

        //for (int i = 0; i < gridX; i++)
        //{
        //    for (int j = 0; j < gridY; j++)
        //    {
        //        GameObject spawnedPiece = Instantiate(gridPiece);

        //        spawnedPiece.transform.position = new Vector2(gridX, gridY);

        //        //gridX++;

        //        //spawnedPiece = Instantiate(spawnedPiece);

        //        //spawnedPiece.transform.position = new Vector2(gridX, gridY);

        //        //gridY++;

        //        Debug.Log(gridX);
        //        Debug.Log(gridY);
        //    }
        //}
    }
}
