using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float MoveSpeed;
    private CharacterController cc;

    public Transform PlayerTransform;
   
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Paused)
        {
            return;
        }
        

        var xInput = Input.GetAxis("Horizontal");
        var zInput = Input.GetAxis("Vertical");
        var inputVector = new Vector3(xInput, 0, zInput).normalized;

        cc.Move(transform.forward * inputVector.z * MoveSpeed * Time.deltaTime);
        cc.Move(transform.right * inputVector.x * MoveSpeed * Time.deltaTime);
        if(inputVector.magnitude > 0)
        {
            PlayerTransform.rotation = Quaternion.LookRotation(inputVector);
        }





    }
}
