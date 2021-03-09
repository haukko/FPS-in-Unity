using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{

    public CharacterController PlayerController;

    
    public float moveSpeed = 4f;

    public float Gravity = -9.81f;

    public float jumpHeight = 5f;

    public Transform GroundCheck;

    public float groundDistance = 0.2f

    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        PlayerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal") * moveSpeed;
        float zAxis = Input.GetAxis("Vertical") * moveSpeed;

        Vector3 move = transform.right * xAxis + transform.forward * zAxis;

        PlayerController.Move(move * moveSpeed * Time.deltaTime);

        //transform.Translate(xAxis, yAxis, 0f);
    }
}
