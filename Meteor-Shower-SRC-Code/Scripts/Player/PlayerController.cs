using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    Animator anim;
    public float moveSpeed = 5;
    public Vector3 Jump;
    public float jumpForce = 2.5f;
    public ScoreController sc;

    public bool isGrounded;
    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        sc = GetComponent<ScoreController>();
        rb = GetComponent<Rigidbody>();
        Jump = new Vector3(0f, 2f, 0f);
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
        else {
            isGrounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        anim.SetBool("IsMoving", false);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);


        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), 0.2f);
            anim.SetBool("IsMoving", true);
        }



        if (Input.GetButtonDown("Jump") && isGrounded) {
            anim.SetTrigger("Jumping");
            isGrounded = false;
            rb.AddForce(Jump * jumpForce, ForceMode.Impulse);
           
        }


    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.normal.y <= 0.6) {
            isGrounded = false;
        }
    }

   
    public void ToggleDeathMenu() {
        SceneManager.LoadScene("EndMenu", LoadSceneMode.Single);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Meteor") {
            //Game Over
           
            ToggleDeathMenu();
            gameObject.SetActive(false);

        }

        if (collision.gameObject.tag == "Finish") {

            gameObject.SetActive(false);
            ToggleDeathMenu();
        }
    }


}
