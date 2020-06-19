using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData
{
    private static MapData _instance=new MapData();
    public static MapData instance { get { return _instance ; } }
    public Dictionary<int, Vector2[]> mapDic = new Dictionary<int, Vector2[]>();
    public Vector2[] stage1 = new Vector2[5];
    private MapData()
    {
        stage1[0] = new Vector2(0, 0);
        stage1[1] = new Vector2(0, 1);
        stage1[2] = new Vector2(0, 2);
        stage1[3] = new Vector2(0, 3);
        stage1[4] = new Vector2(0, 4);
        mapDic.Add(1, stage1);
    }
}
