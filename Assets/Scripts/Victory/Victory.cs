using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class Victory : MonoBehaviour
{
    [Space(10)]
    [Header("Main Controls")]
    [Space(5)]
    private int introSequence;
    public GameObject leftKnob;
    public GameObject rightKnob;
    public GameObject xButtonOutline;
    public float timerKnob;
    public TextMeshProUGUI victoryText;
    public static bool audioPlaying = true;

    [Space(10)]
    [Header("Images")]
    [Space(5)]
    public GameObject one;
    public GameObject two;
    public GameObject three;

    private void Start()
    {
        timerKnob = 0.5f;
        introSequence = 1;
    }

    private void Update()
    {
        CheckLanguage();

        if (Mouse.current.rightButton.wasPressedThisFrame || Gamepad.current != null && Gamepad.current.buttonEast.wasPressedThisFrame ||
            Keyboard.current.escapeKey.wasPressedThisFrame || Keyboard.current.backspaceKey.wasPressedThisFrame)
        {
            ExitToMainMenu();
        }

        timerKnob -= Time.deltaTime;

        if (timerKnob <= 0)
        {
            leftKnob.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            rightKnob.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            xButtonOutline.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        if (timerKnob <= -0.5f)
        {
            leftKnob.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
            rightKnob.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
            xButtonOutline.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
            timerKnob = 0.5f;
        }

        if (Keyboard.current.aKey.wasPressedThisFrame || Keyboard.current.leftArrowKey.wasPressedThisFrame ||
            Gamepad.current != null && Gamepad.current.buttonWest.wasPressedThisFrame)
        {
            PreviousSequence();
        }
        if (Keyboard.current.dKey.wasPressedThisFrame || Keyboard.current.rightArrowKey.wasPressedThisFrame ||
            Gamepad.current != null && Gamepad.current.buttonEast.wasPressedThisFrame)
        {
            NextSequence();
        }
        if (Keyboard.current.enterKey.wasPressedThisFrame || Keyboard.current.numpadEnterKey.wasPressedThisFrame ||
            Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            //Player.life = 75;
            introSequence = 4;
        }

        switch (introSequence)
        {
            case 1:
                one.SetActive(true);
                two.SetActive(false);
                three.SetActive(false);
                break;
            case 2:
                one.SetActive(false);
                two.SetActive(true);
                three.SetActive(false);
                break;
            case 3:
                one.SetActive(false);
                two.SetActive(false);
                three.SetActive(true);
                break;
            case 4:
                //Player.life = 75;
                if (Keyboard.current.anyKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame || Mouse.current.rightButton.wasPressedThisFrame ||
                    Gamepad.current != null && Gamepad.current.buttonEast.wasPressedThisFrame || Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
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
                break;
            default:
                one.SetActive(true);
                two.SetActive(false);
                three.SetActive(false);
                break;
        }
    }

    public void NextSequence()
    {
        if (introSequence > 3)
        {
            introSequence = 4;
        }
        else
        {
            introSequence += 1;
        }
    }

    public void PreviousSequence()
    {
        if (introSequence < 1)
        {
            introSequence = 1;
        }
        else
        {
            introSequence -= 1;
        }
    }

    private void CheckLanguage()
    {
        if (AudioLangController.current.english)
        {
            victoryText.text = "You win!";
        }
        if (AudioLangController.current.portuguese)
        {
            victoryText.text = "Vitória!";
        }
        if (AudioLangController.current.spanish)
        {
            victoryText.text = "Victoria!";
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
