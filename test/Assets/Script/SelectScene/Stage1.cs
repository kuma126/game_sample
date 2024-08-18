using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Stage1 : MonoBehaviour
{
    Button button;
    SelectManager select;

    void Start()
    {
        button = GetComponent<Button>();
        select = GameObject.Find("SelectManager").GetComponent<SelectManager>();

        button.onClick.AddListener(select.GameSceneA);
    }

    void Update()
    {

    }

}
