using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorksSeed : MonoBehaviour
{
    // �ԉ΂𐶐����邽�߂̃N���X
    // ������Ȃ��Ėʂɂ���
    private Transform myTransform = null;
    const int devideNumber = 2; //�������C1��4����
    Vector3 Position = new Vector3(0.0f, 40.0f, 100.0f);
    public GameObject kayaku;

    void Start()
    {
        myTransform = this.gameObject.transform;
        LaunchFireWorks();
    }

    void LaunchFireWorks()
    {
        int i;
        int j;
        Vector3 Velocity = new Vector3(0.0f, 1.0f, 0.0f);
        for (i = 0; i < devideNumber; i++)
        {
            GameObject g = null;
            FireWorks fireWorksIns = null;
            //4�Â������Ă���
            for (j = 0; j < 4; j++)
            {
                g = Instantiate(kayaku, Position, Quaternion.identity, myTransform);
                fireWorksIns = g.GetComponent<FireWorks>();
                fireWorksIns.SetSpeed(Velocity.x, Velocity.y, Velocity.z);
                Velocity = Quaternion.Euler(0, 0, 90) * Velocity;
            }
            Velocity = Quaternion.Euler(0, 0, 45) * Velocity;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            LaunchFireWorks();
        }
    }
}
