using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup_movement : MonoBehaviour
{
    public float speed = 6f;

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

        if (gameObject.transform.position.x <= -9.55)
        {
            Destroy(gameObject);
        }
    }
}
