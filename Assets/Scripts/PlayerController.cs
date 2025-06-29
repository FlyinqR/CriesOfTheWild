using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
public class PlayerController : MonoBehaviour
{
    CustomActions input;
    NavMeshAgent agent;
    Animator animator;

    [Header("Movement")]
    [SerializeField] ParticleSystem clickEffect;
    [SerializeField] LayerMask clickableLayers;



    [SerializeField] private float lookRotationSpeed = 8f;
    [SerializeField] private bool moving;

    
    [SerializeField] private AudioSource walkAudio;
    //[SerializeField] private AudioClip walkClip;

    private TandLScript tandLScript;

    public Animator playerAni;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        input = new CustomActions();
        AssignInputs();

    }

    void AssignInputs()
    {
        input.Main.Move.performed += ctx => ClickToMove();
    }

    void ClickToMove()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers))
        {
            agent.destination = hit.point;
            if (clickEffect != null)
            {
                Instantiate(clickEffect, hit.point += new Vector3(0, 0.01f, 0), clickEffect.transform.rotation);
            }
        }


    }

    private void Start()
    {
        tandLScript = GameObject.Find("TimeManager").GetComponent<TandLScript>();
        moving = false;
    }


    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }

    private void Update()
    {

        if (Vector3.Distance(agent.destination, transform.position) > 0.1)
        {
            FaceTarget();
            walkAudio.enabled = true;
            playerAni.SetBool("canWalk", true);
        }
        else 
        {
            walkAudio.enabled = false;
            playerAni.SetBool("canWalk", false);
        }

        //SetAnimations();


        if (tandLScript.playerLose) 
        {
            walkAudio.enabled = false;
        }
    }


    void FaceTarget()
    {

        Vector3 direction = (agent.destination - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookRotationSpeed);



    }
}
