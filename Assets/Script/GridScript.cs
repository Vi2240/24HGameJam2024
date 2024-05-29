using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    int gridX = 100;
    int gridY = 100;

    int maxX = 100;
    int maxY = 100;

    public GameObject gridPiece;
    GameObject spawnedPiece = null;

    private void Start()
    {
        gridX = maxX;
        while(true)
        {
            GameObject spawnedPiece = Instantiate(gridPiece);

            spawnedPiece.transform.position = new Vector2(gridX, 0);

            gridX--;

            if(gridX <= 0)
            {
                break;
            }
        }
        gridX = -maxX;

        while (true)
        {
            GameObject spawnedPiece = Instantiate(gridPiece);

            spawnedPiece.transform.position = new Vector2(gridX, 0);

            gridX++;

            if (gridX >= 0)
            {
                break;
            }
        }


        //while (true)
        //{
        //    while(true)
        //    {
        //        break;
        //    }
        //    GameObject spawnedPiece = Instantiate(gridPiece);
            
        //    spawnedPiece.transform.position = new Vector2 (gridX, gridY);

        //    gridX++;

        //    spawnedPiece = Instantiate(spawnedPiece);

        //    spawnedPiece.transform.position = new Vector2(gridX, gridY);

        //    gridY++;

        //    Debug.Log(gridX);
        //    Debug.Log(gridY);

        //    if (gridY >= 1 && gridX >= 2)
        //    {
        //        break;
        //    }
        //}

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
