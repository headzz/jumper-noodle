using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float movement = 0f;
    Rigidbody2D rb;
    Camera cam;
    float screenLeftPosition;
    float screenRightPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        screenLeftPosition = cam.ScreenToWorldPoint(new Vector3(0, 0, transform.position.z)).x;
        screenRightPosition = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, transform.position.z)).x;
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal") * moveSpeed;
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;

        bool hasMovementToTheLeft = movement < 0;
        bool hasMovementToTheRight = movement > 0;

        bool isMovingToLeftEdgeOfScreen = transform.position.x < screenLeftPosition && hasMovementToTheLeft;
        bool isMovingToRightEdgeOfScreen = transform.position.x > screenRightPosition && hasMovementToTheRight;

        if (isMovingToLeftEdgeOfScreen || isMovingToRightEdgeOfScreen)
        {
            Vector3 playerXposition = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
            transform.position = playerXposition;
        }
    }
}
