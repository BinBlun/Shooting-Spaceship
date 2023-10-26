using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] float speed;
    private bool hit;
    private float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        lifeTime += Time.deltaTime;
        if(lifeTime > 1)
        {
            gameObject.SetActive(false);
        }
    }

    public void SetActivate()
    {
        lifeTime = 0;

        gameObject.SetActive(true);
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
