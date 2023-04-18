using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 7.0f;
    public float raycastDistance = 1f;
    public LayerMask interactableLayer;
    public KeyCode interactKey = KeyCode.E;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKey(KeyCode.A))
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
        if(Input.GetKey(KeyCode.D))
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
        if (Input.GetKeyDown(interactKey))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, raycastDistance, interactableLayer);
            if (hit.collider != null && hit.collider.CompareTag("Door"))
            {
                SceneManager.LoadScene("Gather Info");
                // Perform the action or scene change here
                Debug.Log("Interacted with " + hit.collider.name);
            }
            if (hit.collider != null && hit.collider.CompareTag("Computer"))
            {
                SceneManager.LoadScene("Computer Screen");
                // Perform the action or scene change here
                Debug.Log("Interacted with " + hit.collider.name);
            }
        }
    }  


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            if(Input.GetKey(KeyCode.A))
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            if(Input.GetKey(KeyCode.D))
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
        }
    }    
}
