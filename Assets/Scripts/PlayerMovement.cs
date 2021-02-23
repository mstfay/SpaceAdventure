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
    [SerializeField]
    float jumpPower;
    
    int numberOfJump;
    [SerializeField]
    int limitOfJump = 3;

    Joystick joystick;

    JoystickButton joystickButton;

    bool jumping;
    // Start is called before the first frame update
    void Start()
    {
        joystickButton = FindObjectOfType<JoystickButton>();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR

        KeyBoardControl();
#else

                JoystickControl();

#endif
       
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

        if (Input.GetKeyDown("space"))
        {
            StartJump();
        }

        if (Input.GetKeyDown("space"))
        {
            StopJump();
        }
    }

    void JoystickControl()
    {
        float movementInput = joystick.Horizontal;
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
        if (joystickButton.pressedButton == true && jumping == false)
        {
            jumping = true;
            StartJump();
        }
        if (joystickButton.pressedButton == false && jumping == true)
        {
            jumping = false;
            StopJump();
        }
    }
    void StartJump()
    {
        if (numberOfJump < limitOfJump)
        {
            rb2d.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
            FindObjectOfType<SliderControl>().SliderDeger(limitOfJump, numberOfJump);
        }        
    }
    
    void StopJump()
    {
        animator.SetBool("Jump", false);
        numberOfJump++;
        FindObjectOfType<SliderControl>().SliderDeger(limitOfJump, numberOfJump);
    }
    public void ResetJump()
    {
        numberOfJump = 0;
        FindObjectOfType<SliderControl>().SliderDeger(limitOfJump, numberOfJump);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathPoints")
        {
            FindObjectOfType<GameControl>().GameOver();
        }
    }

    public void EndGame()
    {
        Destroy(gameObject);
    }
}
