using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField] GameObject panel; //������@��ʂ̃p�l��

    // Start is called before the first frame update
    void Start()
    {
        //�ŏ��͐�����ʂƖ߂�{�^���I�t
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
