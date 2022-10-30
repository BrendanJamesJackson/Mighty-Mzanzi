using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup_movement : MonoBehaviour
{
    public float speed = 6f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (gameObject.transform.position.x <= -9.55)
        {
            Destroy(gameObject);
        }
    }
}
