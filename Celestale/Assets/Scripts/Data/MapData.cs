using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData
{
    private static MapData _instance=new MapData();
    public static MapData instance { get { return _instance ; } }
    public Vector2[][] mapVec = new Vector2[9][];
    public Vector2[] stage1 = new Vector2[5];
    private MapData()
    {
        mapVec[0] = new Vector2[4];
        mapVec[0][0] = new Vector2(-4, 0);
        mapVec[0][1] = new Vector2(11, 0);
        mapVec[0][2] = new Vector2(11, -6);
        mapVec[0][3] = new Vector2(-4, -6);
    }
}
