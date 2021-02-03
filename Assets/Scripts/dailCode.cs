using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dailCode : MonoBehaviour
{

    GameObject dails;
    dailRotate dail1, dail2, dail3, dail4, dail5;

    


    void Start()
    {

        dails = this.transform.GetChild(0).gameObject;

        dail1 = dails.transform.GetChild(0).gameObject.GetComponent<dailRotate>();
        dail2 = dails.transform.GetChild(1).gameObject.GetComponent<dailRotate>();
        dail3 = dails.transform.GetChild(2).gameObject.GetComponent<dailRotate>();
        dail4 = dails.transform.GetChild(3).gameObject.GetComponent<dailRotate>();
        dail5 = dails.transform.GetChild(4).gameObject.GetComponent<dailRotate>();
        
    }

    void Update()
    {
        //Debug.Log(dail1.dailNumber);
        
    }
}
