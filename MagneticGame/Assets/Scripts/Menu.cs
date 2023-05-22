using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public void PlayButton() {
        SceneManager.LoadScene("LevelSelect");
    }
    public void ControlsButton() {
        SceneManager.LoadScene("Controls");
    }
    public void InformationButton() {
        SceneManager.LoadScene("Information");
    }
    public void QuitButton() {
        Application.Quit();
    }

    public void BackButton() {
        SceneManager.LoadScene("Main Menu");
    }

    public void Level1() {
        SceneManager.LoadScene("Level1");
    }
    
    public void Level2() {
        if (PlayerPrefs.GetInt("Level1") != 0) {
            SceneManager.LoadScene("Level2");
        }
    }
    
    public void Level3() {
        if (PlayerPrefs.GetInt("Level2") != 0) {
            SceneManager.LoadScene("Level3");
        }
    }
    

}
