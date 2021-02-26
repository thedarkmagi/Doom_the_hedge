using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//this script manages all the interactions in the item menu
public class swipe : MonoBehaviour
{

    [SerializeField] private GameObject items_description;
    public Color[] colors;
    public GameObject scrollbar;
    private float scroll_pos = 0;
    float[] pos;
    private bool runIt = false;
    private float time;
    private Button takeTheBtn;
    public Button PrevButton, NextButton;
    int btnNumber;
    private int currentItem=1;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        pos = new float[transform.childCount];
        distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
        
    }
    private void Awake()
    {
        PrevButton.interactable = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (scrollbar.GetComponent<Scrollbar>().value != scroll_pos)
            {
                scroll_pos = scrollbar.GetComponent<Scrollbar>().value;


            }
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                    currentItem = i;
                }
            }
        }
        

        OnInput();

    }


    private void  OnInput( )
    {   
        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {                
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
                items_description.GetComponentInChildren<TextMeshProUGUI>().text = transform.GetChild(i).gameObject.GetComponent<Item_Script>().Item_Description;
            }
            else
            {
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                
            }
        }
    }


    private void SelectMenuItem(int _index)
    {
        PrevButton.interactable = (_index != 0);
        NextButton.interactable = (_index != transform.childCount - 1);

        scroll_pos = pos[_index];    

    }


    public void ChangeItem(int _change)
    {        
        currentItem += _change ;
        SelectMenuItem(currentItem);

    }


    
}