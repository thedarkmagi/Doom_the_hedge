using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTrigger : MonoBehaviour
{
    public GameObject WaveGO, RockBLOCK;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WaveGO.GetComponent<waveController>().Activate1stwave();
            RockBLOCK.GetComponent<Animator>().SetBool("PlayerIN", true);
        }
    }
}
