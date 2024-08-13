using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton: MonoBehaviour
{
    Button button;
    ChangeScene changescene;


    void Start()
    {
        button = GetComponent<Button>();
        changescene = GetComponent<ChangeScene>();

        button.onClick.AddListener(changescene.SelectStage);
    }

    void Update()
    {

    }

}