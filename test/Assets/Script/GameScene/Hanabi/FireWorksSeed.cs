using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorksSeed : MonoBehaviour
{
    // 花火を生成するためのクラス
    // 球じゃなくて面にする
    private Transform myTransform = null;
    const int devideNumber = 4; //分割数，1で4方向
    Vector3 Position = new Vector3(-100.0f, 40.0f, 110.0f);
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
            //4個づつ生成していく
            for (j = 0; j < 4; j++)
            {
                g = Instantiate(kayaku, Position, Quaternion.identity, myTransform);
                fireWorksIns = g.GetComponent<FireWorks>();
                fireWorksIns.SetSpeed(Velocity.x, Velocity.y, Velocity.z);
                Velocity = Quaternion.Euler(0, 0, 90) * Velocity;
            }
            Velocity = Quaternion.Euler(0, 0, 90 / devideNumber) * Velocity;
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
