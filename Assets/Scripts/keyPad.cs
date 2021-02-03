using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class keyPad : MonoBehaviour
{

    [SerializeField] public bool interactable = true;
    [SerializeField] public string keyNumber;

    GameObject display;
    private string displayText;
    private string enteredText;
    Color32 thisColor;
    public bool lookedAt = false;
    int flashDelay = 0;
    int flashDelayPress = 0;
    int flashDelayOpen = 0;

    private bool flashing = false;
    private bool flashingPress = false;
    private bool flashingOpen = false;

    private float distanceMoved = 0f;
    private bool buttonIn = false;
    private bool buttonOut = false;

    void Start()
    {
        display = GameObject.Find("Display");
        //displayText = display.transform.Find("Text").GetComponent<TextMeshPro>().text;
        display.transform.Find("Text").GetComponent<TextMeshPro>().text = "222";

        thisColor = gameObject.GetComponent<MeshRenderer>().material.color;


    }


    void Update()
    {

        if (lookedAt)
        {
            listenForKey();

        }
        lookedAt = false;


        if (flashing)
        {
            if (flashDelay == 20)
            {
                display.gameObject.GetComponent<MeshRenderer>().material.color = thisColor;  //new Color(255, 0, 0, 106);
                flashDelay = 0;
                flashing = false;
            }
            else
            {
                flashDelay += 1;
            }
        }

        if (flashingOpen)
        {
            if (flashDelayOpen == 100)
            {
                display.gameObject.GetComponent<MeshRenderer>().material.color = thisColor;  //new Color(255, 0, 0, 106);
                flashDelayOpen = 0;
                flashingOpen = false;
            }
            else
            {
                flashDelayOpen += 1;
            }
        }


        if (flashingPress)
        {
            if (flashDelayPress == 10)
            {
                gameObject.GetComponent<MeshRenderer>().material.color = thisColor;  //new Color(255, 0, 0, 106);
                flashDelayPress = 0;
                flashingPress = false;
            }
            else
            {
                flashDelayPress += 1;
            }
        }

        if (buttonIn)
        {
            if (distanceMoved < 0.015f)
            {
                Vector3 oldSpot = transform.position;
                transform.Translate(0, 0, 0.5f * Time.deltaTime * 0.5f);
                distanceMoved += Vector3.Distance(oldSpot, transform.position);
            } else
            {
                buttonIn = false;
                buttonOut = true;
            }
        }


        if (buttonOut)
        {
            if (distanceMoved > 0f)
            {
                Vector3 oldSpot = transform.position;
                transform.Translate(0, 0, -0.5f * Time.deltaTime * 0.5f);
                distanceMoved -= Vector3.Distance(oldSpot, transform.position);
            }
            else
            {
                buttonOut = false;
            }

        }

    }


    void listenForKey()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {

            buttonPress();
            displayText = display.transform.Find("Text").GetComponent<TextMeshPro>().text;
            int codeLength = displayText.Length;
            //Debug.Log(codeLength);

            if (keyNumber == "Enter" || keyNumber == "Clear")
            {
                ce();
            }
            else
            {
                if (codeLength < 6)
                {
                    addToCode();

                }
                else if (codeLength == 6)
                {
                    flashRed();
                }
            }
                               
        }

    }

    private void ce()
    {
        if (keyNumber == "Clear")
        {
            display.transform.Find("Text").GetComponent<TextMeshPro>().text = "";

        } else
        {
            checkCode();
        }

    }


    private void checkCode()
    {
        if (displayText == "2220")
        {

            display.gameObject.GetComponent<MeshRenderer>().material.color = new Color(0, 255, 0, 255);
            flashingOpen = true;

        } else
        {
            flashRed();
        }






        //displayText = display.transform.Find("Text").GetComponent<TextMeshPro>().text;

    }



    private void buttonPress()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = new Color(255, 0, 0, 106);
        buttonIn = true;

        flashingPress = true;


    }


    private void flashRed()
    {
        display.gameObject.GetComponent<MeshRenderer>().material.color = new Color(255, 0, 0, 106);
        flashing = true;
        
        //System.Random delay = new System.Random();
        //flashDelay = delay.Next(3, lightTrigger + 1);
           

    }




    private void addToCode()
    {
        displayText += keyNumber.ToString();

        display.transform.Find("Text").GetComponent<TextMeshPro>().text = displayText;
        


    }
}
