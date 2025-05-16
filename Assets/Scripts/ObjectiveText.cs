using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI objText;
    public int ppAmount;
    // Start is called before the first frame update
    void Start()
    {
        ppAmount = 5;
    }

    // Update is called once per frame
    void Update()
    {
        updateText();
    }

    private void updateText() 
    {
        objText.text = ("Activate the all the pressure plates: " + ppAmount + "/5");
    }
}
