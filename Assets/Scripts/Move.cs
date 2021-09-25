using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed;
    public float jumpAmount;
    public bool grounded;

    public Camera camera1;
    public Camera camera2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, transform.GetComponent<Rigidbody2D>().velocity.y);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, transform.GetComponent<Rigidbody2D>().velocity.y);

        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (grounded)
            {
                transform.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);

            }
            else if (transform.GetChild(0) != null && !grounded)
            {
                transform.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
                transform.GetChild(0).GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                transform.GetChild(0).GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -5.0f);
                transform.GetChild(0).GetComponent<Rigidbody2D>().simulated = true;
                transform.GetChild(0).position -= new Vector3(0, 2f,0);
                transform.GetChild(0).SetParent(null);
                GetComponent<Shell>().currentShell = null;
                transform.GetComponent<BoxCollider2D>().size = new Vector2(1, 1);
                transform.GetComponent<BoxCollider2D>().offset = Vector2.zero;
            }

        
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Level 2 Detector")
        {
            camera2.enabled = true;
            camera1.enabled = false;

        }
        if (collision.transform.name == "Level 1 Detector")
        {
            camera1.enabled = true;
            camera2.enabled = false;

        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "ground" || collision.transform.tag == "shell")
        {
            grounded = true;

        }
        else {

            grounded = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "ground" || collision.transform.tag == "shell")
        {
            grounded = false;

        }
    }
}
