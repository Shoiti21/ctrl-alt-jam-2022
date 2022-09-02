using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    [Space(10)]
    [Header("Main Controls")]
    [Space(5)]
    private int introSequence;
    public GameObject leftKnob;
    public GameObject rightKnob;
    public GameObject xButtonOutline;
    public float timerKnob;

    [Space(10)]
    [Header("Images")]
    [Space(5)]
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject five;
    public GameObject six;
    public GameObject seven;
    public GameObject eight;
    public GameObject nine;
    public GameObject ten;
    public GameObject eleven;
    public GameObject twelve;

    private void Start()
    {
        timerKnob = 0.5f;
        introSequence = 1;
    }

    private void Update()
    {
        if(!AudioLangController.current.audioSystem)
        {
            GetComponent<AudioSource>().mute = true;
        }
        else
        {
            GetComponent<AudioSource>().mute = false;
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

        if (Keyboard.current.aKey.wasPressedThisFrame || Keyboard.current.leftArrowKey.wasPressedThisFrame
            || Gamepad.current != null && Gamepad.current.buttonWest.wasPressedThisFrame)
        {
            PreviousSequence();
        }
        if (Keyboard.current.dKey.wasPressedThisFrame || Keyboard.current.rightArrowKey.wasPressedThisFrame
            || Gamepad.current != null && Gamepad.current.buttonEast.wasPressedThisFrame)
        {
            NextSequence();
        }
        if (Keyboard.current.enterKey.wasPressedThisFrame || Keyboard.current.numpadEnterKey.wasPressedThisFrame
            || Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            // Duck.life = 75;
            introSequence = 13;
        }

        switch (introSequence)
        {
            case 1:
                leftKnob.SetActive(false);
                one.SetActive(true);
                two.SetActive(false);
                three.SetActive(false);
                four.SetActive(false);
                five.SetActive(false);
                six.SetActive(false);
                seven.SetActive(false);
                eight.SetActive(false);
                nine.SetActive(false);
                ten.SetActive(false);
                eleven.SetActive(false);
                twelve.SetActive(false);
                break;
            case 2:
                leftKnob.SetActive(true);
                one.SetActive(false);
                two.SetActive(true);
                three.SetActive(false);
                four.SetActive(false);
                five.SetActive(false);
                six.SetActive(false);
                seven.SetActive(false);
                eight.SetActive(false);
                nine.SetActive(false);
                ten.SetActive(false);
                eleven.SetActive(false);
                twelve.SetActive(false);
                break;
            case 3:
                one.SetActive(false);
                two.SetActive(false);
                three.SetActive(true);
                four.SetActive(false);
                five.SetActive(false);
                six.SetActive(false);
                seven.SetActive(false);
                eight.SetActive(false);
                nine.SetActive(false);
                ten.SetActive(false);
                eleven.SetActive(false);
                twelve.SetActive(false);
                break;
            case 4:
                one.SetActive(false);
                two.SetActive(false);
                three.SetActive(false);
                four.SetActive(true);
                five.SetActive(false);
                six.SetActive(false);
                seven.SetActive(false);
                eight.SetActive(false);
                nine.SetActive(false);
                ten.SetActive(false);
                eleven.SetActive(false);
                twelve.SetActive(false);
                break;
            case 5:
                one.SetActive(false);
                two.SetActive(false);
                three.SetActive(false);
                four.SetActive(false);
                five.SetActive(true);
                six.SetActive(false);
                seven.SetActive(false);
                eight.SetActive(false);
                nine.SetActive(false);
                ten.SetActive(false);
                eleven.SetActive(false);
                twelve.SetActive(false);
                break;
            case 6:
                one.SetActive(false);
                two.SetActive(false);
                three.SetActive(false);
                four.SetActive(false);
                five.SetActive(false);
                six.SetActive(true);
                seven.SetActive(false);
                eight.SetActive(false);
                nine.SetActive(false);
                ten.SetActive(false);
                eleven.SetActive(false);
                twelve.SetActive(false);
                break;
            case 7:
                one.SetActive(false);
                two.SetActive(false);
                three.SetActive(false);
                four.SetActive(false);
                five.SetActive(false);
                six.SetActive(false);
                seven.SetActive(true);
                eight.SetActive(false);
                nine.SetActive(false);
                ten.SetActive(false);
                eleven.SetActive(false);
                twelve.SetActive(false);
                break;
            case 8:
                one.SetActive(false);
                two.SetActive(false);
                three.SetActive(false);
                four.SetActive(false);
                five.SetActive(false);
                six.SetActive(false);
                seven.SetActive(false);
                eight.SetActive(true);
                nine.SetActive(false);
                ten.SetActive(false);
                eleven.SetActive(false);
                twelve.SetActive(false);
                break;
            case 9:
                one.SetActive(false);
                two.SetActive(false);
                three.SetActive(false);
                four.SetActive(false);
                five.SetActive(false);
                six.SetActive(false);
                seven.SetActive(false);
                eight.SetActive(false);
                nine.SetActive(true);
                ten.SetActive(false);
                eleven.SetActive(false);
                twelve.SetActive(false);
                break;
            case 10:
                one.SetActive(false);
                two.SetActive(false);
                three.SetActive(false);
                four.SetActive(false);
                five.SetActive(false);
                six.SetActive(false);
                seven.SetActive(false);
                eight.SetActive(false);
                nine.SetActive(false);
                ten.SetActive(true);
                eleven.SetActive(false);
                twelve.SetActive(false);
                break;
            case 11:
                rightKnob.SetActive(true);
                one.SetActive(false);
                two.SetActive(false);
                three.SetActive(false);
                four.SetActive(false);
                five.SetActive(false);
                six.SetActive(false);
                seven.SetActive(false);
                eight.SetActive(false);
                nine.SetActive(false);
                ten.SetActive(false);
                eleven.SetActive(true);
                twelve.SetActive(false);
                break;
            case 12:
                rightKnob.SetActive(false);
                one.SetActive(false);
                two.SetActive(false);
                three.SetActive(false);
                four.SetActive(false);
                five.SetActive(false);
                six.SetActive(false);
                seven.SetActive(false);
                eight.SetActive(false);
                nine.SetActive(false);
                ten.SetActive(false);
                eleven.SetActive(false);
                twelve.SetActive(true);
                break;
            case 13:
                // Duck.life = 75;
                UnityEngine.SceneManagement.SceneManager.LoadScene("LevelOne");
                break;
            default:
                one.SetActive(true);
                two.SetActive(false);
                three.SetActive(false);
                four.SetActive(false);
                five.SetActive(false);
                six.SetActive(false);
                seven.SetActive(false);
                eight.SetActive(false);
                nine.SetActive(false);
                ten.SetActive(false);
                eleven.SetActive(false);
                twelve.SetActive(false);
                break;
        }
    }

    public void NextSequence()
    {
        if (introSequence > 12)
        {
            introSequence = 13;
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

    public void SkipScreens()
    {
        introSequence = 13;
    }
}
