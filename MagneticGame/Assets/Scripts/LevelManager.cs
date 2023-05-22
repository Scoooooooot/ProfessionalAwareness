using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Image level1Image;
    [SerializeField] Image level2Image;
    [SerializeField] Image level3Image;
    [SerializeField] Image level4Image;

    [SerializeField] Sprite greenImage;
    [SerializeField] Sprite redImage;

    private void Start() {

        // 0 = incomplete, 1 = complete
        if (!PlayerPrefs.HasKey("Level1")) {
            PlayerPrefs.SetInt("Level1", 0);
        }   
        if (!PlayerPrefs.HasKey("Level2")) {
            PlayerPrefs.SetInt("Level2", 0);
        }
        if (!PlayerPrefs.HasKey("Level3")) {
            PlayerPrefs.SetInt("Level3", 0);
        }
        if (!PlayerPrefs.HasKey("Level4")) {    
            PlayerPrefs.SetInt("Level4", 0);
        }

        SetUI();

    }

    public void ResetGame() {
        PlayerPrefs.SetInt("Level1", 0);
        PlayerPrefs.SetInt("Level2", 0);
        PlayerPrefs.SetInt("Level3", 0);
        PlayerPrefs.SetInt("Level4", 0);
        SetUI();
    }
    private void SetUI() {
        if (PlayerPrefs.GetInt("Level1") == 0) {
            level1Image.sprite = redImage;
        } else {
            level1Image.sprite = greenImage;
        }

        if (PlayerPrefs.GetInt("Level2") == 0) {
            level2Image.sprite = redImage;
        } else {
            level2Image.sprite = greenImage;
        }

        if (PlayerPrefs.GetInt("Level3") == 0) {
            level3Image.sprite = redImage;
        } else {
            level3Image.sprite = greenImage;
        }

        if (PlayerPrefs.GetInt("Level4") == 0) {
            level4Image.sprite = redImage;
        } else {
            level4Image.sprite = greenImage;
        }
    }
}
