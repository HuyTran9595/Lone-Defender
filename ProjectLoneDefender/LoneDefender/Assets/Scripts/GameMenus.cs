using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenus : MonoBehaviour
{
    public PlayerController PlayerRef; //reference to player
    public void PlayTheLevel(string LevelName) //play the level base on given string 
    {
        SceneManager.LoadScene(LevelName);
    }

    public void QuitGame() //quit the game 
    {
        Application.Quit();
    }
    
    public void BackToMenu(string LevelName) // back to main menu
    {
        SceneManager.LoadScene(LevelName);
    }
    
    public void PlayAgain(string LevelName) //play again 
    {
        SceneManager.LoadScene(LevelName);
    }

    public void PauseResume() //pause menu 
    {
        PlayerRef.isPause = false;
        PlayerRef.ThePauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }
    
}
