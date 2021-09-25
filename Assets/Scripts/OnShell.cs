using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnShell : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        
        if (transform.parent == null)
        {
            transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            transform.GetComponent<Rigidbody2D>().simulated = true;


        }
        else
        {

            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.parent.GetComponent<Rigidbody2D>().velocity.x, transform.GetComponent<Rigidbody2D>().velocity.y);
            transform.GetComponent<Rigidbody2D>().simulated = false;
            transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

        }


    }
}
