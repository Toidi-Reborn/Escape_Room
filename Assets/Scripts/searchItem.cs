using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class searchItem : interactable
{

    [SerializeField] public GameObject itemInside;



    pControl player;

    inventory myINV;
    private bool empty = false;



    void Start()
    {


        player = GameObject.Find("Player").GetComponent<pControl>();

  
        myINV = GameObject.Find("game").GetComponent<inventory>();

        if (itemInside == null)
        {
            Debug.Log("sdfsfdsf");
            empty = true;
        }
        



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
        if (!empty) {
            myINV.addToMyInv(itemInside.name);
            empty = true;

            player.setPMessage(itemInside.name + " was found", 10);

        } else
        {
            
            player.setPMessage("Nothing Found", 10);




        }
    }



}
