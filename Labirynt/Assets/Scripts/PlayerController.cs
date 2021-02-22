using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float sprintModifier = 1.5f;
    public float gravity = -9.81f;

    CharacterController characterController;
    Vector3 velocity = new Vector3();


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 direction = x * transform.right + z * transform.forward;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            characterController.Move(direction * speed * sprintModifier * Time.deltaTime);
        }
        else
        {
            characterController.Move(direction * speed * Time.deltaTime);
        }
       

      
        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
       
    }
}
