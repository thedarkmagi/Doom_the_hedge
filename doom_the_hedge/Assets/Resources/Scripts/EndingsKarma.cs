using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class EndingsKarma : MonoBehaviour
{

    public GameObject GM;
    public Flowchart flowchrt;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GM");

        flowchrt.GetComponent<Flowchart>().SetIntegerVariable("karma",GM.GetComponent<GameManager>().totKarma);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
