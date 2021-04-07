using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
	[SerializeField]
	public float accelerationPower = 15f;
	[SerializeField]
	float steeringPower = 0.5f;
	float steeringAmount, speed, direction;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

    void Update()
    {
        steeringAmount = - Input.GetAxisRaw("Horizontal");
        speed = Input.GetAxisRaw("Vertical") * accelerationPower;

    }
	
	// Update is called once per frame
	void FixedUpdate () {

		direction = Mathf.Sign(Vector2.Dot (rb.velocity, rb.GetRelativeVector(Vector2.up)));
		rb.rotation += steeringAmount * steeringPower * 1 * 1;

		rb.AddRelativeForce (Vector2.up * speed);
        rb.AddRelativeForce (Vector2.up * 50);

		rb.AddRelativeForce ( - Vector2.right * rb.velocity.magnitude * steeringAmount / 2.0f);
	}
}