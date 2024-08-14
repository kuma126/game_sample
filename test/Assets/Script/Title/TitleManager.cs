using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//操作説明のオンオフ機能
//ボタンを押したときのSE
//ステージ選択へいく

public class TitleManager : MonoBehaviour
{
    [SerializeField] GameObject panel; //操作方法画面のパネル
    AudioSource back;
    AudioSource button;

    // Start is called before the first frame update
    void Start()
    {

        back = GameObject.Find("BackSE").GetComponent<AudioSource>();
        button = GameObject.Find("ButtonSE").GetComponent<AudioSource>();

        //最初は説明画面と戻るボタンオフ
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //操作説明の表示
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


    //ステージ選択へ
    //音が鳴り終わったらシーン切り替え
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
