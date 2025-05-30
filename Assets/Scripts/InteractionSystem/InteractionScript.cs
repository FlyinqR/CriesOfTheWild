using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;   // Import Scene Management
using UnityEngine.UI;

public class InteractionScript : MonoBehaviour
{
    public bool HoldingItem;
    private int activatedPressurePlates = 0; // Track activated plates
                                             // [SerializeField]

    public int totalItems = 1; // Set this based on the number of items
    public int itemsCollected = 0; // Track collected items
    public Material boxColor;
    public Material PressurePlateColor;
    private bool isBigCubeOnPlate = false;
    private GameObject bigPressurePlate;
    public GameObject Bridge;

    [SerializeField] private AudioSource clickAudio;
    [SerializeField] private AudioClip clickClip;

    private ObjectiveText objTextScript;

    void Start()
    {
        Debug.Log("Total Items Expected: " + totalItems);
        objTextScript = GameObject.Find("GameManager").GetComponent<ObjectiveText>();
    }


    void Update()
    {
        CheckLevelCompletion();
    }



    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        // Make sure there's a Collider on this object
        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            Gizmos.DrawWireCube(col.bounds.center, col.bounds.extents * 2);
        }
    }





    private void OnTriggerStay(Collider collision)
    {

        // BIG CUBE logic
        // BIG CUBE logic
        if (collision.gameObject.CompareTag("BigPressurePlate"))
        {
            Collider[] colliders = Physics.OverlapBox(collision.bounds.center, collision.bounds.extents, Quaternion.identity);
            foreach (var col in colliders)
            {
                if (col.CompareTag("BigCube"))
                {
                    isBigCubeOnPlate = true;
                    bigPressurePlate = collision.gameObject;
                    GameObject bigCube = col.gameObject; // cache the big cube

                    // If space is pressed while big cube is on plate
                    /*if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Destroy(bigPressurePlate); // remove pressure plate
                        Destroy(bigCube);          // remove big cube

                        activatedPressurePlates++;
                        Debug.Log("Big Cube activated a pressure plate!");
                        CheckLevelCompletion();
                        isBigCubeOnPlate = false; // Reset
                    }*/
                    CheckLevelCompletion();
                    activatedPressurePlates++;
                    objTextScript.ppAmount -= 1;
                    Destroy(bigPressurePlate); // remove pressure plate
                    Destroy(bigCube);          // remove big cube

                    
                    Debug.Log("Big Cube activated a pressure plate!");

                    isBigCubeOnPlate = false; // Reset

                }
            }
        }

/*
        if (collision.gameObject.tag == "Interactable" && !HoldingItem && Input.GetMouseButton(1))
        {
            HoldingItem = true;
            itemsCollected++; // Increase collected item count
            Debug.Log("Item Collected: " + itemsCollected);
            boxColor = collision.gameObject.GetComponent<MeshRenderer>().materials[0];
            Debug.Log(boxColor);
            Destroy(collision.gameObject);

        }*/

        if (collision.gameObject.tag == "PressurePlate" && HoldingItem && Input.GetMouseButton(1))
        {
            PressurePlateColor = collision.gameObject.GetComponent<MeshRenderer>().materials[0];
            Debug.Log("Pressure Plate is"+ PressurePlateColor);
            if (PressurePlateColor.name == boxColor.name)
            {
                Debug.Log("Item Dropped");

                activatedPressurePlates++; // Increase activated plate count
                objTextScript.ppAmount -= 1;
                Debug.Log("Pressure Plate Activated: " + activatedPressurePlates);
                collision.gameObject.SetActive(false);

                CheckLevelCompletion();// Check if all plates are activated
                HoldingItem = false;
                clickAudio.PlayOneShot(clickClip);
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
            Debug.Log("Level Complete! Reveling the Hidden Bridge");

            // if (!hiddenbridge.activeInHierarchy)

            Destroy(Bridge);
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
