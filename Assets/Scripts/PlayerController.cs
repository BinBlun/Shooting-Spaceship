using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;
    [SerializeField] float speed;
    [SerializeField] float xRange = 2.0f;
    [SerializeField] float yRange = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        if (transform.position.x >= xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y);
        }
        if (transform.position.x <= -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y);
        }
        if (transform.position.y >= yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange);
        }
        if (transform.position.y <= -yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * speed * Time.deltaTime * verticalInput);
    }
}
