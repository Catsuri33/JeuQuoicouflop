using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public abstract class Interactable : MonoBehaviour
{
    
    public LocalizedString description;

    public void BaseInteract(){

        Interact();

    }

    protected virtual void Interact(){}

}
