using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;

    Vector2 velocity;
    [SerializeField]
    float speed;
    [SerializeField]
    float acceleration;
    [SerializeField]
    float slowDown;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        KeyBoardControl();
    }

    /// <summary>
    /// Karaktere x ekseninde hareket verildi ve scale ile yön kavramı ayarlandı.
    /// </summary>
    void KeyBoardControl()
    {
        float movementInput = Input.GetAxisRaw("Horizontal");
        Vector2 scale = transform.localScale;
        if (movementInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, movementInput * speed, acceleration * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = 0.3f;
        }
        else if (movementInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, movementInput * speed, acceleration * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = -0.3f;
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, slowDown * Time.deltaTime);
            animator.SetBool("Walk", false);
        }
        // Bu atama neden yapıldı?
        transform.localScale = scale;
        transform.Translate(velocity * Time.deltaTime);
    }

}
