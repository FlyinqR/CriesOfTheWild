using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public Camera mainCam;
    public float interactionDistance = 2f;

    public GameObject interactionUI;
    public TextMeshProUGUI interactionText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InteractionRay();
    }

    void InteractionRay() 
    {
        Ray ray = mainCam.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;

        bool hitSomething = false;

        if (Physics.Raycast(ray, out hit, interactionDistance)) 
        {
            IIenteractable interactable = hit.collider.GetComponent<IIenteractable>();

            if (interactable != null) 
            {
                hitSomething = true;
                interactionText.text = interactable.getDescription();

                if (Input.GetMouseButton(1)) 
                {
                    interactable.Interact();
                }
            }
        }

        interactionUI.SetActive(hitSomething);

    }
}
