using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 7.0f;
    public float raycastDistance = 1f;
    public LayerMask interactableLayer;
    public KeyCode interactKey = KeyCode.E;
    private TextMeshProUGUI copText;
    private TextMeshProUGUI lawyerText;
    private TextMeshProUGUI employeeaText;
    private TextMeshProUGUI protestorText;
    private TextMeshProUGUI journalistText;
    // Start is called before the first frame update
    void Start()
    {
        copText = GameObject.Find("Cop Text").GetComponent<TextMeshProUGUI>();
        copText.gameObject.SetActive(false);

        lawyerText = GameObject.Find("Lawyer Text").GetComponent<TextMeshProUGUI>();
        lawyerText.gameObject.SetActive(false);

        employeeaText = GameObject.Find("Employee A Text").GetComponent<TextMeshProUGUI>();
        employeeaText.gameObject.SetActive(false);

        journalistText = GameObject.Find("Journalist Text").GetComponent<TextMeshProUGUI>();
        journalistText.gameObject.SetActive(false);

        protestorText = GameObject.Find("Protestor Text").GetComponent<TextMeshProUGUI>();
        protestorText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
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
            if (hit.collider != null && hit.collider.CompareTag("Protestor"))
            {
                // protestorText.text = "I'm Protesting";
                protestorText.gameObject.SetActive(true);
            }
            else if (protestorText.gameObject.activeSelf)
            {
                protestorText.gameObject.SetActive(false);
            }
            if (hit.collider != null && hit.collider.CompareTag("Cop"))
            {
                // copText.text = "I'm a cop bro";
                copText.gameObject.SetActive(true);
            }
            else if (copText.gameObject.activeSelf)
            {
                copText.gameObject.SetActive(false);
            }
            if (hit.collider != null && hit.collider.CompareTag("Lawyer"))
            {
                // lawyerText.text = "Better call Paul!";
                lawyerText.gameObject.SetActive(true);
            }
            else if (lawyerText.gameObject.activeSelf)
            {
                lawyerText.gameObject.SetActive(false);
            }
            if (hit.collider != null && hit.collider.CompareTag("Employee A"))
            {
                // employeeaText.text = "No I'm not a cupcake";
                employeeaText.gameObject.SetActive(true);
            }
            else if (employeeaText.gameObject.activeSelf)
            {
                employeeaText.gameObject.SetActive(false);
            }
            if (hit.collider != null && hit.collider.CompareTag("Journalist"))
            {
                // journalistText.text = "I've got some damming news to tell yah...";
                journalistText.gameObject.SetActive(true);
            }
            else if (journalistText.gameObject.activeSelf)
            {
                journalistText.gameObject.SetActive(false);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
        }
    }
}
