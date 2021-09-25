using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public bool shellPickUp;
    public Transform shellHover;
    public Transform currentShell;
    public BoxCollider2D Collider;
    public BoxCollider2D frictionlessCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            if (Input.GetKeyDown(KeyCode.Space))
            {
            if (shellPickUp && currentShell == null)
            {
                shellHover.SetParent(transform);
                shellHover.transform.position = transform.position + new Vector3(0, 1, 0);
                currentShell = shellHover;
                Collider.size = new Vector2(1,1.5f);
                Collider.offset = new Vector2(0,0.3f);
                frictionlessCollider.size = new Vector2(1.3f,1.5f);
                frictionlessCollider.offset = new Vector2(0, 0.3f);
                shellHover = null;

            }
            else {
                transform.GetChild(0).SetParent(null);
                currentShell = null;
                Collider.size = new Vector2(1, 0.7f);
                Collider.offset = new Vector2(0, -0.1f);
                frictionlessCollider.size = new Vector2(1.3f, 0.75f);
                frictionlessCollider.offset = new Vector2(0, -0.075f);

            }
            }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "shell")
        {
            shellPickUp = true;
            shellHover = collision.transform;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "shell")
        {
            shellPickUp = false;
        }
    }
}
