using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    [Header("scenes")]
    /*[SerializeField]*/string mainMenu;
    /*[SerializeField]*/string mainGame;
    public void startGame(){
        SceneManager.LoadScene(SceneManager.GetSceneByName("mainGame").buildIndex);
    }
    public void gotoMainMenu(){
        SceneManager.LoadScene(SceneManager.GetSceneByName("mainMenu").buildIndex);
    }
}
