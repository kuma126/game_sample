using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorks : MonoBehaviour
{
    private Transform myTransform;
    private float speedX = 3.0f; //����
    private float speedY = 3.0f; //����
    private float speedZ = 3.0f; //����
    private float scale = 1.0f;

    void Start()
    {
        myTransform = this.transform;   //�g�����X�t�H�[���̐ݒ�
    }

    // �������Ȃ����������
    void Update()
    {
        speedY -= 0.01f;
        scale -= 0.001f;
        myTransform.position += new Vector3(speedX, speedY, speedZ) * Time.deltaTime;
        myTransform.localScale = new Vector3(scale, scale, scale);

        if(myTransform.lossyScale.x < 0.01)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetSpeed(float x, float y, float z)
    {
        speedX = x;
        speedY = y;
        speedZ = z;
    }
}
