using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    public GameObject PC;
    public Sprite[] portraitsSprites;
    public GameObject[] portraitsGO;
    public GameObject[] portraitsGOPAUSE;
    public string[] descriptionChr;
    public Slider[] healthBars;
    private int activebar=4;
    public TextMeshProUGUI healthtext;
    
    

    // Start is called before the first frame update
    void Start()
    {
        foreach(Slider health in healthBars)
        health.value = 5;
    }

    // Update is called once per frame
    void Update()
    {//if((Input.GetKeyDown(KeyCode.Q))|| (Input.GetKeyDown(KeyCode.E)))//updates only when a change in the stack happens
        updateStack();
        updateHealth();
    }


    void updateStack()
    {
        int i;
        switch (PC.GetComponent<Player>().tower._top.weaponIndexValue)
        {
            case 0:
                portraitsGO[2].GetComponent<Image>().sprite = portraitsSprites[0];

                break;

            case 1:
                portraitsGO[2].GetComponent<Image>().sprite = portraitsSprites[1];

                break;

            case 2:
                portraitsGO[2].GetComponent<Image>().sprite = portraitsSprites[2];

                break;

            default:
                break;
        }//update top position of the stack

        switch (PC.GetComponent<Player>().tower._middle.weaponIndexValue)
        {
            case 0:
                portraitsGO[0].GetComponent<Image>().sprite = portraitsSprites[0];

                break;

            case 1:
                portraitsGO[0].GetComponent<Image>().sprite = portraitsSprites[1];

                break;

            case 2:
                portraitsGO[0].GetComponent<Image>().sprite = portraitsSprites[2];

                break;

            default:
                break;
        }//update middle position of the stack

        switch (PC.GetComponent<Player>().tower._bottom.weaponIndexValue)
        {
            case 0:
                portraitsGO[1].GetComponent<Image>().sprite = portraitsSprites[0];

                break;

            case 1:
                portraitsGO[1].GetComponent<Image>().sprite = portraitsSprites[1];

                break;

            case 2:
                portraitsGO[1].GetComponent<Image>().sprite = portraitsSprites[2];

                break;

            default:
                break;
        }//update bottom position of the stack
       
        for (i = 0; i < 3; i++)//updates the pause menu
        {
            portraitsGOPAUSE[i].GetComponent<Image>().sprite = portraitsGO[i].GetComponent<Image>().sprite;
            if(portraitsGOPAUSE[i].GetComponent<Image>().sprite.name=="bunui")
            portraitsGOPAUSE[i].GetComponentInChildren<TextMeshProUGUI>().text = descriptionChr[1];
            if (portraitsGOPAUSE[i].GetComponent<Image>().sprite.name == "skunkui")
                portraitsGOPAUSE[i].GetComponentInChildren<TextMeshProUGUI>().text = descriptionChr[2];
            if (portraitsGOPAUSE[i].GetComponent<Image>().sprite.name == "hedgehogui")
                portraitsGOPAUSE[i].GetComponentInChildren<TextMeshProUGUI>().text = descriptionChr[0];
        }
        
    }


    void updateHealth()
    {
        int temp=0,hptemp;
        hptemp = (int)PC.GetComponent<HpPool>().HP + 1;

        if (hptemp >= 80)
        {
            temp = hptemp - 79;
            activebar = 4;
        }
        else if(hptemp >= 60)
        {
            temp = hptemp - 59;
            activebar = 3;
        }
        else if (hptemp >= 40)
        {
            temp = hptemp - 39;
            activebar = 2;
        }
        else if (hptemp >= 20)
        {
            temp = hptemp - 19;
            activebar = 1;
        }
        else if (hptemp > 0)
        {
            temp = hptemp;
            activebar = 0;
        }
        healthBars[activebar].value = (int) temp / 4;

        healthtext.text = (""+ (hptemp-1));

    }
}
