using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorksSeed : MonoBehaviour
{
    // 花火を生成するためのクラス
    // 球じゃなくて面にする
    private Transform myTransform = null;
    const int devideNumber = 10; //分割数，1で4方向だから数的には設定値の4倍になる
    Vector3 Position = new Vector3(10.0f, 30.0f, 100.0f);
    public GameObject kayaku1;
    public GameObject kayaku2;
    public GameObject kayaku3;
    public GameObject kayaku4;

    //花火のSE
    public AudioSource hanabiSE;

    void Start()
    {
        myTransform = this.gameObject.transform;
        LaunchFireWorks();

        //サウンドのコンポーネント取得
        hanabiSE = GetComponent<AudioSource>();
    }

    void LaunchFireWorks()
    {
        int i, j, t;
        float fireWorksVel = 3.0f;  //最初のベクトルの大きさ
        GameObject kayakuColor; //層の色を決める
        Vector3 Velocity = new Vector3(0.0f, fireWorksVel, 0.0f);
        int loopNum = 20; //層の数
        float minusVelocity = fireWorksVel / loopNum; // 内側になるほど速度を落とす
        for (t = 0; t < loopNum; t++)
        {
            //層にする
            double checkValue = (double)t / loopNum; //色変更用の数字 ランダムでも可
            Debug.Log(checkValue);
            if (checkValue <= 0.25)
            {
                kayakuColor = kayaku1;
            }
            else if (checkValue <= 0.50)
            {
                kayakuColor = kayaku2;
            }
            else if (checkValue <= 0.75)
            {
                kayakuColor = kayaku3;
            }
            else
            {
                kayakuColor = kayaku4;
            }

            //層にするために速度を変更
            Velocity.y -= minusVelocity;
            //花火の生成
            for (i = 0; i < devideNumber; i++)
            {
                GameObject g = null;
                FireWorks fireWorksIns = null;
                //4個づつ生成していく
                for (j = 0; j < 4; j++)
                {
                    g = Instantiate(kayakuColor, Position, Quaternion.identity, myTransform);
                    g.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                    fireWorksIns = g.GetComponent<FireWorks>();
                    fireWorksIns.SetSpeed(Velocity.x, Velocity.y, Velocity.z);
                    Velocity = Quaternion.Euler(0, 0, 90) * Velocity;
                }
                Velocity = Quaternion.Euler(0, 0, 90 / devideNumber) * Velocity;    //ベクトルの回転
            }
            Velocity = Quaternion.Euler(0, 0, -90) * Velocity;    //ベクトルの回転
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            LaunchFireWorks();
            hanabiSE.Play();
        }
    }
}
