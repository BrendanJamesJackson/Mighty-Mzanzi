using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input_manager : MonoBehaviour
{

    public player_movement pm_script;
    public player_shoot ps_script;

    private bool Left_Input_Pressed;
    private bool Right_Input_Pressed;


    // Start is called before the first frame update
    void Start()
    {
        Left_Input_Pressed = false;
        Right_Input_Pressed = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Left_Input_Pressed)
        {
            pm_script.Jump();
        }
        if (Right_Input_Pressed)
        {
            ps_script.Shoot();
        }
    }

    public void LeftDown()
    {
        Left_Input_Pressed = true;
        Debug.Log("Down");
    }

    public void LeftUp()
    {
        Left_Input_Pressed = false;
        Debug.Log("Up");

    }

    public void RightDown()
    {
        Right_Input_Pressed = true;
    }

    public void RightUp()
    {
        Right_Input_Pressed = false;
    }
}
