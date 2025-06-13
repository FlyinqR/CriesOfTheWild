using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;   // Import Scene Management
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour
{
    public bool HoldingItem;
    public int activatedPressurePlates = 0; // Track activated plates
                                             // [SerializeField]

    public int totalItems = 1; // Set this based on the number of items
    public int itemsCollected = 0; // Track collected items

    public string itemTag;
    public string PressurePlateTag;

    private bool isBigCubeOnPlate = false;
    private GameObject bigPressurePlate;
    public GameObject Bridge;

    public AudioSource clickAudio;
    public AudioClip clickClip;

    public ObjectiveText objTextScript;

    private LevelLoader levelLoader;

    void Start()
    {
        Debug.Log("Total Items Expected: " + totalItems);
        objTextScript = GameObject.Find("GameManager").GetComponent<ObjectiveText>();
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
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

        
    }

    public void CheckLevelCompletion()
    {
        if (activatedPressurePlates >= totalItems)
        {
            Debug.Log("Level Complete! Reveling the Hidden Bridge");

            // if (!hiddenbridge.activeInHierarchy)

            Destroy(Bridge);
            levelLoader.LoadNextLevel();

        }
    }

    


}
