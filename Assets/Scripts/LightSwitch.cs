using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{

    private List<GameObject> allLights = new List<GameObject>();
    [SerializeField] GameObject light1;
    [SerializeField] GameObject light2;
    [SerializeField] GameObject light3;
   

    GameObject on;
    GameObject off;
    int lightCount;
    bool lightOn = true;

    Color32 greenColorOn = new Color32(0, 255, 0, 1);
    Color32 greenColorOff = new Color32(0, 55, 0, 1);
    Color32 redColorOn = new Color32(255, 0, 0, 1);
    Color32 redColorOff = new Color32(55, 0, 0, 1);

    
    void Start()
    {
       
        if (light2 == null)
        {
            lightCount = 1;

        } else if (light3 == null)
        {
            lightCount = 2;
        } else
        {
            lightCount = 3;
        }
        
        on = GameObject.Find("On");
        off = GameObject.Find("Off");

        on.gameObject.GetComponent<MeshRenderer>().material.color = greenColorOn;
        off.gameObject.GetComponent<MeshRenderer>().material.color = redColorOff;



        Debug.Log(lightCount);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            flipSwitch();

        }




    }


    void flipSwitch()
    {

        lightOn = !lightOn;

        if (lightOn)
        {
            on.gameObject.GetComponent<MeshRenderer>().material.color = greenColorOn;
            off.gameObject.GetComponent<MeshRenderer>().material.color = redColorOff;
            on.transform.Translate(0, 0.1f, 0 * Time.deltaTime * 3.5f);
            off.transform.Translate(0, -0.1f, 0 * Time.deltaTime * 3.5f);


            light1.SetActive(true);

            if (light2 != null)
            {
                light2.SetActive(true);
            }

            if (light3 != null)
            {
                light3.SetActive(true);
            }
        }
        else
        {

            on.gameObject.GetComponent<MeshRenderer>().material.color = greenColorOff;
            off.gameObject.GetComponent<MeshRenderer>().material.color = redColorOn;
            on.transform.Translate(0, -0.1f, 0 * Time.deltaTime * 3.5f);
            off.transform.Translate(0, 0.1f, 0 * Time.deltaTime * 3.5f);


            light1.SetActive(false);
            if (light2 != null)
            {
                light2.SetActive(false);
            }

            if (light3 != null)
            {
                light3.SetActive(false);
            }

        }




    }


}
