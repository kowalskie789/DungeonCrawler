using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Atack
{
    // Start is called before the first frame update
    [SerializeField] private float playerMovementSpeed = 10f;
    private Rigidbody2D rb;

    private Vector2 movementDirection;

    private Animator animator;

    public GameObject ItemPlace1;
    public GameObject ItemPlace2;

    public Collider2D AtackColider;
  
    void Start()
    {
        
        SetHealth(100);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(Health);

        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (movementDirection != Vector2.zero)
        {
            animator.SetBool("IsWalking", true);
            animator.SetFloat("XInput", movementDirection.x);
            animator.SetFloat("YInput", movementDirection.y);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            
            animator.SetBool("Attack", true);
           if (InRange ==true)
            {
                
                enemy.gameObject.GetComponent<Enemy>().ApplyDamage(5);
                ApplyDamage(2);
            }

        }
        else 
        {
            animator.SetBool("Attack", false);
           
        }

    }
    void FixedUpdate()
    {
        rb.velocity = movementDirection * playerMovementSpeed * Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sword")
        {
            //Add text to interface "press e to pick up// 
            Destroy(collision.gameObject);
            ItemPlace1.SetActive(true);
        }
        if (collision.gameObject.tag == "Key")
        {
            Destroy(collision.gameObject);
            ItemPlace2.SetActive(true);
        }
        

        
    }
    

}