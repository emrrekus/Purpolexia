using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinterMovement : MonoBehaviour
{
    public CharacterController controller;
    AudioSource source;
    public float speed = 3f;
    public float runSpeed = 7f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float jumpHeight = 2f;
    public float timeBetweenSteps = 0.6f;

    public AudioClip[] defaultSound;
    public AudioClip[] grassSound;
    public AudioClip[] snowSound;
    int soundControl;
    float timer;

    Vector3 velocity;
    bool isGrounded;
    bool isMove;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        source = GetComponent<AudioSource>();

    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        switch (hit.transform.tag)
        {
            case "Snow": soundControl = 0; break;
        }
    }

    void Update()
    {
        #region Move
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
       
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        #endregion

        #region Footsteps
        isMove = (x != 0 || z != 0) ? true : false;
        if (isMove && isGrounded)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                switch (soundControl)
                {
                    case 0: source.clip = snowSound[UnityEngine.Random.Range(0, snowSound.Length)]; break;
                }


                timer = timeBetweenSteps;
                source.pitch = UnityEngine.Random.Range(0.85f, 1.15f);
                source.Play();
            }
        }
        else
        {
            timer = timeBetweenSteps;
        }
        #endregion

        #region Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        #endregion

        #region Run
        if (Input.GetKey(KeyCode.LeftShift) )
        {
            controller.Move(move * runSpeed * Time.deltaTime);
            timeBetweenSteps = 0.35f;
        }
        if (!Input.GetKey(KeyCode.LeftShift) )
        {
            controller.Move(move * speed * Time.deltaTime);
            timeBetweenSteps = 0.6f;
        }

        #endregion

    }
}
