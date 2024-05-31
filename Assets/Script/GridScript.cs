using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    #region Grid

    int gridX = 100;
    int gridY = 100;

    int maxX = 10;
    int maxY = 10;

    int howManyUppPosetive = 1;
    int howManyDownPosetive = 0;

    int howManyUppNegative = 1;
    int howManyDownNegative = 0;

    #endregion

    #region Grid Pieces

    public GameObject BasicGridPiece;
    public GameObject TreeGridPiece;
    public GameObject StoneGridPiece;
    public GameObject IronGridPiece;
    public GameObject BaseGridPiece;

    #endregion

    #region RandomChance

    float randomNumberBasic1 = 0;
    float randomNumberBasic2 = 96f;
    float randomNumberTree = 98.5f;
    float randomNumberStone = 100f;
    float randomNumberIron = 100.1f;

    #endregion

    private void Start()
    {
        while (true)
        {
            gridX = maxX;
            while (true)
            {
                PlacePiece(howManyUppPosetive);

                gridX--;

                if (gridX < 0)
                {
                    howManyUppPosetive++;
                    break;
                }
            }

            gridX = maxX;

            while (true)
            {
                PlacePiece(howManyDownPosetive);

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
                PlacePiece(howManyUppNegative);

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
                PlacePiece(howManyDownNegative);

                gridX++;

                if (gridX >= 0)
                {
                    howManyDownNegative--;
                    break;
                }
            }

            if (howManyUppPosetive >= maxY)
            {
                break;
            }
        }
    }

    private void PlacePiece(int uppOrDown)
    {
        //if(uppOrDown == 0 && gridX == 0 || uppOrDown == 0 && gridX == 1 || uppOrDown == 0 && gridX == -1 || uppOrDown == 1 && gridX == 0 || uppOrDown == 1 && gridX == 1 || uppOrDown == 1 && gridX == -1 || uppOrDown == -1 && gridX == 0 || uppOrDown == -1 && gridX == 1 || uppOrDown == -1 && gridX == -1)
        //{
        //    if(uppOrDown == 0 && gridX == 0)
        //    {
        //        GameObject spawnBasePiece = Instantiate(BaseGridPiece);

        //        spawnBasePiece.transform.position = new Vector2(gridX, uppOrDown);
        //    }
        //    GameObject spawnedPiece = Instantiate(BasicGridPiece);

        //    spawnedPiece.transform.position =  new Vector2(gridX, uppOrDown);
        //}
        //else
        //{
        //}
            float Number = Random.Range(0, 101);
            if (Number >= randomNumberBasic1 && Number < randomNumberBasic2)
            {
                GameObject spawnedPiece = Instantiate(BasicGridPiece);

                spawnedPiece.transform.position = new Vector2(gridX, uppOrDown);
            }

            if (Number >= randomNumberBasic2 && Number < randomNumberTree)
            {
                GameObject spawnedPiece = Instantiate(TreeGridPiece);

                spawnedPiece.transform.position = new Vector2(gridX, uppOrDown);
            }

            if (Number >= randomNumberTree && Number < randomNumberStone)
            {
                GameObject spawnedPiece = Instantiate(StoneGridPiece);

                spawnedPiece.transform.position = new Vector2(gridX, uppOrDown);
            }

            if (Number >= randomNumberStone && Number < randomNumberIron)
            {
                GameObject spawnedPiece = Instantiate(IronGridPiece);

                spawnedPiece.transform.position = new Vector2(gridX, uppOrDown);
            }
    }
}
