using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] int timelimit; //��������
    [SerializeField] Text timertext; //�^�C�}�[�e�L�X�g
    float time; //�o�ߎ���


    // Update is called once per frame
    void Update()
    {
        //���Ԏ擾����UI�ɕ\��
        time += Time.deltaTime;

        int remaining = timelimit - (int)time;

        timertext.text = $"��܂�:{remaining.ToString("D3")}";


        if(remaining <= 0)
        {
            //���Ԃ��o�߂�����J�����������ĉԉΏオ��B
        }
    }
}
