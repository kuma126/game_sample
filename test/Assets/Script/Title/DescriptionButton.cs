using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionButton : MonoBehaviour
{
    Button button;
    TitleManager titleManager;
    void Start()
    {
        button = GetComponent<Button>();
        titleManager = GameObject.Find("TitleManager").GetComponent<TitleManager>();

        button.onClick.AddListener(titleManager.OnDescription);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
