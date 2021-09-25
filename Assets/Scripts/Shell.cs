using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public bool shellPickUp;
    public Transform shellHover;
    public Transform currentShell;
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
                transform.GetComponent<BoxCollider2D>().size = new Vector2(1,2);
                transform.GetComponent<BoxCollider2D>().offset = new Vector2(0,0.5f);
                shellHover = null;

            }
            else {
                transform.GetChild(0).SetParent(null);
                currentShell = null;
                transform.GetComponent<BoxCollider2D>().size = new Vector2(1, 1);
                transform.GetComponent<BoxCollider2D>().offset = Vector2.zero;

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
