using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openClose : MonoBehaviour
{
    [SerializeField] public bool opened = false;
    [SerializeField] public bool interactable = true;
    [SerializeField] public bool locked = false;


    public bool lookedAt = false;
    private GameObject actionDisplay;



    private Vector3 startX;
    private float distanceMoved = 0f;
    
    void Start()
    {
        startX = transform.position;
        actionDisplay = GameObject.Find("myButton");
        actionDisplay.SetActive(false);
    }
 


    void Update()
    {
        actionDisplay.SetActive(false);

        if (lookedAt){
                actionDisplay.SetActive(true);    //too put x image - may not want
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
        if (distanceMoved < 2.5f) {
            Vector3 oldSpot = transform.position;
            transform.Translate(0,0,1 * Time.deltaTime * 3.5f);
            distanceMoved += Vector3.Distance(oldSpot, transform.position);
        }
    }

    void closeDrawer(){
        if (distanceMoved >= 0f) {
            Vector3 oldSpot = transform.position;
            transform.Translate(0,0,-1 * Time.deltaTime * 3.5f);
            distanceMoved -= Vector3.Distance(oldSpot, transform.position);

        } else {
            //reset to start spot
            transform.position = startX;

        }


    }
    
}
