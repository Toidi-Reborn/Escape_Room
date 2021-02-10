using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dailRotate : MonoBehaviour
{

    [SerializeField] public bool lookedAt = false;
    GameObject rotationBar;
    public int dailNumber = 0;


    void Start()
    {
        rotationBar = this.transform.GetChild(0).gameObject;
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

            rotationBar.transform.Rotate(0,36f,0 * Time.deltaTime);
            if (dailNumber == 9)
            {
                dailNumber = 0;
            } else
            {
                dailNumber += 1;
            }

        }
    }

}




