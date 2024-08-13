using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
@ brief マップを作る，難易度に応じて変更
*/
public class FieldMaker : MonoBehaviour
{
    public static FieldMaker Instance = null;
    private int mapLevel;   // マップのレベルを決める変数
    public GameObject Obj0;  // 地面
    public GameObject Obj1;  // 道路
    public GameObject Obj2;  // storeA
    public GameObject Obj3;  // storeB
    public GameObject Obj4;  // storeC
    private const int fieldSize = 10;    
    private int[,] fieldData = new int[fieldSize, fieldSize]; // 0:道 1:店A 2:店B 3:店C
    //private GameObject[,] fieldObjectData = new GameObject[fieldSize, fieldSize];
    
    private void Awake()
    {
        // シングルトン
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        //マップ情報の初期化
        for (int i = 0; i < fieldSize; i++)
        {
            for(int j = 0; j < fieldSize; j++) {
                Vector3 pos;
                pos.x = i * 1;
                pos.z = j * 1;
                pos.y = 0;
                fieldData[i,j] = 0;
                SetInstance(pos, fieldData[i,j]);
            }
        }
        
    }

    /*
    @ brief インスタンスの生成
    @ param Position 生成する位置(vector3)
    @ param ObjNumber 0:道 1:店A 2:店B 3:店C
    */
    void SetInstance(Vector3 Position, int ObjNumber)
    {
        GameObject g;
        switch (ObjNumber)
        {
        case 0:
            g = Instantiate(Obj0, Position, Quaternion.identity);
            break;
        case 1:
            g = Instantiate(Obj1, Position, Quaternion.identity);
            break;
        case 2:
            g = Instantiate(Obj2, Position, Quaternion.identity);
            break;
        case 3:
            g = Instantiate(Obj3, Position, Quaternion.identity);
            break;
        case 4:
            g = Instantiate(Obj4, Position, Quaternion.identity);
            break;
        }
        //fieldObjectData[(int)Position.x, (int)Position.z] = g;
    }

    /*
    @ brief マップのレベルを設定
    */
    void SetMapLevel(int levelNum)
    {
        mapLevel = levelNum;
    }

    void Build(int x, int y, int objectNum) 
    {

    }
}
