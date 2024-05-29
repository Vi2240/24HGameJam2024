using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    #region Grid

    int gridX = 100;
    int gridY = 100;

    int maxX = 100;
    int maxY = 100;

    int howManyUppNegative = 1;
    int howManyDownNegative = 0;
    int howManyUppPosetive = 1;
    int howManyDownPosetive = 0;

    #endregion

    #region Grid Pieces

    public GameObject BasicGridPiece;
    public GameObject TreeGridPiece;
    public GameObject StoneGridPiece;
    public GameObject IronGridPiece;

    #endregion

    float randomNumberBasic1 = 0;
    float randomNumberBasic2 = 93;
    float randomNumberTree = 97;
    float randomNumberStone = 100;
    float randomNumberIron = 101;

    private void Start()
    {
        while (true)
        {
            gridX = maxX;
            while (true)
            {
                float Number = Random.Range(0, 101);
                if (Number >= randomNumberBasic1 && Number < randomNumberBasic2)
                {
                    GameObject spawnedPiece = Instantiate(BasicGridPiece);

                    spawnedPiece.transform.position = new Vector2(gridX, howManyUppPosetive);
                }
                if (Number >= randomNumberBasic2 && Number < randomNumberTree)
                {
                    GameObject spawnedPiece = Instantiate(TreeGridPiece);

                    spawnedPiece.transform.position = new Vector2(gridX, howManyUppPosetive);
                }
                if (Number >= randomNumberTree && Number < randomNumberStone)
                {
                    GameObject spawnedPiece = Instantiate(StoneGridPiece);

                    spawnedPiece.transform.position = new Vector2(gridX, howManyUppPosetive);
                }
                if (Number >= randomNumberStone && Number < randomNumberIron)
                {
                    GameObject spawnedPiece = Instantiate(IronGridPiece);

                    spawnedPiece.transform.position = new Vector2(gridX, howManyUppPosetive);
                }

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
                float Number = Random.Range(0, 101);
                if (Number >= randomNumberBasic1 && Number < randomNumberBasic2)
                {
                    GameObject spawnedPiece = Instantiate(BasicGridPiece);

                    spawnedPiece.transform.position = new Vector2(gridX, howManyDownPosetive);
                }
                if (Number >= randomNumberBasic2 && Number < randomNumberTree)
                {
                    GameObject spawnedPiece = Instantiate(TreeGridPiece);

                    spawnedPiece.transform.position = new Vector2(gridX, howManyDownPosetive);
                }
                if (Number >= randomNumberTree && Number < randomNumberStone)
                {
                    GameObject spawnedPiece = Instantiate(StoneGridPiece);

                    spawnedPiece.transform.position = new Vector2(gridX, howManyDownPosetive);
                }
                if (Number >= randomNumberStone && Number < randomNumberIron)
                {
                    GameObject spawnedPiece = Instantiate(IronGridPiece);

                    spawnedPiece.transform.position = new Vector2(gridX, howManyDownPosetive);
                }

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

                float Number = Random.Range(0, 101);
                if (Number >= randomNumberBasic1 && Number < randomNumberBasic2)
                {
                    GameObject spawnedPiece = Instantiate(BasicGridPiece);

                    spawnedPiece.transform.position = new Vector2(gridX, howManyUppNegative);
                }
                if (Number >= randomNumberBasic2 && Number < randomNumberTree)
                {
                    GameObject spawnedPiece = Instantiate(TreeGridPiece);

                    spawnedPiece.transform.position = new Vector2(gridX, howManyUppNegative);
                }
                if (Number >= randomNumberTree && Number < randomNumberStone)
                {
                    GameObject spawnedPiece = Instantiate(StoneGridPiece);

                    spawnedPiece.transform.position = new Vector2(gridX, howManyUppNegative);
                }
                if (Number >= randomNumberStone && Number < randomNumberIron)
                {
                    GameObject spawnedPiece = Instantiate(IronGridPiece);

                    spawnedPiece.transform.position = new Vector2(gridX, howManyUppNegative);
                }

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


                float Number = Random.Range(0, 101);
                if (Number >= randomNumberBasic1 && Number < randomNumberBasic2)
                {
                    GameObject spawnedPiece = Instantiate(BasicGridPiece);

                    spawnedPiece.transform.position = new Vector2(gridX, howManyDownNegative);
                }
                if (Number >= randomNumberBasic2 && Number < randomNumberTree)
                {
                    GameObject spawnedPiece = Instantiate(TreeGridPiece);

                    spawnedPiece.transform.position = new Vector2(gridX, howManyDownNegative);
                }
                if (Number >= randomNumberTree && Number < randomNumberStone)
                {
                    GameObject spawnedPiece = Instantiate(StoneGridPiece);

                    spawnedPiece.transform.position = new Vector2(gridX, howManyDownNegative);
                }
                if (Number >= randomNumberStone && Number < randomNumberIron)
                {
                    GameObject spawnedPiece = Instantiate(IronGridPiece);

                    spawnedPiece.transform.position = new Vector2(gridX, howManyDownNegative);
                }

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
