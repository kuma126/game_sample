using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//��������̃I���I�t�@�\
//�{�^�����������Ƃ���SE
//�X�e�[�W�I���ւ���

public class TitleManager : MonoBehaviour
{
    [SerializeField] GameObject panel; //������@��ʂ̃p�l��
    AudioSource back;
    AudioSource button;

    // Start is called before the first frame update
    void Start()
    {

        back = GameObject.Find("BackSE").GetComponent<AudioSource>();
        button = GameObject.Find("ButtonSE").GetComponent<AudioSource>();

        //�ŏ��͐�����ʂƖ߂�{�^���I�t
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //��������̕\��
    public void OnDescription()
    { 
        panel.SetActive(true);
        button.Play();
    }

    public void OffDescription()
    {
        panel.SetActive(false);
        back.Play();
    }


    //�X�e�[�W�I����
    //������I�������V�[���؂�ւ�
    public void SelectScene()
    {
        DontDestroyOnLoad(button.gameObject);
        StartCoroutine(PlayButtonSound());

    }
    private IEnumerator PlayButtonSound()
    {
        button.Play();
        yield return new WaitForSeconds(button.clip.length);
        Destroy(button.gameObject);
        SceneManager.LoadScene("SelectScene");
    }



}
