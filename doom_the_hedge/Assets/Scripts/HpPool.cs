using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpPool : MonoBehaviour
{
    public float HP;
    public float timer;
        private float startT;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.name == "player"&& GetComponentInChildren<Canvas>().enabled)
        {
           
            if (Time.time>startT+timer)
            {
                GetComponentInChildren<Canvas>().enabled = false;
            }
        }
    }

    public void takeDamage(float dmg)
    {
        HP -= dmg;
        if (this.name=="player")
        {   if(!GetComponentInChildren<Canvas>().enabled)
            startT = Time.time;

            GetComponentInChildren<Canvas>().enabled = true;
            
        }
    }
}
