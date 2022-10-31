using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_shoot : MonoBehaviour
{
    public float shootRate = 3f;
    public GameObject bullet;

    private Transform bulletSP;
    
    // Start is called before the first frame update
    void Start()
    {
        bulletSP = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
