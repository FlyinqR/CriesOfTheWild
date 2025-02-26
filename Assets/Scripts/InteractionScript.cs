using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    public bool HoldingItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HoldingItem && Input.GetMouseButton(1))
        {
            Debug.Log("Item Dropped");
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Interactable" && HoldingItem == false && Input.GetMouseButton(1))
        {
            HoldingItem = true;
            Debug.Log("Item Collected");
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            Debug.Log("Item Can Be Picked Up");
        }
    }
}
