using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using MarksAssets.ScreenOrientationWebGL;
using ScreenOrientation = MarksAssets.ScreenOrientationWebGL.ScreenOrientationWebGL.ScreenOrientation;

public class orientation : MonoBehaviour
{
   /* private void Start()
    {
        SetOrientation();
        Debug.Log("orientation");
    }

    [DllImport("__Internal")]
    public static extern void SetOrientation();*/

    public GameObject rotate_img;
    public AudioSource music;
    
    
    private bool portrait = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.deviceOrientation == DeviceOrientation.Portrait || Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown)
        {
            Time.timeScale = 0;
            rotate_img.SetActive(true);
            portrait = true;
        }
        else if ((Input.deviceOrientation != DeviceOrientation.Portrait || Input.deviceOrientation != DeviceOrientation.PortraitUpsideDown) && portrait)
        {
            rotate_img.SetActive(false);
            Time.timeScale = 1;
            portrait = false;
        }*/
    }

    public void OrientCheck(int orient)
    {
        //int orient;
        ScreenOrientation orientation = (ScreenOrientation)orient;

        if (orientation == ScreenOrientation.Portrait || orientation == ScreenOrientation.PortraitUpsideDown)
        {
            Time.timeScale = 0;
            rotate_img.SetActive(true);
            portrait = true;
            music.Stop();
        }
        else if ((orientation == ScreenOrientation.LandscapeLeft || orientation == ScreenOrientation.LandscapeRight) && portrait)
        {
            rotate_img.SetActive(false);
            Time.timeScale = 1;
            portrait = false;
            music.Play();
        }
        
    }
}
