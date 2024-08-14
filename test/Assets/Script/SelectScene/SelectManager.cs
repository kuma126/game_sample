using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SelectManager : MonoBehaviour
{
     AudioSource select;
     AudioSource back;

    // Start is called before the first frame update
    void Start()
    {
        select = GameObject.Find("SelectSE").GetComponent<AudioSource>();
        back = GameObject.Find("BackSE").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameScene()
    {
        //�V�[�����؂�ւ���Ă������r�؂�Ȃ��悤�ɂ���
        DontDestroyOnLoad(select.gameObject);
        StartCoroutine(PlaySelectSound());
    }

    public void TitleScene()
    {
        //�V�[�����؂�ւ���Ă������r�؂�Ȃ��悤�ɂ���
        DontDestroyOnLoad(back.gameObject);
        StartCoroutine(PlayBackSound());
    }


    //�R���[�`���������ĉ�����I�������I�u�W�F�N�g����
    //�Z���N�gSE
    private IEnumerator PlaySelectSound()
    {
        select.Play();
        yield return new WaitForSeconds(select.clip.length);
        Destroy(select.gameObject);
        SceneManager.LoadScene("GameScene");
    }

    //�߂�SE
    private IEnumerator PlayBackSound()
    {
        back.Play();
        yield return new WaitForSeconds(back.clip.length);
        Destroy(back.gameObject);
        SceneManager.LoadScene("TitleScene");
    }

}
