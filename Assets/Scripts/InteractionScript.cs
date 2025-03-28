using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Import Scene Management

public class InteractionScript : MonoBehaviour
{
    public bool HoldingItem;
    private int activatedPressurePlates = 0; // Track activated plates
    public int totalItems = 5; // Set this based on the number of items
    private int itemsCollected = 0; // Track collected items
    public Material boxColor;
    public Material PressurePlateColor;

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Interactable" && !HoldingItem && Input.GetMouseButton(1))
        {
            HoldingItem = true;
            itemsCollected++; // Increase collected item count
            Debug.Log("Item Collected: " + itemsCollected);
            MeshRenderer boxColor = collision.gameObject.GetComponent<MeshRenderer>();
            Debug.Log(boxColor);
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "PressurePlate" && HoldingItem && Input.GetMouseButton(1))
        {
            MeshRenderer PressurePlateColor = collision.gameObject.GetComponent<MeshRenderer>();
            Debug.Log(PressurePlateColor);
            if (PressurePlateColor.sharedMaterial == boxColor)
            {
                Debug.Log("Item Dropped");
                
                activatedPressurePlates++; // Increase activated plate count
                Debug.Log("Pressure Plate Activated: " + activatedPressurePlates);
                collision.gameObject.SetActive(false);

                CheckLevelCompletion(); // Check if all plates are activated
                HoldingItem = false;
            }
            else
            {
                Debug.Log("Wrong Piece");
                //Debug.Log("Plate color is " + PressurePlateColor);
                //Debug.Log("Box color is " + boxColor);
            }
           
        }
    }

    private void CheckLevelCompletion()
    {
        if (activatedPressurePlates >= totalItems)
        {
            Debug.Log("Level Complete! Loading Next Level...");
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1; // Get next scene index
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings) // Check if next scene exists
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more levels available!");
        }
    }

    
}
