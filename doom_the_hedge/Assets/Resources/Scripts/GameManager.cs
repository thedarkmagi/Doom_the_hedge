using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class GameManager : MonoBehaviour
{
    public int totKarma;
    public GameObject flowchrt;
    private bool pause=false;

    void Awake()
    {     

        if (GameObject.FindGameObjectsWithTag("GM").Length>1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   


    public void updateKarma()
    {
        if (flowchrt == null)
        {
            
            if (GameObject.Find("A_interaction") != null)
                flowchrt = GameObject.Find("A_interaction");
            else if (GameObject.Find("Menu") != null)
                totKarma = 0;

        }
        else
        totKarma += flowchrt.GetComponent<Flowchart>().GetIntegerVariable("karma");
    }   


}
