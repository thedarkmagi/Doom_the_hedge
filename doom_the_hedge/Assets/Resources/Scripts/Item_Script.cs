using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Fungus;

public class Item_Script : MonoBehaviour
{
    //[SerializeField] private TextMeshPro Item_Description;
    public string ItemOwnername;
    public string Item_Description;
    private bool isObjSelected=false;
    // Start is called before the first frame update
    void Start() {
       
   }
    private void Awake()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.localScale.x < 1)
            isObjSelected = false;
    }


    public void ObjectSelected()
    {
        if (isObjSelected == false)
        {
            if (GameObject.Find(ItemOwnername) == null)
                Fungus.Flowchart.BroadcastFungusMessage("Give_false");
            else
                Fungus.Flowchart.BroadcastFungusMessage("Give");

            isObjSelected = true;
        }
    }
}
