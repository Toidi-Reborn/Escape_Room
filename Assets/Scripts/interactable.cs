using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable : MonoBehaviour
{

    public bool lookedAt = false;

    public virtual void Use()
    {
        Debug.Log("UsableObject.Use");
    }


}
