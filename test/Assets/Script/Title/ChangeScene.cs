using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void SelectStage()
    {
        SceneManager.LoadScene("SelectScene");
    }

    public void Title()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void Game()
    {
        SceneManager.LoadScene("GameScene");

    }

}
