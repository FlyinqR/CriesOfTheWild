using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteraction : MonoBehaviour, IInteractable
{

    Material mat;
    public string getDescription()
    {
        return "Change to a random colour";
    }

    public void Interact()
    {
        mat.color = new Color(Random.value, Random.value, Random.value);
    }

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
