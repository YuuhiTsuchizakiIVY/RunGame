using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelect : MonoBehaviour
{
    public static int Level;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartEasy()
    {
        Level = 0;
        SceneManager.LoadScene("GameScene");
    }

    public void StartNormal()
    {
        Level = 1;
        SceneManager.LoadScene("GameScene");
    }
    public void StartHard()
    {
        Level = 2;
        SceneManager.LoadScene("GameScene");
    }

    public void BackTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void EndGame()
    {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
    #else
                Application.Quit();//ゲームプレイ終了
    #endif
    }
}
