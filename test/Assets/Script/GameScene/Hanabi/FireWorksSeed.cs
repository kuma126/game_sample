using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorksSeed : MonoBehaviour
{
    // �ԉ΂𐶐����邽�߂̃N���X
    // ������Ȃ��Ėʂɂ���
    private Transform myTransform = null;
    const int devideNumber = 10; //�������C1��4���������琔�I�ɂ͐ݒ�l��4�{�ɂȂ�
    Vector3 Position = new Vector3(10.0f, 30.0f, 100.0f);
    public GameObject kayaku1;
    public GameObject kayaku2;
    public GameObject kayaku3;
    public GameObject kayaku4;

    //�ԉ΂�SE
    public AudioSource hanabiSE;

    void Start()
    {
        myTransform = this.gameObject.transform;
        LaunchFireWorks();

        //�T�E���h�̃R���|�[�l���g�擾
        hanabiSE = GetComponent<AudioSource>();
    }

    void LaunchFireWorks()
    {
        int i, j, t;
        float fireWorksVel = 3.0f;  //�ŏ��̃x�N�g���̑傫��
        GameObject kayakuColor; //�w�̐F�����߂�
        Vector3 Velocity = new Vector3(0.0f, fireWorksVel, 0.0f);
        int loopNum = 20; //�w�̐�
        float minusVelocity = fireWorksVel / loopNum; // �����ɂȂ�قǑ��x�𗎂Ƃ�
        for (t = 0; t < loopNum; t++)
        {
            //�w�ɂ���
            double checkValue = (double)t / loopNum; //�F�ύX�p�̐��� �����_���ł���
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

            //�w�ɂ��邽�߂ɑ��x��ύX
            Velocity.y -= minusVelocity;
            //�ԉ΂̐���
            for (i = 0; i < devideNumber; i++)
            {
                GameObject g = null;
                FireWorks fireWorksIns = null;
                //4�Â������Ă���
                for (j = 0; j < 4; j++)
                {
                    g = Instantiate(kayakuColor, Position, Quaternion.identity, myTransform);
                    g.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                    fireWorksIns = g.GetComponent<FireWorks>();
                    fireWorksIns.SetSpeed(Velocity.x, Velocity.y, Velocity.z);
                    Velocity = Quaternion.Euler(0, 0, 90) * Velocity;
                }
                Velocity = Quaternion.Euler(0, 0, 90 / devideNumber) * Velocity;    //�x�N�g���̉�]
            }
            Velocity = Quaternion.Euler(0, 0, -90) * Velocity;    //�x�N�g���̉�]
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
