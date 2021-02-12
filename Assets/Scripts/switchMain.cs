using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchMain : interactable
{
    private List<GameObject> allLights = new List<GameObject>();
    [SerializeField] GameObject light1;
    [SerializeField] GameObject light2;
    [SerializeField] GameObject light3;
    [SerializeField] GameObject blMessage;


    GameObject on;
    GameObject off;
    //int lightCount;
    bool lightOn = true;

    Color32 greenColorOn = new Color32(0, 255, 0, 1);
    Color32 greenColorOff = new Color32(0, 55, 0, 1);
    Color32 redColorOn = new Color32(255, 0, 0, 1);
    Color32 redColorOff = new Color32(55, 0, 0, 1);


    private void Start()
    {

        on = GameObject.Find("On");
        off = GameObject.Find("Off");
        blMessage.SetActive(false);


        on.gameObject.GetComponent<MeshRenderer>().material.color = greenColorOn;
        off.gameObject.GetComponent<MeshRenderer>().material.color = redColorOff;
    }





    private void Update()
    {
        if (lookedAt)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                flipSwitch();

            }

        }

        lookedAt = false;
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


            blMessage.SetActive(false);
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

            blMessage.SetActive(true);
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
