using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemPickup : MonoBehaviour, IInteractable
{
    private bool hasInteracted = false;
    private InteractionManager interactionManager;
    private PlayerInteraction interactor;
    [SerializeField] private TextMeshProUGUI UIText;
    private bool PU_allowed;

    public bool CanInteract()
    {
        if (hasInteracted) 
        {
            
            return false;
        }
        PU_allowed = true;
        return true;
    }

    public bool Interact(PlayerInteraction interactor)
    {
        if (interactionManager.HoldingItem == false) 
        {
            interactionManager.HoldingItem = true;
            interactionManager.itemsCollected++; // Increase collected item count
            Debug.Log("Item Collected: " + interactionManager.itemsCollected);
            interactionManager.itemTag = gameObject.tag;
            Debug.Log(interactionManager.itemTag);
            Destroy(gameObject);
            return true;
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        interactionManager = GameObject.Find("InteractionRadius").GetComponent<InteractionManager>();
        interactor = GameObject.Find("Player").GetComponent<PlayerInteraction>();
        UIText = GameObject.Find("InteractionText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PU_allowed)
        {
            UIText.text = "Collect";
        }
        if (interactor.DoInteractionTest(out IInteractable interactable)) 
        {
            PU_allowed = false;
        }
    }
}

