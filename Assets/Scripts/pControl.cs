using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


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

    Color c;


    GameObject aText;
    GameObject lText;
    GameObject sText;
    GameObject pText;
    GameObject rText;
    GameObject centerLook;

    public Text pTextHolder;

       
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
        sText = GameObject.Find("searchText");
        rText = GameObject.Find("readText");
        pText = GameObject.Find("playerMessage");


        pTextHolder = pText.transform.gameObject.GetComponent<Text>();
        
        aText.SetActive(false);
        lText.SetActive(false);
        sText.SetActive(false);
        pText.SetActive(false);
        rText.SetActive(false);
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


        aText.SetActive(false);
        lText.SetActive(false);
        sText.SetActive(false);
        rText.SetActive(false);
        centerLook.SetActive(false);

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
                if (thisRayHit.searchable)
                {
                    sText.SetActive(true);
                } else if (thisRayHit.readable)
                {
                    rText.SetActive(true);

                }
                
            }
        }

    }



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
;
            }
        }

    }


    private void ProcessRaycast2(){
        RaycastHit hit;

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range)) {
            //  ( from, directoin, info about the hit, how far to look  )   

            thisHit = hit.collider.gameObject;
        
            thisDrawer = hit.collider.gameObject.GetComponent<openClose>();
            
            /*
             * 
             * OLD = switch to universal raycasrt
             * 
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
            */

            
        } 
    }


    public void setPMessage(string message, int timeout)
    {
        pText.SetActive(true);

        pTextHolder.text = message;

        // Added to reset routine if interupted before finished
        StopCoroutine("FadeOut");
        c = pTextHolder.color;
        c.a = 1f;
        pTextHolder.color = c;
        ///////////////////////////////

        StartCoroutine("FadeOut");
    }


    

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(2f);

        for (float ft = 1f; ft >= 0; ft -= 0.05f)
        {
            c.a = ft;
            pTextHolder.color = c;
            yield return new WaitForSeconds(0.1f);
        }

        c.a = 1f;
        pTextHolder.color = c;
        pText.SetActive(false);
    }

}
