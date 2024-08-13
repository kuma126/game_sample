using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] int timelimit; //制限時間
    [SerializeField] Text timertext; //タイマーテキスト
    float time; //経過時間


    // Update is called once per frame
    void Update()
    {
        //時間取得してUIに表示
        time += Time.deltaTime;

        int remaining = timelimit - (int)time;

        timertext.text = $"夜まで:{remaining.ToString("D3")}";


        if(remaining <= 0)
        {
            //時間が経過したらカメラ動かして花火上がる。
        }
    }
}
