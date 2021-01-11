using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openCloseDoor : MonoBehaviour
{
    [SerializeField] public bool opened = false;
    [SerializeField] public bool interactable = true;
    [SerializeField] public bool locked = false;


    public bool lookedAt = false;
    private GameObject actionDisplay;
    private GameObject hinge;
    private float distanceMoved = 0f;
    
     

    void Start()
    {
        actionDisplay = this.transform.Find("myButton").gameObject;
        //hinge = this.transform;

    }
 


    void Update()
    {
        actionDisplay.SetActive(false);

        if (lookedAt){
                //actionDisplay.SetActive(true);   //too put x image - may not want
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
                Debug.Log("Locked!!!!!!!!!");

            }
   
        }
    
    }


    void keyXPressed(){
        opened = !opened; 
    }


    void openDrawer(){        
        if (distanceMoved < 37f) {
            transform.parent.Rotate(0,2.5f,0 * Time.deltaTime);
            distanceMoved += 1f;
        }
    }

    void closeDrawer(){
        if (distanceMoved > 0f) {
            transform.parent.Rotate(0,-2.5f, 0 * Time.deltaTime);
            distanceMoved -= 1f;
        }
    }
}
