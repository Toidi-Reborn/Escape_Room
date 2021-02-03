using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting : MonoBehaviour
{

    [SerializeField] GameObject light1;
    [SerializeField] GameObject light2;
    [SerializeField] GameObject light3;
    [SerializeField] GameObject light4;
    [SerializeField] GameObject light5;
    [SerializeField] GameObject light6;
    [SerializeField] GameObject light7;
    [SerializeField] GameObject light8;
    [SerializeField] GameObject light9;
    [SerializeField] GameObject light10;


    [SerializeField] int lightTotal = 10;

    

    void Start()
    {
        for (int i = 1; i <= lightTotal; i++)
        {
            var thisLight = "light" + i.ToString();

        }


        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            lightToggle(light1);
        }



    }


    public void lightToggle(GameObject x)
    {
        bool cur = x.activeInHierarchy;
        x.SetActive(!cur);


    }






}
