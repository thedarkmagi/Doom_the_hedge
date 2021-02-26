using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
//this script allows flow flowchart to pass a variable's value
public class Flowchart_var : MonoBehaviour
{

    public GameObject PrevFlowchart;
    public string[] inheritVar;
   // public GameObject NextFlowchart;
    int karmaValue;
    // Start is called before the first frame update
    void Start()
    {
        foreach(string var in inheritVar){

            GetComponent<Flowchart>().SetIntegerVariable(var, PrevFlowchart.GetComponent<Flowchart>().GetIntegerVariable(var) );
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
