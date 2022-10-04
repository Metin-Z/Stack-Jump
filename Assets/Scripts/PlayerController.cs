using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    public float jumpPower;
    bool IsGrounded = true;
    CanvasManager _canvas;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
        _canvas = FindObjectOfType<CanvasManager>();
    }
    void Update()
    {
        Jump();
    }
    public void Jump()
    {
        if (Input.GetMouseButtonDown(0) && IsGrounded == true)
        {
            rb.AddForce(transform.up * jumpPower);
            IsGrounded = false;
            anim.SetBool("IsGround", false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            IsGrounded = true;
            anim.SetBool("IsGround", true);
            collision.gameObject.GetComponent<BlockController>().enabled = false;
            collision.gameObject.GetComponent<ComboController>().enabled = false;
            _canvas.score++;
        }
        if (collision.gameObject.tag == "BaseBlock")
        {
            IsGrounded = true;
            anim.SetBool("IsGround", true);
            _canvas.score++;
        }
    }
}
