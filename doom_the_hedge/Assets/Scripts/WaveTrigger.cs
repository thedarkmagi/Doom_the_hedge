using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class WaveTrigger : MonoBehaviour
{
    public GameObject WaveGO, RockBLOCK;
    public Flowchart flowchart;
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
            flowchart.SetBooleanVariable("Trap", true);
            flowchart.ExecuteBlock("Shake");
        }

    }
}
