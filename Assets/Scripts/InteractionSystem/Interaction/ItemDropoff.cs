using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemDropoff : MonoBehaviour, IInteractable
{
    private bool hasInteracted = false;
    private InteractionManager interactionManager;
    private PlayerInteraction interactor;
    [SerializeField] private TextMeshProUGUI UIText;
    private bool DO_allowed;

    public bool CanInteract()
    {
        if (hasInteracted)
        {
            
            return false;
        }
        DO_allowed = true;
        return true;
    }

    public bool Interact(PlayerInteraction interactor)
    {
        
        if (interactionManager.HoldingItem && Input.GetMouseButton(1))
        {
            interactionManager.PressurePlateTag = gameObject.tag;
            Debug.Log(interactionManager.PressurePlateTag);
            if (interactionManager.PressurePlateTag == interactionManager.itemTag)
            {
                Debug.Log("Item Dropped");

                interactionManager.activatedPressurePlates++; // Increase activated plate count
                interactionManager.objTextScript.ppAmount -= 1;
                Debug.Log("Pressure Plate Activated: " + interactionManager.activatedPressurePlates);
                gameObject.SetActive(false);

                interactionManager.CheckLevelCompletion();// Check if all plates are activated
                interactionManager.HoldingItem = false;
                interactionManager.clickAudio.PlayOneShot(interactionManager.clickClip);
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
        interactionManager = GameObject.Find("InteractionRadius").GetComponent<InteractionManager>();
        interactor = GameObject.Find("Player").GetComponent<PlayerInteraction>();
        UIText = GameObject.Find("InteractionText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DO_allowed) 
        {
            UIText.text = "Activate";
        }
        if (interactor.DoInteractionTest(out IInteractable interactable))
        {
            DO_allowed = false;
        }
    }
}
