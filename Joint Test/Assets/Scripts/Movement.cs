using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            rb.velocity = Vector2.left * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            rb.velocity = Vector2.right * speed * Time.deltaTime;
    }
}
