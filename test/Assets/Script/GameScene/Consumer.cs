using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static Unity.Collections.AllocatorManager;

public class Consumer : MonoBehaviour
{
    // fieldmaker��������󂯎��C����ɗאڂ����Ƃ��ɂ������g�������߂�
    // �ړ��������g�����m�F�̃��[�v�@
    // �ԉ΂��グ��Ώグ��قǃX�s�[�h���x���Ȃ邼
    // private int money = 10000;  //�q�̏����� ����Ȃ�����
    private Vector3 myGridPos; // �q�̃O���b�h�ʒu
    private bool isBuying;
    private Transform myTransform = null;
    FieldMaker fieldMaker; // �t�B�[���h�����擾���邽�ߍŏ��ɂ����Ă���
    Store currentStore; // �������X
    GridConverter gridConverter;

    private void Awake()
    {
        myGridPos = Vector3.zero;
        myTransform = this.gameObject.transform;
        fieldMaker = GameObject.Find("FieldMaker").GetComponent<FieldMaker>() ;
        gridConverter = new GridConverter();
    }

    void Update()
    {
        checkGridPos();
        Move();

    }

    void BuySomething()
    {
        isBuying = true;
        currentStore.Sale();
    }

    void Move()
    {
        // �������Ĉړ�����
        transform.Translate(0.0f, 0.0f, 0.001f);

        if (isBuying)
        {
            return;
        }

        // �X�ɗאڂ��Ă��邩�H
        GameObject store;
        store = null;

        // �㉺���E�m�F
        var dx = new int[4] { 0, -1, 0, 1 };
        var dz = new int[4] { 1, 0, -1, 0 };
        for (int i = 0; i < 4; i++) //��}�X�Ŕ������ł���̂�1�܂ł��Ă��Ƃ�
        {
            Vector3 checkGrid = Vector3.zero;
            var newX = myGridPos.x + dx[i];
            var newZ = myGridPos.z + dz[i];
            checkGrid.x = newX;
            checkGrid.z = newZ;
            store = fieldMaker.GetStore(checkGrid); // �X�`�F�b�N
            if (store != null)
            {
                currentStore = store.GetComponent<Store>();
                //�w�����邩�H
                bool buyFlag = true;
                if (buyFlag)
                {
                    BuySomething();
                    break;
                }
            }
        }
    }

    /*
    @brief �O���b�h�ʒu���X�V���� 
    */
    void checkGridPos()
    {
        Vector3 newPos;
        newPos = gridConverter.CalcPosition(myTransform.position.x, myTransform.position.z);

        // �O���b�h�ʒu���ς�����Ȃ�
        if(newPos.x != myGridPos.x || newPos.z != myGridPos.z)
        {
            isBuying = false;
        }

        myGridPos = newPos;
    }
}
