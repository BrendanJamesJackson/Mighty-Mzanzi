using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax_controller : MonoBehaviour
{

    public float speed_background;
    public float speed_transitional;
    public float speed_midground;
    public float speed_road;
    public float speed_barrier;

    public GameObject midground;
    public GameObject transitional;
    public GameObject background;
    public GameObject road;
    public GameObject barrier;

    public GameObject next_background;
    public GameObject next_transitional;
    public GameObject next_midground;
    public GameObject next_road;
    public GameObject next_barrier;

    public game_manager gm_script;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        midground.gameObject.transform.Translate(Vector3.left * speed_midground * Time.deltaTime * gm_script.global_world_speed);
        next_midground.gameObject.transform.Translate(Vector3.left * speed_midground * Time.deltaTime * gm_script.global_world_speed);

        transitional.gameObject.transform.Translate(Vector3.left * speed_transitional * Time.deltaTime * gm_script.global_world_speed);
        next_transitional.gameObject.transform.Translate(Vector3.left * speed_transitional * Time.deltaTime * gm_script.global_world_speed);

        background.gameObject.transform.Translate(Vector3.left * speed_background * Time.deltaTime * gm_script.global_world_speed);
        next_background.gameObject.transform.Translate(Vector3.left * speed_background * Time.deltaTime * gm_script.global_world_speed);

        road.gameObject.transform.Translate(Vector3.left * speed_road * Time.deltaTime * gm_script.global_world_speed);
        next_road.gameObject.transform.Translate(Vector3.left * speed_road * Time.deltaTime * gm_script.global_world_speed);

        barrier.gameObject.transform.Translate(Vector3.left * speed_barrier * Time.deltaTime * gm_script.global_world_speed);
        next_barrier.gameObject.transform.Translate(Vector3.left * speed_barrier * Time.deltaTime * gm_script.global_world_speed);

        // Debug.Log("Parallax Move");

        if (midground.transform.position.x <= -116.0f)
        {
            GameObject temp_midground = midground;
            midground = next_midground;
            next_midground = temp_midground;
            next_midground.transform.position = new Vector2(midground.transform.position.x + 112.5952f, next_midground.transform.position.y);
        }

        if (transitional.transform.position.x <= -48.7f)
        {
            GameObject temp_transitional = transitional;
            transitional = next_transitional;
            next_transitional = temp_transitional;
            next_transitional.transform.position = new Vector2(transitional.transform.position.x + 48.7f, next_transitional.transform.position.y);
        }

        if (background.transform.position.x <= -48.7f)
        {
            GameObject temp_background = background;
            background = next_background;
            next_background = temp_background;
            next_background.transform.position = new Vector2(background.transform.position.x + 48.7f, next_background.transform.position.y);
        }

        if (road.transform.position.x <= -20f)
        {
            GameObject temp_road = road;
            road = next_road;
            next_road = temp_road;
            next_road.transform.position = new Vector2(road.transform.position.x + 19.2f, next_road.transform.position.y);
        }

        if (barrier.tag == "barrier" && barrier.transform.position.x <= -72f)
        {
            GameObject temp_barrier = barrier;
            barrier = next_barrier;
            next_barrier = temp_barrier;
            next_barrier.transform.position = new Vector2(barrier.transform.position.x + 27.02f, next_barrier.transform.position.y);
        }
        
        if (barrier.tag == "metal barrier" && barrier.transform.position.x <= -25f)
        {
            GameObject temp_barrier = barrier;
            barrier = next_barrier;
            next_barrier = temp_barrier;
            next_barrier.transform.position = new Vector2(barrier.transform.position.x + 70.82f, next_barrier.transform.position.y);
        }

    }
}
