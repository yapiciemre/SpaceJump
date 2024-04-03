using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;

    Vector2 velocity;

    [SerializeField]
    float speed = default;

    [SerializeField]
    float acceleration = default;

    [SerializeField]
    float deceleration = default;

    [SerializeField]
    float jumpingForce = default;

    [SerializeField]
    int jumpingLimit = 3;

    int jumpingCount;

    Joystick joystick;

    JoystickButton joystickButton;

    bool jumping;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        joystick = FindObjectOfType<Joystick>();
        joystickButton = FindObjectOfType<JoystickButton>();
    }

    void Update()
    {
#if UNITY_EDITOR
        KeyboardControl();
#else
        JoystickControl();
#endif
    }

    void KeyboardControl()
    {
        float movementInput = Input.GetAxisRaw("Horizontal");
        Vector2 scale = transform.localScale;

        if (movementInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, movementInput * speed, acceleration * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = 0.7f;
        }
        else if (movementInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, movementInput * speed, acceleration * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = -0.7f;
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
            animator.SetBool("Walk", false);
        }

        transform.localScale = scale;
        transform.Translate(velocity * Time.deltaTime);

        if (Input.GetKeyDown("space"))
        {
            StartJumping();
        }

        if (Input.GetKeyUp("space"))
        {
            StopJumping();
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
            scale.x = 0.7f;
        }
        else if (movementInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, movementInput * speed, acceleration * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = -0.7f;
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
            animator.SetBool("Walk", false);
        }

        transform.localScale = scale;
        transform.Translate(velocity * Time.deltaTime);

        if (joystickButton.pressedButton == true && jumping == false)
        {
            jumping = true;
            StartJumping();
        }

        if (joystickButton.pressedButton == false && jumping == true)
        {
            jumping = false;
            StopJumping();
        }
    }

    void StartJumping()
    {
        if (jumpingCount < jumpingLimit)
        {
            FindObjectOfType<SoundEffectControl>().JumpingAudio();
            rb2d.AddForce(new Vector2(0, jumpingForce), ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
            FindObjectOfType<SliderControl>().SliderValue(jumpingLimit, jumpingCount);
        }
    }

    void StopJumping()
    {
        animator.SetBool("Jump", false);
        jumpingCount++;
        FindObjectOfType<SliderControl>().SliderValue(jumpingLimit, jumpingCount);
    }

    public void ResetJump()
    {
        jumpingCount = 0;
        FindObjectOfType<SliderControl>().SliderValue(jumpingLimit, jumpingCount);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "DeathPoint")
        {
            FindObjectOfType<GameControl>().GameOver();
        }
    }

    public void GameOver()
    {
        Destroy(gameObject);
    }
}
