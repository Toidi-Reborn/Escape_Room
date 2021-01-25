using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alarm : MonoBehaviour
{

    public bool alarmOn = false;
    public bool activated = false;
    bool bTrigger = false;
    bool rTrigger = true;
    
    int min;
    int max;

    int lightTrigger = 20;

    GameObject redLight;
    GameObject blueLight;
    GameObject mainLight;
    

    void Start()
    {
        redLight = GameObject.Find("red");
        blueLight = GameObject.Find("blue");
        mainLight = GameObject.Find("main");
        //redLight.SetActive(false);
        //blueLight.SetActive(false);

        
    }
    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.T)) //testing
        {
            getRandomOn();
            alarmOn = true;
        }

        if (alarmOn && activated)
        {
            mainLight.SetActive(false);

            if (max == lightTrigger)
            {
                
                blueSwitch();
                redSwitch();
                getRandomOn();
            }
            else
            {
                max += 1;                
            }
        }
    }


    void getRandomOn()
    {
        System.Random delay = new System.Random();
        max = delay.Next(3, lightTrigger + 1); 
    }

    void redSwitch()
    {
        rTrigger = !rTrigger;
        redLight.SetActive(rTrigger);        
    }

    void blueSwitch()
    {
        bTrigger = !bTrigger;
        blueLight.SetActive(bTrigger);
    }


    void turnOffAlarm()
    {
        mainLight.SetActive(true);
        redLight.SetActive(false);
        blueLight.SetActive(false);
        alarmOn = false;

    }

}
