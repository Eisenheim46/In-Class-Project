using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 500;

    private Rigidbody2D rigidbody;
    private float horizontalInput, verticalInput;

    private float maxHitPoints = 50;
    private float currentHitPoints;

    public float CurrentHitPoints
    {
        get
        {
            return currentHitPoints;
        }

    }

	void Awake ()
	{
        rigidbody = GetComponent<Rigidbody2D>();

        
	}

    private void Start()
    {
        currentHitPoints = maxHitPoints;
    }

    // Update is called once per frame
    void Update ()
	{
        GetInput();
        HandleMovement();
	}

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void HandleMovement()
    {
        rigidbody.velocity = new Vector2(horizontalInput, verticalInput) * speed * Time.deltaTime;
    }

    public void TakeDamage( float damage)
    {
        currentHitPoints -= damage;
    }
}
