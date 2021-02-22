using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpPool : MonoBehaviour
{
    public float HP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(float dmg)
    {
        HP -= dmg;
    }
}
