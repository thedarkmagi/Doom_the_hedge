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
    public GameObject[] desciptionGO;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateStack();
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
       
        for (i = 0; i < 3; i++)
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
}
