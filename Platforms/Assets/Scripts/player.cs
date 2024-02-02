using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] float velocidad = 5;
    [SerializeField] float velocidadSalto = 20;
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded.isGrounded && Input.GetButtonDown("Jump"))
        {
            IsGrounded.isGrounded = false;
            animator.SetTrigger("CanJump");
            Vector2 fuerzaSalto = new Vector2(0, velocidadSalto);
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(fuerzaSalto, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0) 
            spriteRenderer.flipX = false;
        else if(horizontal < 0)
            spriteRenderer.flipX = true;
        
        animator.SetFloat("speed", Mathf.Abs(horizontal));


        transform.Translate(horizontal * velocidad * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
