using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class OpenGate : MonoBehaviour
{
    public GameObject castle;
    public Flowchart flowchart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeInHierarchy)
        {
            castle.GetComponent<Animator>().SetBool("open", true);
            flowchart.ExecuteBlock("Shake");
        }
    }
}
