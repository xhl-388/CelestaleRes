using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData
{
    private static MapData _instance=new MapData();
    public static MapData instance { get { return _instance ; } }
    public Vector2[][] mapVec = new Vector2[7][];
    private MapData()
    {
        mapVec[0] = new Vector2[2];
        mapVec[0][0] = new Vector2(-2, -2);
        mapVec[0][1] = new Vector2(11, -2);

        mapVec[1] = new Vector2[7];
        mapVec[1][0] = new Vector2(6, -2);
        mapVec[1][1] = new Vector2(3, -2);
        mapVec[1][2] = new Vector2(3, 3);
        mapVec[1][3] = new Vector2(-1, 3);
        mapVec[1][4] = new Vector2(-1, -2);
        mapVec[1][5] = new Vector2(-4, -2);
        mapVec[1][6] = new Vector2(-4, 5);

        mapVec[2] = new Vector2[6];
        mapVec[2][0] = new Vector2(3,2);
        mapVec[2][1] = new Vector2(3,3);
        mapVec[2][2] = new Vector2(1,3);
        mapVec[2][3] = new Vector2(1,2);
        mapVec[2][4] = new Vector2(-2,2);
        mapVec[2][5] = new Vector2(-2,6);

        mapVec[3] = new Vector2[3];
        mapVec[3][0] = new Vector2(1, -3);
        mapVec[3][1] = new Vector2(1, 1);
        mapVec[3][2] = new Vector2(9, 1);

        mapVec[4] = new Vector2[4];
        mapVec[4][0] = new Vector2(4,-3);
        mapVec[4][1] = new Vector2(4,0);
        mapVec[4][2] = new Vector2(0,0);
        mapVec[4][3] = new Vector2(0,-5);

        mapVec[5] = new Vector2[7];
        mapVec[5][0] = new Vector2(2,-3);
        mapVec[5][1] = new Vector2(2,-1);
        mapVec[5][2] = new Vector2(-3,-1);
        mapVec[5][3] = new Vector2(-3,2);
        mapVec[5][4] = new Vector2(7,2);
        mapVec[5][5] = new Vector2(7,0);
        mapVec[5][6] = new Vector2(9,0);

        mapVec[6] = new Vector2[9];
        mapVec[6][0] = new Vector2(-6,-5);
        mapVec[6][1] = new Vector2(-6,2);
        mapVec[6][2] = new Vector2(4,2);
        mapVec[6][3] = new Vector2(4,-4);
        mapVec[6][4] = new Vector2(-4,-4);
        mapVec[6][5] = new Vector2(-4,0);
        mapVec[6][6] = new Vector2(3,0);
        mapVec[6][7] = new Vector2(3,-2);
        mapVec[6][8] = new Vector2(-2,-2);
    }
}
