using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public static bool audioPlaying = true;
    public GameObject xButtonOutline;
    public float timerKnob = 0.5f;

    void Update()
    {
        if(Keyboard.current.anyKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame || Mouse.current.rightButton.wasPressedThisFrame ||
            Gamepad.current != null && Gamepad.current.buttonEast.wasPressedThisFrame || Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            ExitToMainMenu();
        }

        timerKnob -= Time.deltaTime;

        if (timerKnob <= 0)
        {
            xButtonOutline.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        if (timerKnob <= -0.5f)
        {
            xButtonOutline.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
            timerKnob = 0.5f;
        }
    }

    public void ExitToMainMenu()
    {
        if (AudioLangController.current.audioSystem)
        {
            audioPlaying = true;
        }
        else
        {
            audioPlaying = true;
        }
        AudioLangController.current.restart = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
