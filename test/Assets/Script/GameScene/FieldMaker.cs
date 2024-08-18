using OpenCover.Framework.Model;
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

    //フィールドのサイズそれぞれ
    private const int fieldSize = 30;

    private Block[,] fieldData = new Block[fieldSize, fieldSize]; // 0:�� 1:�XA 2:�XB 3:�XC
    private GameObject[,] fieldObjectData = new GameObject[fieldSize, fieldSize];

    private enum Block
    {
        Road,
        Ground,
        Store,
    }

    private enum Direction
    {
        North,
        East,
        South,
        West,
        None,
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
        //ステージ選択画面から
        mapLevel = SelectManager.fieldNumber;


        switch (mapLevel)
        {
            case 0:
                CreateMapA();
                break;
            case 1:
                CreateMapB();
                break;
            case 2:
                CreateMapC();
                break;
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

    private void CreateMapA()
    {
        for (int i = 0; i < fieldSize; i++)
        {
            for (int j = 0; j < fieldSize; j++)
            {
                fieldData[i, j] = Block.Ground;
            }
        }
        for (int i = 0; i < fieldSize; i++)
        { 
            //メインロード
            fieldData[fieldSize / 2, i] = Block.Road;
            fieldData[fieldSize / 2 + 1, i] = Block.Road;
            fieldData[fieldSize / 2 - 1 , i] = Block.Road;

            //周りの道
            fieldData[0,i] = Block.Road;
            fieldData[1, i] = Block.Road;
            fieldData[fieldSize - 1, i] = Block.Road;
            fieldData[fieldSize - 2, i] = Block.Road;

            fieldData[i,0] = Block.Road;
            fieldData[i, 1] = Block.Road;
            fieldData[i, fieldSize - 1] = Block.Road;
            fieldData[i, fieldSize - 2] = Block.Road;
        }
    }

    private void CreateMapB()
    {
        for (int i = 0; i < fieldSize; i++)
        {
            for (int j = 0; j < fieldSize; j++)
            {
                fieldData[i, j] = Block.Ground;
            }
        }

        for (int i = 0; i < fieldSize; i++)
        {
            //メインロード
            fieldData[fieldSize / 3, i] = Block.Road;
            fieldData[fieldSize / 3 - 1, i] = Block.Road;
            fieldData[(fieldSize * 2 / 3), i] = Block.Road;
            fieldData[(fieldSize * 2 / 3) + 1, i] = Block.Road;

        }

        //枝分かれの細い道
        for(int i = 0; i<fieldSize / 3; i++)
        {
            fieldData[i, fieldSize / 4] = Block.Road;
            fieldData[i, fieldSize / 2] = Block.Road;
        }

        for (int i = fieldSize * 2 /3; i < fieldSize; i++)
        {
            fieldData[i, fieldSize / 3] = Block.Road;
            fieldData[i, fieldSize * 2 / 3] = Block.Road;
        }

    }

    private void CreateMapC()
    {
        for (int i = 0; i < fieldSize; i++)
        {
            for (int j = 0; j < fieldSize; j++)
            {
                fieldData[i, j] = Block.Ground;
            }
        }

        for (int i = 0; i < fieldSize; i++)
        {
            //メインロード
            fieldData[fieldSize / 3, i] = Block.Road;
            fieldData[fieldSize / 3 - 1, i] = Block.Road;
            fieldData[(fieldSize * 2 / 3), i] = Block.Road;
            fieldData[(fieldSize * 2 / 3) + 1, i] = Block.Road;

            //周りの道
            fieldData[0, i] = Block.Road;
            fieldData[fieldSize - 1, i] = Block.Road;

            fieldData[i, 0] = Block.Road;
            fieldData[i, fieldSize - 1] = Block.Road;

        }

        //枝分かれの細い道
        for (int i = 0; i < fieldSize / 3; i++)
        {
            fieldData[i, fieldSize / 4] = Block.Road;
            fieldData[i, fieldSize / 2] = Block.Road;
        }

        for (int i = fieldSize * 2 / 3; i < fieldSize; i++)
        {
            fieldData[i, fieldSize / 3] = Block.Road;
            fieldData[i, fieldSize * 2 / 3] = Block.Road;
        }

        for(int i = fieldSize / 3; i < fieldSize * 2 / 3; i++)
        {
            fieldData[i, fieldSize / 2] = Block.Road;

        }

    }

    /*
    @ brief �C���X�^���X�̐���
    @ param Position ��������ʒu(vector3)
    @ param ObjNumber 0:�� 1:�XA 2:�XB 3:�XC
    */
    void SetInstance(Vector3 position, Block blockType, Direction direction = Direction.North)
    {
        var x = (int)position.x;
        var z = (int)position.z;
        var angle = (int)direction * 90;
        var rotation = Quaternion.identity * Quaternion.AngleAxis(angle, Vector3.up);

        switch (blockType)
        {
        case Block.Road:
            fieldObjectData[x, z] = Instantiate(road, position, rotation, this.gameObject.transform);
            break;
        case Block.Ground:
            fieldObjectData[x, z] = Instantiate(ground, position, rotation, this.gameObject.transform);
            break;
        case Block.Store:
            fieldObjectData[x, z] = Instantiate(store, position, rotation, this.gameObject.transform);
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

        var d = GetDirectionRoad(x, z);             // 面している道路の方向
        if (d == Direction.None) return;            // 道路から離れた場所には建築不可

        if (fieldData[x,z] == Block.Ground)
        {
            BuildStore(x, z, d);
        }
        else if (fieldData[x,z] == Block.Store)
        {
            RankUp(x, z);
        }

    }

    private void BuildStore(int x, int z, Direction direction) 
    {
        SetInstance(new Vector3(x, 0, z), Block.Store);
        fieldData[x, z] = Block.Store;        
    }

    private void RankUp(int x, int z)
    {
        // GetComponentは重い？　ランクアップはそこまで多くないから許容？
        var storeScript = fieldObjectData[x, z].GetComponent<Store>();
        storeScript.RankUp();
    }
  
    // roadに接している方向を返す
    private Direction GetDirectionRoad(int x, int z)
    {
        var dx = new int[4] { 0, 1, 0, -1 };
        var dz = new int[4] { -1, 0, 1, 0 };

        for (int i = 0; i < 4; i++)
        {
            var newX = x + dx[i];
            var newZ = z + dz[i];
            if (newX < 0 || newZ < 0 || newX >= fieldSize || newZ >= fieldSize) continue;
            if (fieldData[newX, newZ] == Block.Road) 
            {
                return (Direction)i;
            }
        }

        return Direction.None;
    }

    public GameObject GetStore(Vector3 targetPosition)
    {
        var x = (int)targetPosition.x;
        var z = (int)targetPosition.z;
        if ((x > 0 && x < fieldSize) && (z > 0 && z < fieldSize))
        {
            if (fieldData[x, z] != Block.Store)
            {
                return null;
            }
        }
        else
        {
            return null;
        }

        return fieldObjectData[x, z];
    }

    
}
