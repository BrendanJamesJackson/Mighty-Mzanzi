using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_controller : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void enemyDie()
    {
        //particle effect
        //sound
        Destroy(gameObject);
    }
}
