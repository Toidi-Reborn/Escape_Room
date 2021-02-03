using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;



public class monitorWindow : MonoBehaviour
{

    private List<TextMeshProUGUI> lines = new List<TextMeshProUGUI>();
    public bool lookedAt = false;  //may not need
    public bool screenActive = false;


    FirstPersonController fpc;
    public GameObject screen;

    void Start()
    {

        screen = GameObject.Find("screen");
        fpc = GameObject.Find("Player").GetComponent<FirstPersonController>();

        for (var i = 0; i < 11; i++)
        {
            lines.Add(screen.transform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>());

            if ( i > 0 )
            {
                lines[i].text = "";
            } else
            {
                lines[i].text = "Password: ";
            }
            
        }

        screen.SetActive(false);
        //lines[5].text = "This should be line 6";
    }
    

    void Update()
    {
        if (lookedAt)
        {

            Debug.Log("sdfdsfdsfdsfdsfS");


        }



    }
}
