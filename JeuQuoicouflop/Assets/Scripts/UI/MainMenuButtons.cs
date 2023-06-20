using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    
    public void Play(){

        SceneManager.LoadScene("TestMap");

    }

    public void Settings(){

        

    }

    public void Quit(){

        Application.Quit();

    }

}
