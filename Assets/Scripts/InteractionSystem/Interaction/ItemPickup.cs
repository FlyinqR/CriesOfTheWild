using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour, IInteractable
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
        interactionScript.HoldingItem = true;
        interactionScript.itemsCollected++; // Increase collected item count
        Debug.Log("Item Collected: " + interactionScript.itemsCollected);
        interactionScript.boxColor = gameObject.GetComponent<MeshRenderer>().materials[0];
        Debug.Log(interactionScript.boxColor);
        Destroy(gameObject);
        return true;
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
