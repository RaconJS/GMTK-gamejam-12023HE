using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public void startGame(){
        SceneManager.LoadScene("mainGame");//, LoadSceneMode.Additive);
    }
    public void gotoMainMenu(){
        SceneManager.LoadScene("mainMenu");//, LoadSceneMode.Additive);
    }
    public void gotoPauseMenu(){
        SceneManager.LoadScene("pauseMenu");//, LoadSceneMode.Additive);
    }
}
