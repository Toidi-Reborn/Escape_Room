using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pControl : MonoBehaviour
{
   
    [SerializeField] Camera playerCamera;
    float range = 28f;

    GameObject thisHit;  //for raycast
    openClose thisDrawer; // drawer movement
    openCloseDoor thisDoor; // door movement

    pickup thisPickUp; // item pickup
    keyPad thisKeyPad; // keypad
    dailRotate thisDail; // end game dail
    monitor thisPC;  // PC Screen

    //combine raycasting
    interactable thisRayHit;




    GameObject aText;
    GameObject lText;
    GameObject centerLook;


    float charHeight;
    float charGround;

    float charHeightM;
    float charHeightC;

    float charBottomM;
    float charBottomC;


    private Vector3 originalCenter;
    private float originalHeight;
    private float originalMoveSpeed;
    public CharacterController controller;
    public GameObject myCamera;
    public float moveSpeed;





    void Start(){

        centerLook = GameObject.Find("SelectIMG");
        aText = GameObject.Find("actionText");
        lText = GameObject.Find("lockedText");

        aText.SetActive(false);
        lText.SetActive(false);
        centerLook.SetActive(false);

        //for test
        //Debug.Log(charBottomM + " - " + charBottomC + " - " + charheightM + " - " + charheightC);


    }


    void Update(){
        ProcessRaycast2();
        keyPadRayCast();
        DailRayCast();

        //pcRayCast();

        // new raycast way (by inheriting a class) to avoid multiple raycasts

        allRayCast();

   
    }

    private void allRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            thisRayHit = hit.collider.gameObject.GetComponent<interactable>();

            if (thisRayHit == null)
            {
                return;
            }
            else
            {
                thisRayHit.lookedAt = true;
                centerLook.SetActive(true);

                //Debug.Log("dsfdfdsfsdfsdfdsf");
            }
        }

    }


 
    /*
    private void pcRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            thisPC = hit.collider.gameObject.GetComponent<monitor>();

            if (thisPC == null)
            {
                return;
            }
            else
            {
                thisPC.lookedAt = true;
                centerLook.SetActive(true);

                //Debug.Log("dsfdfdsfsdfsdfdsf");
            }
        }

    }


    */




    /*
    private void RayCastHit()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {

            thisHit = hit.collider.gameObject;

            if (thisHit == null)
            {
                return;
            }
            else
            {
                //thisKeyPad.lookedAt = true;
                centerLook.SetActive(true);
                
            }
        }

    }
    */



    private void DailRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            thisDail = hit.collider.gameObject.GetComponent<dailRotate>();

            if (thisDail == null)
            {
                return;
            }
            else
            {
                thisDail.lookedAt = true;
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
