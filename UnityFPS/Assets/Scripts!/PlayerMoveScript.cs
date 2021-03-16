using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{

    public CharacterController PlayerController;

    
    public float moveSpeed = 4f;

    public float Gravity = -9.81f;

    public float jumpHeight = 5f;

    public bool isGrounded;

    public Transform GroundCheckingObject;

    public LayerMask ground;

    public Vector3 velocity;


    public float distanceOfGround = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(GroundCheckingObject.position, distanceOfGround, ground);

        float xAxis = Input.GetAxis("Horizontal") * moveSpeed;
        float zAxis = Input.GetAxis("Vertical") * moveSpeed;

        Vector3 move = transform.right * xAxis + transform.forward * zAxis;

        PlayerController.Move(move * moveSpeed * Time.deltaTime);

        //transform.Translate(xAxis, yAxis, 0f);

        velocity.y += Gravity * Time.deltaTime;
        PlayerController.Move(velocity * Time.deltaTime);
       

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * Gravity);
        }
    }
}
