using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetOrientation
{
    [System.Runtime.InteropServices.DllImport("__Internal")]
    public static extern string CheckOrientation();

    public static bool OrientStatus()
    {
        if (CheckOrientation() == "true")
        {
            Debug.Log("Landscape Orientation");
            return true;
        }
        else
        {
            Debug.Log("Portrait Orientation");
            return false;
        }
    }

}
