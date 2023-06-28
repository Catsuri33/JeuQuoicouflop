using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenuButtons : MonoBehaviour
{
    private Canvas canvas;
    private GameObject screenObject;
    private GameObject volumeObject;
    private GameObject textObject;
    private GameObject keysObject;

    void Awake(){

        canvas = this.transform.parent.GetComponent<Canvas>();

        screenObject = GameObject.Find("ScreenSettings");
        volumeObject = GameObject.Find("VolumeSettings");
        textObject = GameObject.Find("TextSettings");
        keysObject = GameObject.Find("KeysSettings");

    }

    public void DisplaySettings(){

        ResetImages();

        screenObject.SetActive(true);
        volumeObject.SetActive(false);
        textObject.SetActive(false);
        keysObject.SetActive(false);

        Sprite img = Resources.Load<Sprite>("Images/Buttons/ScreenButtonChecked");
        this.GetComponent<Image>().sprite = img;

    }

    public void VolumeSettings(){

        ResetImages();

        screenObject.SetActive(false);
        volumeObject.SetActive(true);
        textObject.SetActive(false);
        keysObject.SetActive(false);

        Sprite img = Resources.Load<Sprite>("Images/Buttons/VolumeButtonChecked");
        this.GetComponent<Image>().sprite = img;

    }

    public void LanguageSettings(){

        ResetImages();

        screenObject.SetActive(false);
        volumeObject.SetActive(false);
        textObject.SetActive(true);
        keysObject.SetActive(false);

        Sprite img = Resources.Load<Sprite>("Images/Buttons/TextButtonChecked");
        this.GetComponent<Image>().sprite = img;

    }

    public void KeysSettings(){

        ResetImages();

        screenObject.SetActive(false);
        volumeObject.SetActive(false);
        textObject.SetActive(false);
        keysObject.SetActive(true);

        Sprite img = Resources.Load<Sprite>("Images/Buttons/KeysButtonChecked");
        this.GetComponent<Image>().sprite = img;

    }

    public void Back(){

        SceneManager.LoadScene("MainMenu");

    }

    private void ResetImages(){

        foreach(Transform child in canvas.transform)
        {
            if(child.gameObject.GetComponent<Image>() != null){

                string imageName;

                if(child.gameObject.GetComponent<Image>().name.Contains("Checked")){

                    imageName = child.gameObject.GetComponent<Image>().name.Substring(0, child.gameObject.GetComponent<Image>().name.Length - 7);

                } else {

                    imageName = child.gameObject.GetComponent<Image>().name;

                }

                Sprite imgReset = Resources.Load<Sprite>("Images/Buttons/" + imageName);
                child.gameObject.GetComponent<Image>().sprite = imgReset;

            }
        }

    }
}
