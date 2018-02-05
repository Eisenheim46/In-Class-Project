using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 500;

    [SerializeField]
    private float damageCoolDownInSeconds = 1f;

    private Rigidbody2D rigidbody;
    private float horizontalInput, verticalInput;

    private float maxHitPoints = 50;
    
    private float currentHitPoints_UseProperty;

    SpriteRenderer spriteRenderer;

    private bool isInvulnerable_UseProperty = false;
    private bool IsInvulnerbale
    {
        get
        {
            return isInvulnerable_UseProperty;
        }

        set
        {
            isInvulnerable_UseProperty = value;

            if (isInvulnerable_UseProperty)
                StartCoroutine(BlinkWhileInvulnerable());

        }
    }

    public float CurrentHitPoints
    {
        get
        {
            return currentHitPoints_UseProperty;
        }

        private set
        {
            currentHitPoints_UseProperty = value;

            if (currentHitPoints_UseProperty < 0)
                currentHitPoints_UseProperty = 0;

            if (currentHitPoints_UseProperty > maxHitPoints)
                currentHitPoints_UseProperty = maxHitPoints;
        }

    }

	void Awake ()
	{
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}

    private void Start()
    {
        
        CurrentHitPoints = maxHitPoints;
        
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

        if (!IsInvulnerbale)
        {
            CurrentHitPoints -= damage;
            StartCoroutine(BlinkWhileInvulnerable());
            StartCoroutine(DamageCoolDown());
            
        }
        
    }

    private IEnumerator DamageCoolDown()
    {
        IsInvulnerbale = true;

        yield return new WaitForSeconds(damageCoolDownInSeconds);

        IsInvulnerbale = false;
    }

    private IEnumerator BlinkWhileInvulnerable()
    {
        Color defaultColor = spriteRenderer.color;
        Color invulnerableColor = new Color(1, 1, 1, 0);

        float blinkInterval = 0.3f;

        while (IsInvulnerbale)
        {
            spriteRenderer.color = invulnerableColor;
            yield return new WaitForSeconds(blinkInterval);

            spriteRenderer.color = defaultColor;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
