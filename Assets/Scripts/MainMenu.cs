using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public string sceneName;
    public void LoadLevel(string sceneName)
    {
        AudioManager.instance.SfxFunc(1);
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()  
    {
        AudioManager.instance.SfxFunc(1);
        Application.Quit();
    }




}
