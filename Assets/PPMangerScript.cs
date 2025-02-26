using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PPMangerScript : MonoBehaviour
{
    private int totalPlates = 5;
    private int activatedPlates = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivatePlate()
    {
        activatedPlates++;
        Debug.Log("Plates" + activatedPlates);

        if (activatedPlates >= totalPlates)
        {
            LoadNextScene();
        }


        void LoadNextScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

