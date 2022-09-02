using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using TMPro;

public class SettingsSelector : MonoBehaviour
{
    public static SettingsSelector current;

    private int selector;

    [Space(5)]
    [Header("Button")]
    [Space(5)]
    public GameObject gameControlsButton;
    public GameObject languageButton;
    public GameObject audioButton;
    public GameObject backButton;

    [Space(10)]
    [Header("Language")]
    [Space(5)]
    public TextMeshProUGUI gameControlsText;
    public TextMeshProUGUI languageText;
    public TextMeshProUGUI audioText;
    public TextMeshProUGUI backText;

    [Space(5)]
    [Header("Controls Screen")]
    [Space(5)]
    public GameObject gameControlsScreen;
    public TextMeshProUGUI rotateText;
    public TextMeshProUGUI moveText;

    [Space(10)]
    [Header("Settings")]
    [Space(5)]
    public GameObject canvasMainMenu;
    public GameObject canvasSettings;

    void Start()
    {
        current = this;

        selector = 0;

        CheckLanguage();
    }
    public void PointerOn()
    {
        EventSystem.current.SetSelectedGameObject(null);
        selector = -1;
    }

    void Update()
    {
        CheckLanguage();

        if (Keyboard.current.aKey.wasPressedThisFrame || Keyboard.current.leftArrowKey.wasPressedThisFrame ||
            Gamepad.current != null && Gamepad.current.dpad.left.wasPressedThisFrame)
        {
            //MusicSFXControl.currentMSFX.SFXPlay();
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
            //MusicSFXControl.currentMSFX.SFXPlay();
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
            EventSystem.current.SetSelectedGameObject(gameControlsButton);
            if (Keyboard.current.enterKey.wasPressedThisFrame || Keyboard.current.numpadEnterKey.wasPressedThisFrame ||
                Keyboard.current.spaceKey.wasPressedThisFrame || Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
            {
                GameControlsButton();
            }
        }
        else if (selector == 1)
        {
            EventSystem.current.SetSelectedGameObject(languageButton);
            if (Keyboard.current.enterKey.wasPressedThisFrame || Keyboard.current.numpadEnterKey.wasPressedThisFrame ||
                Keyboard.current.spaceKey.wasPressedThisFrame || Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
            {
                LanguageButton();
            }
        }
        else if (selector == 2)
        {
            EventSystem.current.SetSelectedGameObject(audioButton);
            if (Keyboard.current.enterKey.wasPressedThisFrame || Keyboard.current.numpadEnterKey.wasPressedThisFrame ||
                Keyboard.current.spaceKey.wasPressedThisFrame || Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
            {
                AudioButton();
            }
        }
        else if (selector == 3)
        {
            EventSystem.current.SetSelectedGameObject(backButton);
            if (Keyboard.current.enterKey.wasPressedThisFrame || Keyboard.current.numpadEnterKey.wasPressedThisFrame ||
                Keyboard.current.spaceKey.wasPressedThisFrame ||
                Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
            {
                BackToMainMenu();
            }
        }

        if(Keyboard.current.anyKey.wasPressedThisFrame ||
            Mouse.current.rightButton.wasPressedThisFrame ||
            Mouse.current.leftButton.wasPressedThisFrame ||
            Gamepad.current != null && Gamepad.current.buttonEast.wasPressedThisFrame ||
            Gamepad.current != null && Gamepad.current.buttonWest.wasPressedThisFrame ||
            Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame ||
            Gamepad.current != null && Gamepad.current.buttonNorth.wasPressedThisFrame)
        {
            BackFromControlsScreen();
        }
    }

    public void CheckLanguage()
    {
        if (AudioLangController.current.english)
        {
            gameControlsText.text = "Game Controls";
            languageText.text = "Language: English";
            if (AudioLangController.current.audioSystem)
            {
                audioText.text = "Audio: On";
            }
            else if (!AudioLangController.current.audioSystem)
            {
                audioText.text = "Audio: Off";
            }
            backText.text = "Back to Main Menu";
        }
        else if (AudioLangController.current.portuguese)
        {
            gameControlsText.text = "Controles do Jogo";
            languageText.text = "Linguagem: Português";
            if (AudioLangController.current.audioSystem)
            {
                audioText.text = "Áudio: Ligado";
            }
            else if (!AudioLangController.current.audioSystem)
            {
                audioText.text = "Áudio: Desligado";
            }
            backText.text = "Voltar ao Menu Inicial";
        }
    }

    public void GameControlsButton()
    {
        gameControlsButton.SetActive(false);
        gameControlsScreen.SetActive(true);
        if (AudioLangController.current.english)
        {
            rotateText.text = "Rotate";
            moveText.text = "Move";
        }
        else if(AudioLangController.current.portuguese)
        {
            rotateText.text = "Rotacionar";
            moveText.text = "Movimentar";
        }
        languageButton.SetActive(false);
        audioButton.SetActive(false);
        backButton.SetActive(false);
    }

    public void LanguageButton()
    {
        if (AudioLangController.current.english)
        {
            AudioLangController.current.english = false;
            AudioLangController.current.portuguese = true;
        }
        else if (AudioLangController.current.portuguese)
        {
            AudioLangController.current.english = true;
            AudioLangController.current.portuguese = false;
        }
    }

    public void AudioButton()
    {
        EventSystem.current.SetSelectedGameObject(audioButton);
        if(AudioLangController.current.audioSystem)
        {
            AudioLangController.current.audioSystem = false;
            AudioLangController.audioSource.Stop();
        }
        else if(!AudioLangController.current.audioSystem)
        {
            AudioLangController.current.audioSystem = true;
            AudioLangController.audioSource.Play();
        }
    }

    public void BackFromControlsScreen()
    {
        gameControlsButton.SetActive(true);
        gameControlsScreen.SetActive(false);
        languageButton.SetActive(true);
        audioButton.SetActive(true);
        backButton.SetActive(true);
    }
    public void BackToMainMenu()
    {
        canvasSettings.SetActive(false);
        canvasMainMenu.SetActive(true);
    }
}
