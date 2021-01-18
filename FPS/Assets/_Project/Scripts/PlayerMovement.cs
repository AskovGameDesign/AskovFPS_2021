using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpHeight = 2.5f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.5f;
    Vector3 movement;
    bool isGrounded;
    CharacterController character;
    Vector3 velocity;
        
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Tjeck om vi står på jorden 
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
        
        if(isGrounded && velocity.y < 0f)
        {
            velocity.y = -1f;
        }

        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        movement = (transform.right * xMovement) + (transform.forward * zMovement);
        character.Move(movement * speed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -3f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        character.Move(velocity * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
