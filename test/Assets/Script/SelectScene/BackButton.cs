using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    Button button;
    SelectManager selectManager;

    void Start()
    {
        button = GetComponent<Button>();
        selectManager = GameObject.Find("SelectManager").GetComponent<SelectManager>();

        button.onClick.AddListener(selectManager.TitleScene);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

}
