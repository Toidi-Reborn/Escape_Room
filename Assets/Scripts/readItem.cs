using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class readItem : interactable
{


    [SerializeField] public string message = "Placeholder Text";
    pControl player;

    inventory myINV;
    


    void Start()
    {

        readable = true;

        player = GameObject.Find("Player").GetComponent<pControl>();
        myINV = GameObject.Find("game").GetComponent<inventory>();
  
    }

    void Update()
    {

        if (lookedAt)
        {
            listenForKey();
        }
        lookedAt = false;

    }


    void listenForKey()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            keyXPressed();
        }

    }


    void keyXPressed()
    {           
        player.setPMessage(message, 10);
    }



}
