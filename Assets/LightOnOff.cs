using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnOff : MonoBehaviour
{
    [SerializeField] public bool lightOn = true;      


    void Start()
    {
        this.gameObject.SetActive(lightOn);
    }
    
}
