using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets.Characters.FirstPerson;

public class monitor : interactable
{
    
    [SerializeField] GameObject pcScreen;
    monitorWindow pcScript;

    FirstPersonController fpc;


    void Start()
    {
        pcScript = pcScreen.gameObject.GetComponent<monitorWindow>();
        fpc = GameObject.Find("Player").GetComponent<FirstPersonController>();
    }

    void Update()
    {
        if (lookedAt) {
            if (Input.GetKeyDown(KeyCode.K))
            {
                pcScript.screen.SetActive(true);
                pcScript.screenActive = true;  //for inventory screen referance to avoid hitting I
                fpc.enabled = false;

            }
        }
    }
}
