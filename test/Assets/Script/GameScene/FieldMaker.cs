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
    public GameObject Obj0;  // �n��
    public GameObject Obj1;  // ���H
    public GameObject Obj2;  // storeA
    public GameObject Obj3;  // storeB
    public GameObject Obj4;  // storeC
    private const int fieldSize = 10;    
    private int[,] fieldData = new int[fieldSize, fieldSize]; // 0:�� 1:�XA 2:�XB 3:�XC
    private GameObject[,] fieldObjectData = new GameObject[fieldSize, fieldSize];
    
    private void Awake()
    {
        // �V���O���g��
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
        //�}�b�v���̏�����
        for (int i = 0; i < fieldSize; i++)
        {
            for (int j = 0; j < fieldSize; j++)
            {
                fieldData[i, j] = 0;
            }
        }
        for (int i = 0; i < fieldSize; i++)
        {
            fieldData[fieldSize / 2, i] = 1;
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
    void SetInstance(Vector3 Position, int ObjNumber)
    {
        switch (ObjNumber)
        {
        case 0:
            fieldObjectData[(int)Position.x, (int)Position.z] = Instantiate(Obj0, Position, Quaternion.identity, this.gameObject.transform);
            break;
        case 1:
            fieldObjectData[(int)Position.x, (int)Position.z] = Instantiate(Obj1, Position, Quaternion.identity, this.gameObject.transform);
            break;
        case 2:
            fieldObjectData[(int)Position.x, (int)Position.z] = Instantiate(Obj2, Position, Quaternion.identity, this.gameObject.transform);
            break;
        case 3:
            fieldObjectData[(int)Position.x, (int)Position.z] = Instantiate(Obj3, Position, Quaternion.identity, this.gameObject.transform);
            break;
        case 4:
            fieldObjectData[(int)Position.x, (int)Position.z] = Instantiate(Obj4, Position, Quaternion.identity, this.gameObject.transform);
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

    public void Build(Vector3 hitPos, int objectNum) 
    {
        int x = (int)(hitPos.x + 0.5);
        int z = (int)(hitPos.z + 0.5);
        if (x < 0 || z < 0 || x >= fieldSize || z >= fieldSize) return;

        Destroy(fieldObjectData[x, z]);
        SetInstance(new Vector3(x, 0, z), objectNum);
        fieldData[x, z] = objectNum;
    }

   
}
