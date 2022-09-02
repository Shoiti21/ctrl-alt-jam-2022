using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform footTransform;
    [SerializeField] private ParticleSystem dustParticle;
    [SerializeField] private ParticleSystem steamParticle;

    private Rigidbody2D rb;
    private Animator animator;
    private float speed;
    [SerializeField][Range(0, 0.1f)] private float speedDecrease;

    private bool availableJumping;
    private string facingDirection;

    private float bufferTime;
    private float coyoteTimeCounter;
    private float jumpBufferCounter;
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.speed = 3f;
        this.bufferTime = 0.2f;
        this.facingDirection = "Left";
        this.availableJumping = true;
    }
    void Update()
    {
        Move();
        Jump();
        Decrease();
        Died();
        Gravity();
        Animation();
        Particle();
    }
    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float velocityX = this.rb.velocity.x;

        if (horizontal != 0)
        {
            velocityX += horizontal * this.speed * 0.5f;

            if (this.rb.velocity.x <= -this.speed || this.rb.velocity.x >= this.speed)
            {
                velocityX = horizontal * this.speed;
            }

            this.rb.velocity = new Vector2(velocityX, this.rb.velocity.y);

            // Virar horizontalmente
            this.transform.localScale = new Vector3(-horizontal * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
    }
    private void Jump()
    {
        // Gerenciar o tempo para o salto Coyote
        if (Physics2D.OverlapCircle(this.footTransform.position, 0.05f, this.groundLayer))
        {
            this.coyoteTimeCounter = this.bufferTime;
        }
        else
        {
            this.coyoteTimeCounter = this.coyoteTimeCounter < 0f ? 0f : this.coyoteTimeCounter -= Time.deltaTime;
        }

        // Gerenciar o tempo para o Jump Buffer
        if (Input.GetButtonDown("Jump"))
        {
            this.jumpBufferCounter = this.bufferTime;
        }
        else
        {
            this.jumpBufferCounter = this.jumpBufferCounter < 0f ? 0f : this.jumpBufferCounter -= Time.deltaTime;
        }

        if (this.coyoteTimeCounter > 0f && this.jumpBufferCounter > 0f && this.availableJumping)
        {
            this.rb.velocity = new Vector2(this.rb.velocity.x, 7f);
            StartCoroutine(JumpCooldown());
        }

        if (Input.GetButtonUp("Jump") && this.rb.velocity.y > 0f)
        {
            this.rb.velocity = new Vector2(this.rb.velocity.x, this.rb.velocity.y * 0.5f); // Height jump
        }
    }
    private void Decrease()
    {
        if(this.speedDecrease > 0)
        {
            if (!this.steamParticle.isPlaying)
            {
                this.steamParticle.Play();
            }
            this.transform.localScale -= new Vector3((this.transform.localScale.x > 0f ? this.speedDecrease : -this.speedDecrease) * Time.deltaTime, this.speedDecrease * Time.deltaTime, this.transform.localScale.z);
        } else
        {
            if (this.steamParticle.isPlaying)
            {
                this.steamParticle.Stop();
            }
        }
    }
    private void Gravity()
    {
        this.rb.velocity += Vector2.up * Physics2D.gravity.y * 1f * Time.deltaTime;
    }
    private void Died()
    {
        if(this.transform.localScale.y <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
    private void Animation()
    {
        this.animator.SetBool("isWalking", Input.GetAxisRaw("Horizontal") != 0);
        this.animator.SetBool("isJumping", !Physics2D.OverlapCircle(this.footTransform.position, 0.05f, this.groundLayer));
    }
    private void Particle()
    {
        if(Mathf.Round(this.rb.velocity.y) == 0f)
        {
            if (this.rb.velocity.x < 0f)
            {
                if (this.facingDirection == "Right")
                {
                    this.facingDirection = "Left";
                    dustParticle.Play();
                }
            }
            else if (this.rb.velocity.x > 0f)
            {
                if (this.facingDirection == "Left")
                {
                    this.facingDirection = "Right";
                    dustParticle.Play();
                }
            }
        }
    }
    private IEnumerator JumpCooldown()
    {
        this.availableJumping = false;
        this.dustParticle.Play();
        yield return new WaitForSeconds(0.4f);
        this.availableJumping = true;
    }
}
