using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class environment_movement : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (gameObject.transform.position.x <= -15)
        {
            Destroy(gameObject);
        }
    }
}
