using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    //[SerializeField]
    //private float castDistance = 5f;
    [SerializeField]
    private Vector3 raycastOffset = new Vector3(0, 1f, 0);

    [SerializeField]
    private GameObject interactionUI;

    [Header("Layers")]
    public LayerMask triggerLayer;     // Layer to trigger a boolean

    [Header("RayConfig")]
    public int rayCount;       // Number of rays
    public int rayLength;      // Length of the rays

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //CastRays();
        if (DoInteractionTest(out IInteractable interactable)) 
        {
            if (interactable.CanInteract())
            {
                interactionUI.SetActive(true);

                if (Input.GetMouseButton(1))
                {
                    interactable.Interact(this);
                }
            }
            else 
            {
                interactionUI.SetActive(false);
            }
        }
        else
        {
            interactionUI.SetActive(false);
        }

    }
    private bool DoInteractionTest(out IInteractable interactable)
    {
        interactable = null;
        float angleStep = 360f / rayCount;

        for (int i = 0; i < rayCount; i++)
        {
            float currentAngle = i * angleStep;
            Vector3 direction = transform.rotation * Quaternion.Euler(0f, currentAngle, 0f) * Vector3.forward;

            Ray ray = new Ray(transform.position + raycastOffset, direction);
            Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, rayLength))
            {
                interactable = hitInfo.collider.GetComponent<IInteractable>();

                if (interactable != null)
                {
                    return true;
                }
            }
        }

        return false;
    }

}
