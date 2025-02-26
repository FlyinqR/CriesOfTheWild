using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PressurePlate : MonoBehaviour
{
    // Start is called before the first frame update
    public  PPMangerScript manager;
    public bool isActivated = false;

    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(!isActivated && other.CompareTag("Player"))
        {
            isActivated = true;
            Debug.Log(gameObject.name + "activated");
            manager.ActivatePlate();
            
        }

       
    }
}

