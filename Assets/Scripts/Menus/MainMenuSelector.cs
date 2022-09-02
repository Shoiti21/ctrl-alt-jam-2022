using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using TMPro;

public class MainMenuSelector : MonoBehaviour
{
    public static MainMenuSelector current;

    private int selector;

    [Space(10)]
    [Header("Button")]
    [Space(5)]
    public GameObject newGameButton;
    public GameObject settingsButton;
    public GameObject creditsButton;
    public GameObject exitButton;

    [Space(10)]
    [Header("Language")]
    [Space(5)]
    public TextMeshProUGUI newGameText;
    public TextMeshProUGUI settingsText;
    public TextMeshProUGUI creditsText;
    public TextMeshProUGUI exitText;

    [Space(10)]
    [Header("Credits Screen")]
    [Space(5)]
    public GameObject creditsImage;

    [Space(10)]
    [Header("Settings")]
    [Space(5)]
    public GameObject canvasMainMenu;
    public GameObject canvasSettings;

    void Start()
    {
        current = this;
        selector = 0;
    }
    public void PointerOn()
    {
        EventSystem.current.SetSelectedGameObject(null);
        selector = -1;
    }

    void Update()
    {
        LanguageCheck();

        if (Keyboard.current.aKey.wasPressedThisFrame || Keyboard.current.leftArrowKey.wasPressedThisFrame ||
            Gamepad.current != null && Gamepad.current.dpad.left.wasPressedThisFrame)
        {
            if (selector <= 0)
            {
                selector = 3;
            }
            else
            {
                selector -= 1;
            }
        }

        if (Keyboard.current.dKey.wasPressedThisFrame || Keyboard.current.rightArrowKey.wasPressedThisFrame ||
             Gamepad.current != null && Gamepad.current.dpad.right.wasPressedThisFrame)
        {
            if (selector >= 3)
            {
                selector = 0;
            }
            else
            {
                selector += 1;
            }
        }

        if(selector == 0)
        {
            EventSystem.current.SetSelectedGameObject(newGameButton);
            if (Keyboard.current.enterKey.wasPressedThisFrame || Keyboard.current.numpadEnterKey.wasPressedThisFrame ||
                Keyboard.current.spaceKey.wasPressedThisFrame || Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
            {
                NewGameButton();
            }
        }
        else if (selector == 1)
        {
            EventSystem.current.SetSelectedGameObject(settingsButton);
            if (Keyboard.current.enterKey.wasPressedThisFrame || Keyboard.current.numpadEnterKey.wasPressedThisFrame ||
                Keyboard.current.spaceKey.wasPressedThisFrame || Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
            {
                SettingsButton();
            }
        }
        if (selector == 2)
        {
            EventSystem.current.SetSelectedGameObject(creditsButton);
            if (Keyboard.current.enterKey.wasPressedThisFrame || Keyboard.current.numpadEnterKey.wasPressedThisFrame ||
                Keyboard.current.spaceKey.wasPressedThisFrame || Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
            {
                CreditsButton();
            }
        }
        else if (selector == 3)
        {
            EventSystem.current.SetSelectedGameObject(exitButton);
            if (Keyboard.current.enterKey.wasPressedThisFrame || Keyboard.current.numpadEnterKey.wasPressedThisFrame ||
                Keyboard.current.spaceKey.wasPressedThisFrame || Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
            {
                QuitGameButton();
            }
        }

        if (Keyboard.current.escapeKey.wasPressedThisFrame || Keyboard.current.backspaceKey.wasPressedThisFrame ||
            Gamepad.current != null && Gamepad.current.buttonEast.wasPressedThisFrame || Mouse.current.rightButton.wasPressedThisFrame)
        {
            BackFromCreditsScreenButton();
        }
    }

    public void LanguageCheck()
    {
        if (AudioLangController.current.english)
        {
            newGameText.text = "New Game - Demo";
            settingsText.text = "Settings";
            creditsText.text = "Credits";
            exitText.text = "Exit";
        }
        else if(AudioLangController.current.portuguese)
        {
            newGameText.text = "Novo Jogo - Demo";
            settingsText.text = "Configurações";
            creditsText.text = "Créditos";
            exitText.text = "Sair";
        }
    }

    public void NewGameButton()
    {
        selector = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Intro");
    }

    public void SettingsButton()
    {
        selector = 1;
        canvasMainMenu.SetActive(false);
        canvasSettings.SetActive(true);
    }

    public void CreditsButton()
    {
        selector = 2;
        newGameButton.SetActive(false);
        settingsButton.SetActive(false);
        creditsButton.SetActive(false);
        creditsImage.SetActive(true);
        exitButton.SetActive(false);
    }

    public void BackFromCreditsScreenButton()
    {
        newGameButton.SetActive(true);
        settingsButton.SetActive(true);
        creditsButton.SetActive(true);
        creditsImage.SetActive(false);
        exitButton.SetActive(true);
    }

    public void QuitGameButton()
    {
        selector = 3;
        Application.Quit();
    }
}
