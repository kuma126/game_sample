using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SelectManager : MonoBehaviour
{
     AudioSource select;
     AudioSource back;

    public static int fieldNumber;

    void Start()
    {
        select = GameObject.Find("SelectSE").GetComponent<AudioSource>();
        back = GameObject.Find("BackSE").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameSceneA()
    {
        fieldNumber = 0;
        //シーンが切り替わっても音が途切れないようにする
        DontDestroyOnLoad(select.gameObject);
        StartCoroutine(PlaySelectSound());
    }

    public void GameSceneB()
    {
        fieldNumber = 1;
        //シーンが切り替わっても音が途切れないようにする
        DontDestroyOnLoad(select.gameObject);
        StartCoroutine(PlaySelectSound());
    }

    public void GameSceneC()
    {
        fieldNumber = 2;
        //シーンが切り替わっても音が途切れないようにする
        DontDestroyOnLoad(select.gameObject);
        StartCoroutine(PlaySelectSound());
    }



    public void TitleScene()
    {
        DontDestroyOnLoad(back.gameObject);
        StartCoroutine(PlayBackSound());
    }


    //コルーチンをつかって音が鳴り終わったらオブジェクト消す
    //セレクトSE
    private IEnumerator PlaySelectSound()
    {
        select.Play();
        yield return new WaitForSeconds(select.clip.length);
        Destroy(select.gameObject);
        SceneManager.LoadScene("GameScene");
    }

    //戻るSE
    private IEnumerator PlayBackSound()
    {
        back.Play();
        yield return new WaitForSeconds(back.clip.length);
        Destroy(back.gameObject);
        SceneManager.LoadScene("TitleScene");
    }

}
