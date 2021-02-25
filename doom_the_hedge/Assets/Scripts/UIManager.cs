using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public GameObject PC;
    public Sprite[] portraitsSprites;
    public GameObject[] portraitsGO;
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


    }
}
