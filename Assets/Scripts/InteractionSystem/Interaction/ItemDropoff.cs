using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropoff : MonoBehaviour, IInteractable
{
    private bool hasInteracted = false;
    public InteractionScript interactionScript;
    public bool CanInteract()
    {
        if (hasInteracted)
        {
            return false;
        }
        return true;
    }

    public bool Interact(PlayerInteraction interactor)
    {
        if (interactionScript.HoldingItem && Input.GetMouseButton(1))
        {
            interactionScript.PressurePlateColor = gameObject.GetComponent<MeshRenderer>().materials[0];
            Debug.Log(interactionScript.PressurePlateColor);
            if (interactionScript.PressurePlateColor.name == interactionScript.boxColor.name)
            {
                Debug.Log("Item Dropped");

                interactionScript.activatedPressurePlates++; // Increase activated plate count
                interactionScript.objTextScript.ppAmount -= 1;
                Debug.Log("Pressure Plate Activated: " + interactionScript.activatedPressurePlates);
                gameObject.SetActive(false);

                interactionScript.CheckLevelCompletion();// Check if all plates are activated
                interactionScript.HoldingItem = false;
                interactionScript.clickAudio.PlayOneShot(interactionScript.clickClip);
                return true;
            }
            else
            {
                Debug.Log("Wrong Piece");
                //Debug.Log("Plate color is " + PressurePlateColor);
                //Debug.Log("Box color is " + boxColor);
                return false;
            }

        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        interactionScript = GameObject.Find("InteractionRadius").GetComponent<InteractionScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
