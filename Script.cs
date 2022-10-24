using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;

    [SerializeField] private Rigidbody2D Rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }
    private bool IsGrounded() {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    // Update is called once per frame
    void Update()
    {
        
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && IsGrounded()) {
            Debug.Log("down was pressed");
            Rb.velocity = new Vector2 (Rb.velocity.x, jumpingPower);
        }
        if (Input.GetButtonUp("Jump") && Rb.velocity.y > 0f) {
            Debug.Log("down was pressed");
            Rb.velocity = new Vector2 (Rb.velocity.x, Rb.velocity.y * 0.5f);
        }
    }
    private void FixedUpdate(){
        Rb.velocity = new Vector2(horizontal*speed, Rb.velocity.y);
    }
}
