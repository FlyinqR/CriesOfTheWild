using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCamera : MonoBehaviour
{
    public Transform target;
    [SerializeField] private int degrees = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {

            degrees = 10;
            transform.RotateAround(target.position, Vector3.up, Input.GetAxis("Mouse X") * degrees);
            //            transform.RotateAround (target.position, Vector3.left, Input.GetAxis ("Mouse Y")* dragSpeed);
        }
        if (!Input.GetMouseButton(1))
            transform.RotateAround(target.position, Vector3.up, degrees * Time.deltaTime);
        else
        {

            degrees = 0;
        }
    }
}
