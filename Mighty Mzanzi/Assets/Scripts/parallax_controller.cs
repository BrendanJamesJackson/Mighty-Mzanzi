using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax_controller : MonoBehaviour
{

    public float speed_background;
    public float speed_transitional;
    public float speed_midground;
    public float speed_road;

    public GameObject midground;
    public GameObject transitional;
    public GameObject background;
    public GameObject road;

    public GameObject next_background;
    public GameObject next_transitional;
    public GameObject next_midground;
    public GameObject next_road;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        midground.gameObject.transform.Translate(Vector3.left * speed_midground * Time.deltaTime);
        next_midground.gameObject.transform.Translate(Vector3.left * speed_midground * Time.deltaTime);

        transitional.gameObject.transform.Translate(Vector3.left * speed_transitional * Time.deltaTime);
        next_transitional.gameObject.transform.Translate(Vector3.left * speed_transitional * Time.deltaTime);

        background.gameObject.transform.Translate(Vector3.left * speed_background * Time.deltaTime);
        next_background.gameObject.transform.Translate(Vector3.left * speed_background * Time.deltaTime);

        road.gameObject.transform.Translate(Vector3.left * speed_road * Time.deltaTime);
        next_road.gameObject.transform.Translate(Vector3.left * speed_road * Time.deltaTime);

        if (midground.transform.position.x <= -48.7f)
        {
            GameObject temp_midground = midground;
            midground = next_midground;
            next_midground = temp_midground;
            next_midground.transform.position = new Vector2(midground.transform.position.x + 48.7f, next_midground.transform.position.y);
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

    }
}
