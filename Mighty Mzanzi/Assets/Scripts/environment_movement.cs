using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class environment_movement : MonoBehaviour
{
    public float speed;

    private game_manager gm_script;

    // Start is called before the first frame update
    void Start()
    {
        gm_script = (game_manager)FindObjectOfType(typeof(game_manager));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime * gm_script.global_world_speed);

        //Debug.Log("Enviro Move");

        if (gameObject.transform.position.x <= -15)
        {
            Destroy(gameObject);
        }
    }
}
