using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionItem : MonoBehaviour
{

    [SerializeField] public bool opened = false;
    [SerializeField] public bool isDoor = false;
    [SerializeField] public bool isDrawer = false;
    private Vector3 startX;

    [SerializeField] public bool locked = false;
    [SerializeField] public string requiredItem = "";
    [SerializeField] public GameObject doorHinge;
    [SerializeField] public bool reversed = false;
    private float distanceMoved = 0f;


    [SerializeField] public bool canPickUp = false;
    [SerializeField] public bool spinning = false;

    [SerializeField] public bool hasAlarm = false;


    [SerializeField] public bool searchable = false;
    [SerializeField] public GameObject itemInside;
    private bool empty = false;


    [SerializeField] public bool readable = false;
    [SerializeField] public string message = "Placeholder Text";
    [SerializeField] public int messageAlive = 10;

    public bool lookedAt = false;
    
    pControl player;
    inventory myINV;

    
    void Start()
    {

        player = GameObject.Find("Player").GetComponent<pControl>();
        myINV = GameObject.Find("game").GetComponent<inventory>();

        if (itemInside == null)
        {
            empty = true;
        }


        if (isDrawer)
        {
            startX = transform.position;
        }

    }
    
    void Update()
    {

        if (isDoor)
        {
            if (opened)
            {
                openDoor();
            }
            else
            {
                closeDoor();
            }
        }


        if (isDrawer)
        {
            if (opened)
            {
                openDrawer();
            }
            else
            {
                closeDrawer();
            }
        }

 
        if (spinning)
        {
            transform.Rotate(0, 2.5f, 0 * Time.deltaTime);
        }


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
            if (searchable)
            {
                player.centerText = "Search";
                search();
            } else if (readable)
            {
                player.centerText = "Read";
                readMessage();
            } else if (canPickUp)
            {
                player.centerText = "Pick-Up";
                pickup();
            } else if (isDoor || isDrawer)
            {
                player.centerText = "Open / Close";
                if (locked)
                {
                    checkLock();
                } else
                {
                    toggleDoor();
                }

            }


        }

    }


    void checkLock()
    {
        string curSel = myINV.myInvItems[myINV.curInvSel].name;
        

        if (curSel == requiredItem)
        {
            toggleDoor();

        } else
        {
            player.setPMessage("LOCKED! " + requiredItem + " is needed.", messageAlive);
        }

    }


    void toggleDoor()
    {
        opened = !opened;
    }




    void openDrawer()
    {
        if (distanceMoved < 2.5f)
        {
            Vector3 oldSpot = transform.position;
            transform.Translate(0, 0, 1 * Time.deltaTime * 3.5f);
            distanceMoved += Vector3.Distance(oldSpot, transform.position);
        }
    }

    void closeDrawer()
    {
        if (distanceMoved >= 0f)
        {
            Vector3 oldSpot = transform.position;
            transform.Translate(0, 0, -1 * Time.deltaTime * 3.5f);
            distanceMoved -= Vector3.Distance(oldSpot, transform.position);

        }
        else
        {
            transform.position = startX;

        }


    }

    void openDoor()
    {
        if (distanceMoved < 37f)
        {
            if (doorHinge == null)
            {
                Debug.Log("No Hinge Assigned");
            }
            else
            {
                if (reversed)
                {
                    doorHinge.transform.Rotate(0, -2.5f, 0 * Time.deltaTime);
                    distanceMoved += 1f;
                }
                else
                {
                    doorHinge.transform.Rotate(0, 2.5f, 0 * Time.deltaTime);
                    distanceMoved += 1f;
                }
            }
        }
    }

    void closeDoor()
    {
        if (distanceMoved > 0f)
        {
            if (doorHinge == null)
            {
                Debug.Log("No Hinge Assigned");

            }
            else
            {
                if (reversed)
                {
                    doorHinge.transform.Rotate(0, 2.5f, 0 * Time.deltaTime);
                    distanceMoved -= 1f;
                }
                else
                {
                    doorHinge.transform.Rotate(0, -2.5f, 0 * Time.deltaTime);
                    distanceMoved -= 1f;
                }

            }

        }

    }


    void pickup()
    {
        Debug.Log(name);
        myINV.addToMyInv(name);
        Destroy(gameObject);
    }




    void readMessage()
    {
        player.setPMessage(message, messageAlive);
    }




    void search()
    {
        if (!empty)
        {
            myINV.addToMyInv(itemInside.name);
            empty = true;

            player.setPMessage(itemInside.name + " was found", 10);

        }
        else
        {

            player.setPMessage("Nothing Found", 10);

        }

    }





}
