using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openCloseDoor : interactable
{


    Lighting lighting;
    inventory playerInv; // Players Inventory
    alarm alarmScript;

    //public bool lookedAt = false;
    private GameObject actionDisplay;
    //private GameObject hinge;
    private float distanceMoved = 0f;
    
    void Start()
    {
        actionDisplay = this.transform.Find("myButton").gameObject;
        //hinge = this.transform;
        playerInv = GameObject.Find("game").GetComponent<inventory>();
        alarmScript = GameObject.Find("Lighting").GetComponent<alarm>();
        lighting = GameObject.Find("game").GetComponent<Lighting>();

    }



    void Update()
    {
        actionDisplay.SetActive(false);

        if (lookedAt){
                actionDisplay.SetActive(true);   //too put x image - may not want
                listenForKey();  
                
        }

        lookedAt = false;
               
        if (opened) {
            openDrawer();
        } else {
            closeDrawer();
        }
    }


    void listenForKey(){
        if (Input.GetKeyDown(KeyCode.K)) {

            if(!locked){

                keyXPressed();

            } else {
                string curSel = playerInv.myInvItems[playerInv.curInvSel].name;


                if (curSel == requiredItem )
                {
                    keyXPressed();

                    if (alarm)
                    {
                        alarmScript.alarmOn = true;
                    }

                   
                }
               
                Debug.Log("Locked!!!!!!!!!");

            }
   
        }
    
    }


    void keyXPressed(){
        opened = !opened; 
    }


    void openDrawer(){        
        if (distanceMoved < 37f) {
            if (reversed) {
                transform.parent.Rotate(0, -2.5f, 0 * Time.deltaTime);
                distanceMoved += 1f;
            }
            else {
                transform.parent.Rotate(0, 2.5f, 0 * Time.deltaTime);
                distanceMoved += 1f;
            }
        }
    }

    void closeDrawer(){
        if (distanceMoved > 0f) {
            if (reversed)
            {
                transform.parent.Rotate(0, 2.5f, 0 * Time.deltaTime);
                distanceMoved -= 1f;
            }
            else
            {
                transform.parent.Rotate(0, -2.5f, 0 * Time.deltaTime);
                distanceMoved -= 1f;
            }


        }
    }
}
