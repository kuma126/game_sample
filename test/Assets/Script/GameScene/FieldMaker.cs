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
    public GameObject Obj1;
    public GameObject Obj2;
    public GameObject Obj3;
    public GameObject Obj4;
    private const int fieldSize = 10;    
    private int[,] fieldData = new int[fieldSize, fieldSize]; // 0:�� 1:�XA 2:�XB 3:�XC
    
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
    @ brief �C���X�^���X�̐���
    @ param Position ��������ʒu(vector3)
    @ param ObjNumber 0:�� 1:�XA 2:�XB 3:�XC
    */
    void SetInstance(Vector3 Position, int ObjNumber)
    {
        GameObject g;
        switch (ObjNumber)
        {
        case 0:
            g = Instantiate(Obj1, Position, Quaternion.identity);
            break;
        case 1:
            g = Instantiate(Obj2, Position, Quaternion.identity);
            break;
        case 2:
            g = Instantiate(Obj3, Position, Quaternion.identity);
            break;
        case 3:
            g = Instantiate(Obj4, Position, Quaternion.identity);
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
}
