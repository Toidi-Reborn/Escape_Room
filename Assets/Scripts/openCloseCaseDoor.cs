using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openCloseCaseDoor : interactable
{

    private float distanceMoved = 0f;
    GameObject hinge;
    
    void Start()
    {
        hinge = GameObject.Find("pivot");

    }



    void Update()
    {
              
        if (opened) {
            openWindow();
        } else {
            closeWindow();
        }
    }


    void openWindow(){        
        if (distanceMoved < 37f) {
            if (reversed) {
                hinge.transform.Rotate(0, -2.5f, 0 * Time.deltaTime);
                distanceMoved += 1f;
            }
            else {
                hinge.transform.Rotate(0, 2.5f, 0 * Time.deltaTime);
                distanceMoved += 1f;
            }
        }
    }

    void closeWindow(){
        if (distanceMoved > 0f) {
            if (reversed)
            {
                hinge.transform.Rotate(0, 2.5f, 0 * Time.deltaTime);
                distanceMoved -= 1f;
            }
            else
            {
                hinge.transform.Rotate(0, -2.5f, 0 * Time.deltaTime);
                distanceMoved -= 1f;
            }


        }
    }
}
