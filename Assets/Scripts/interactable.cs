using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable : MonoBehaviour
{

    [SerializeField] public bool opened = false;
    [SerializeField] public bool canPickUp = true;
    [SerializeField] public bool locked = false;
    [SerializeField] public bool spinning = false;
    [SerializeField] public bool alarm = false;
    [SerializeField] public bool reversed = false;
    [SerializeField] public string requiredItem = "";
    [SerializeField] public bool searchable = false;
    [SerializeField] public bool readable = false;



    public bool lookedAt = false;
    //public bool canBePickedUp = false;




    public virtual void Use()
    {
        Debug.Log("UsableObject.Use");
    }


}
