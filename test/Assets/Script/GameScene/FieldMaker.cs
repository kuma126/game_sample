using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
@ brief �}�b�v�����C��Փx�ɉ����ĕύX
*/
public class FieldMaker : MonoBehaviour
{
    public static FieldMaker Instance = null;
    private int mapLevel;   // �}�b�v�̃��x�������߂�ϐ�
    public GameObject road;  // �n��
    public GameObject ground;  // ���H
    public GameObject store;
    private const int fieldSize = 10;    
    private Block[,] fieldData = new Block[fieldSize, fieldSize]; // 0:�� 1:�XA 2:�XB 3:�XC
    private GameObject[,] fieldObjectData = new GameObject[fieldSize, fieldSize];
    

    private enum Block
    {
        Road,
        Ground,
        Store,
    }
    
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

        //  フィールド初期化
        for (int i = 0; i < fieldSize; i++)
        {
            for (int j = 0; j < fieldSize; j++)
            {
                fieldData[i, j] = Block.Ground;
            }
        }
        for (int i = 0; i < fieldSize; i++)
        {
            fieldData[fieldSize / 2, i] = Block.Road;
        }

        for (int i = 0; i < fieldSize; i++)
        {
            for(int j = 0; j < fieldSize; j++) {
                Vector3 pos;
                pos.x = i * 1;
                pos.z = j * 1;
                pos.y = 0;
                SetInstance(pos, fieldData[i,j]);
            }
        }
        
    }

    private void Update()
    {
        
    }

    /*
    @ brief �C���X�^���X�̐���
    @ param Position ��������ʒu(vector3)
    @ param ObjNumber 0:�� 1:�XA 2:�XB 3:�XC
    */
    void SetInstance(Vector3 position, Block blockType)
    {
        switch (blockType)
        {
        case Block.Road:
            fieldObjectData[(int)position.x, (int)position.z] = Instantiate(road, position, Quaternion.identity, this.gameObject.transform);
            break;
        case Block.Ground:
            fieldObjectData[(int)position.x, (int)position.z] = Instantiate(ground, position, Quaternion.identity, this.gameObject.transform);
            break;
        case Block.Store:
            fieldObjectData[(int)position.x, (int)position.z] = Instantiate(store, position, Quaternion.identity, this.gameObject.transform);
            break;

        }
        
    }

    /*
    @ brief �}�b�v�̃��x����ݒ�
    */
    void SetMapLevel(int levelNum)
    {
        mapLevel = levelNum;
    }

    public void Click(Vector3 clickPos)
    {
        int x = (int)(clickPos.x + 0.5);
        int z = (int)(clickPos.z + 0.5);
        if (x < 0 || z < 0 || x >= fieldSize || z >= fieldSize) return;
        if (fieldData[x, z] == Block.Road) return;  // 道路上には建築不可
        if (!IsNextToRoad(x, z)) return;            // 道路から離れた場所には建築不可

        if (fieldData[x,z] == Block.Ground)
        {
            Build(x, z, Block.Store);
        }
        else if (fieldData[x,z] == Block.Store)
        {
            RankUp(x, z);
        }

    }

    private void Build(int x, int z, Block blockType) 
    {
        Destroy(fieldObjectData[x, z]);
        SetInstance(new Vector3(x, 0, z), blockType);
        fieldData[x, z] = blockType;        
    }

    private void RankUp(int x, int z)
    {
        // GetComponentは重い？　ランクアップはそこまで多くないから許容？
        var storeScript = fieldObjectData[x, z].GetComponent<Store>();
        storeScript.RankUp();
    }
  
    // roadに接しているか
    private bool IsNextToRoad(int x, int z)
    {
        var dx = new int[4] { 0, -1, 0, 1 };
        var dz = new int[4] { 1, 0, -1, 0 };

        for (int i = 0; i < 4; i++)
        {
            var newX = x + dx[i];
            var newZ = z + dz[i];
            if (newX < 0 || newZ < 0 || newX >= fieldSize || newZ >= fieldSize) continue;
            if (fieldData[newX, newZ] == Block.Road) return true;
        }

        return false;
    }

   
}
