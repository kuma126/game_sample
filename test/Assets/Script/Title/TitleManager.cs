using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField] GameObject panel; //操作方法画面のパネル

    // Start is called before the first frame update
    void Start()
    {
        //最初は説明画面と戻るボタンオフ
        OffDescription();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDescription()
    { 
        panel.SetActive(true);
    }

    public void OffDescription()
    {
        panel.SetActive(false); 
    }




}
