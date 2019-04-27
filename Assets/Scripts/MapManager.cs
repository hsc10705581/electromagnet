using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    /*
     *      1 
     *    2   4
     *      3
     */

    public GameObject[] OneSideMagneticWall;
    public GameObject[] twoSideMagneticWall;
    public GameObject[] threeSideMagneticWall;
    public GameObject fourSideMagneticWall;
    public GameObject wall;
    public GameObject water;
    public GameObject land;
    public GameObject exit;

    public int rows = 11;
    public int columns = 11;

    private Transform MapHolder;

    /* OneSide:         1   2   3   4
     * TwoSide:         5   6   7   8   9(13)   10(24)
     * ThreeSide:       11  12  13  14
     * FourSide:        15
     * wall:            16
     * water:           17
     * land:            18
     * exit:            19
     */
    
    private int[,] simpleMapInfo = {
        {16, 16, 16, 16, 16, 01, 16, 16, 16, 16, 16},
        {16, 17, 17, 17, 17, 18, 17, 17, 17, 17, 16},
        {16, 17, 17, 17, 17, 17, 17, 17, 17, 17, 16},
        {16, 17, 17, 17, 17, 17, 17, 17, 17, 17, 16},
        {16, 17, 17, 17, 17, 17, 17, 17, 17, 17, 16},
        {16, 17, 17, 17, 17, 17, 17, 17, 17, 17, 16},
        {16, 17, 17, 17, 17, 17, 17, 17, 17, 17, 16},
        {16, 17, 17, 17, 17, 17, 17, 17, 17, 17, 16},
        {16, 17, 17, 17, 17, 17, 17, 17, 17, 17, 16},
        {16, 17, 17, 17, 17, 19, 17, 17, 17, 17, 16},
        {16, 16, 16, 16, 16, 03, 16, 16, 16, 16, 16}
    };
    
    private GameObject num2Object(int num)
    {
        switch (num)
        {
            case 1:
                return OneSideMagneticWall[0];
            case 2:
                return OneSideMagneticWall[1];
            case 3:
                return OneSideMagneticWall[2];
            case 4:
                return OneSideMagneticWall[3];
            case 5:
                return twoSideMagneticWall[0];
            case 6:
                return twoSideMagneticWall[1];
            case 7:
                return twoSideMagneticWall[2];
            case 8:
                return twoSideMagneticWall[3];
            case 9:
                return twoSideMagneticWall[4];
            case 10:
                return twoSideMagneticWall[5];
            case 11:
                return threeSideMagneticWall[0];
            case 12:
                return threeSideMagneticWall[1];
            case 13:
                return threeSideMagneticWall[2];
            case 14:
                return threeSideMagneticWall[3];
            case 15:
                return fourSideMagneticWall;
            case 16:
                return wall;
            case 17:
                return water;
            case 18:
                return land;
            case 19:
                return exit;
            default:
                return null;
        }
    }

    public void Start()
    {
        InitMap();
    }

    public void InitMap()
    {
        MapHolder = new GameObject("Map").transform;
        for(int x = 0; x < columns; x++)
        {
            for(int y = 0; y < rows; y++)
            {
                GameObject go = GameObject.Instantiate(num2Object(simpleMapInfo[y,x]), new Vector3(x, y, 0), Quaternion.identity) as GameObject;
                go.transform.SetParent(MapHolder);
            }
        }
    }


}
