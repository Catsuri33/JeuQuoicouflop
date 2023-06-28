using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera camera;
    [SerializeField]
    private float distance = 3.0f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;
    private InputManager inputManager;

    void Start()
    {

        camera = GetComponent<PlayerLook>().camera;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
        
    }

    void Update()
    {

        playerUI.UpdateText(string.Empty);

        Ray ray = new Ray(camera.transform.position, camera.transform.forward);
        RaycastHit hitInfo;
        
        if(Physics.Raycast(ray, out hitInfo, distance, mask)){

            if(hitInfo.collider.GetComponent<Interactable>() != null){

                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();

                playerUI.UpdateText(interactable.description.GetLocalizedString());

                if(inputManager.onFloor.Interact.triggered){

                    interactable.BaseInteract();

                }

            }

        }
        
    }
}
