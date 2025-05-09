using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RotatingCamera : MonoBehaviour
{
    public Transform target;
    [SerializeField] private int degrees = 10;

    public CinemachineFreeLook freelookcam;

    [SerializeField] private int xSpeed;
    [SerializeField] private int ySpeed;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        //Cursor.lockState = CursorLockMode.Confined;
        /*if (Input.GetMouseButton(1))
        {

            degrees = 10;
            transform.RotateAround(target.position, Vector3.up, Input.GetAxis("Mouse X") * degrees);
            //            transform.RotateAround (target.position, Vector3.left, Input.GetAxis ("Mouse Y")* dragSpeed);
        }
        else
        {

            degrees = 0;
            transform.RotateAround(target.position, Vector3.up, degrees * Time.deltaTime);
        }*/

        if (Input.GetMouseButton(1))
        {

            freelookcam.m_XAxis.m_MaxSpeed = xSpeed;
            freelookcam.m_YAxis.m_MaxSpeed = ySpeed;
        }
        else
        {

            freelookcam.m_XAxis.m_MaxSpeed = 0;
            freelookcam.m_YAxis.m_MaxSpeed = 0;
        }

    }
}
