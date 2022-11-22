using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orientation : MonoBehaviour
{
    public GameObject rotate_img;

    private bool portrait = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.deviceOrientation == DeviceOrientation.Portrait || Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown)
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
        }
    }
}
