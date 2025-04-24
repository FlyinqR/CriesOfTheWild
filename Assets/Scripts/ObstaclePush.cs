using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePush : MonoBehaviour
{
    [SerializeField]private float pushPower = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        if (body == null|| body.isKinematic) 
        {
            return;
        }
        if (hit.moveDirection.y < -0.3f) 
        {
            return;
        }
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        body.velocity = pushDir * pushPower;
        /*Vector3 collisionPoint = hit.point;
        body.AddForceAtPosition(pushDir * pushPower, collisionPoint, ForceMode.Impulse);*/
    }
}
