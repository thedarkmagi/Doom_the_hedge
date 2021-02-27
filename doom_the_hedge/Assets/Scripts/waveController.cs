using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveController : MonoBehaviour
{
    public List<GameObject> Waves;
    public int waveIndex;
    public bool wavesComplete;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Waves.Count; i++)
        {
            if(i!=0)
            {
                Waves[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!wavesComplete)
        {
            checkWaveOver();
        }
    }
    
    void checkWaveOver()
    {
        
        if (Waves[waveIndex].transform.childCount <= 0)
        {
            // we do not have any things left 
            // next wave
            waveIndex++;
            if(waveIndex< Waves.Count)
            {
                Waves[waveIndex].SetActive(true);
            }
            else
            {
                wavesComplete = true;
            }
        }
    }
}
