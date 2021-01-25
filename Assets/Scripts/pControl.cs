using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pControl : MonoBehaviour
{
    

    [SerializeField] Camera playerCamera;
    float range = 5f;

    GameObject thisHit;  //for raycast
    openClose thisDrawer; // drawer movement
    openCloseDoor thisDoor; // door movement
    pickup thisPickUp; // item pickup
    keyPad thisKeyPad; // keypad

    GameObject aText;
    GameObject lText;
    GameObject centerLook;

    void Start(){

        centerLook = GameObject.Find("SelectIMG");
        aText = GameObject.Find("actionText");
        lText = GameObject.Find("lockedText");

        aText.SetActive(false);
        lText.SetActive(false);
        centerLook.SetActive(false);        
        
    }


    void Update(){
        
        ProcessRaycast2();
        keyPadRayCast();
    }



    private void RayCastHit()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            //thisHit = hit.collider.gameObject.GetComponent<keyPad>();

            thisHit = hit.collider.gameObject;

            Debug.Log(thisHit.name);



            if (thisHit == null)
            {
                return;
            }
            else
            {
                //thisKeyPad.lookedAt = true;
                centerLook.SetActive(true);

                //Debug.Log("dsfdfdsfsdfsdfdsf");
            }
        }

    }





    private void keyPadRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            thisKeyPad = hit.collider.gameObject.GetComponent<keyPad>();
            if (thisKeyPad == null)
            {
                return;
            } else
            {
                thisKeyPad.lookedAt = true;   
                centerLook.SetActive(true);

                //Debug.Log("dsfdfdsfsdfsdfdsf");
            }
        }

    }


    private void ProcessRaycast2(){
        RaycastHit hit;
        aText.SetActive(false);
        lText.SetActive(false);
        centerLook.SetActive(false);

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range)) {
            //  ( from, directoin, info about the hit, how far to look  )   

            thisHit = hit.collider.gameObject;
        
            thisDrawer = hit.collider.gameObject.GetComponent<openClose>();
            

            if(thisDrawer == null) {
                thisDoor = hit.collider.gameObject.GetComponent<openCloseDoor>();
                
                if(thisDoor == null) {
                    thisPickUp = hit.collider.gameObject.GetComponent<pickup>();
                    
                    if(thisPickUp == null) {

                        //Debug.Log("Null Trigger");
                        return;
                    } else {
                        thisPickUp.lookedAt = true;
                        
                        centerLook.SetActive(true);
                        return;
                    }
                } else {  // if door not null
                    thisDoor.lookedAt = true;  ///////////////////
                    //string needed = thisDoor.requiredItem;  //Need?

                    if (thisDoor.locked) {
                        lText.SetActive(true);
                    }

                    aText.SetActive(true);
                    centerLook.SetActive(true);
                    return;
                }
            } else { // if drawer not null
                thisDrawer.lookedAt = true;
                    if (thisDrawer.locked) {
                    lText.SetActive(true);
                    }
                aText.SetActive(true);
                centerLook.SetActive(true);         
            }
            
        } 
    }
          

}
