using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class inventory : MonoBehaviour {
   
    private List<GameObject> invSpots = new List<GameObject>();
    private List<GameObject> invItems = new List<GameObject>();
    public List<GameObject> myInvItems = new List<GameObject>();
    private bool showInv = false;
    private int curInvSel = 0;

    public GameObject itemList;

    GameObject window;
    FirstPersonController fpc;
    GameObject invSelect;
    


// Need to generate item squars through script.... delete prefab parts
    
    void Start() {
        
        for (var i = 1; i < 13; i++)
        {
            invSpots.Add(GameObject.Find("InvSpot" + i.ToString()));
            invSpots[i-1].SetActive(false);
        }

        invSelect = GameObject.Find("invSelect");

        window = GameObject.Find("iWindow");
        window.SetActive(false);
        
        fpc = GameObject.Find("Player").GetComponent<FirstPersonController>();

        itemList = GameObject.Find("items");


        foreach (Transform child in itemList.transform)
        {
            invItems.Add(child.gameObject);
            //Debug.Log(child.name);
            //  if (child.name == "Hand")  line used.... temo for testing
            if (child.name == "Hand")
            {
                myInvItems.Add(child.gameObject);
            } else
            {
                child.gameObject.SetActive(false);
            }

        }
        

        /*  for testing */
        string pName = "Key 001";
        foreach (Transform gg in itemList.transform)
        {
            
            if (gg.name == pName)
            {
                myInvItems.Add(gg.gameObject);
                Debug.Log(gg);
            }
        }
    }
    
     
    void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {
            if (showInv){
                hide();
            } else {
                setInvSpots();
                show();
            }
            showInv = !showInv;
        
         //   Debug.Log(myInventory[0]);
       //     Debug.Log(myInventory.Count);
       
        }

        if (showInv) {

            int count = myInvItems.Count;


            if (Input.GetKeyDown("up"))
            {
                moveUp(count);
            }
            else if (Input.GetKeyDown("down"))
            {
                moveDown(count);
            }
            else if (Input.GetKeyDown("right"))
            {
                moveRight(count);
            }
            else if (Input.GetKeyDown("left"))
            {
                moveLeft(count);
            }

        }


    }


    public void addToMyInv(string pName)
    {
        
        foreach (Transform gg in itemList.transform)
        {

            if (gg.name == pName)
            {
                myInvItems.Add(gg.gameObject);
                //Debug.Log(gg);
            }
        }

    }


    private void setInvSpots()
    {
        for (var i = 0; i < myInvItems.Count; i++)
        {
            invSpots[i].SetActive(true);
            myInvItems[i].SetActive(true);
            Debug.Log(invSpots[i].gameObject.transform.Find("name").GetComponent<UnityEngine.UI.Text>().text);

            myInvItems[i].transform.position = invSpots[i].transform.position;
            invSpots[i].gameObject.transform.Find("name").GetComponent<UnityEngine.UI.Text>().text = myInvItems[i].name;

        }
    }
   



    private void moveLeft(int c)
    {

        if (curInvSel > 0)
        {
            curInvSel -= 1;
            invSelect.transform.position = invSpots[curInvSel].transform.position;
        }
                     
    }
    private void moveRight(int c)
    {
        if (c > curInvSel + 1) { 
            curInvSel += 1;
            invSelect.transform.position = invSpots[curInvSel].transform.position;
        }
    }
    private void moveDown(int c)
    {
        if (curInvSel < 8 && curInvSel + 4 < c)
        {   
            curInvSel += 4;
            invSelect.transform.position = invSpots[curInvSel].transform.position;
        }

    }
    private void moveUp(int c)
    {
        if ( curInvSel > 3) { 
            curInvSel -= 4;
            invSelect.transform.position = invSpots[curInvSel].transform.position;
        }

    }


    void show(){
        window.SetActive(true);
        fpc.enabled = false;
    }

    void hide(){


        for (var i = 0; i < myInvItems.Count; i++)
        {
            myInvItems[i].SetActive(false);

        }
        myInvItems[curInvSel].SetActive(true);
        myInvItems[curInvSel].transform.position = GameObject.Find("curInvItem").transform.position;
        GameObject.Find("curInvItem").transform.Find("name").GetComponent<UnityEngine.UI.Text>().text = myInvItems[curInvSel].name;
        window.SetActive(false);
        fpc.enabled = true;
    }



}
