using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DKinematicMovement : MonoBehaviour
{
    [SerializeField, Range(0, 100f)]
    float maximumSpeed = 10f;
    [SerializeField, Range(0, 500f)]
    float maxAcceleration = 10f;

    Vector3 velocity, desiredVelocity;
    Rigidbody2D body;
    
    private void Awake() {
        body = GetComponent<Rigidbody2D>();    
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerInput;
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");
        // Clamp only scales down if the magnitude is greater than 1
        playerInput = Vector2.ClampMagnitude(playerInput, 1f);

        desiredVelocity = new Vector3(playerInput.x, playerInput.y, 0.0f) * maximumSpeed;
    }

    private void FixedUpdate() {
        UpdateState();

        float maxSpeedChange = maxAcceleration * Time.deltaTime;

        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        velocity.y = Mathf.MoveTowards(velocity.y, desiredVelocity.y, maxSpeedChange);

        body.velocity = velocity;
    }

    void UpdateState () {
		velocity = body.velocity;
	}

    private void OnCollisionEnter2D(Collision2D other) {
        EvaluateCollision(other);
    }
    private void OnCollisionStay2D(Collision2D other) {
        EvaluateCollision(other);  
    }

    private void EvaluateCollision(Collision2D collision) {
        for(int i = 0; i < collision.contactCount; i++) {
            Vector3 normal = collision.GetContact(i).normal;
            Debug.Log(normal);
            // onGround |= normal.y >= 0.9f;
        }
    }
}
