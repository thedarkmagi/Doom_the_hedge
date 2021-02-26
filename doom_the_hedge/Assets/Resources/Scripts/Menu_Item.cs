using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Menu_Item : MonoBehaviour {
    // Start is called before the first frame update
    [SerializeField] private Button PrevButton;
    [SerializeField] private Button NextButton;
    //[SerializeField] private GameObject[] items;
    [SerializeField] private GameObject items_description;
    private int currentItem, childObjs;

    private void Awake () {
        SelectMenuItem (0);
        childObjs = transform.childCount;
    }

    private void SelectMenuItem (int _index) {

        //PrevButton.interactable = (_index != 0);
        //NextButton.interactable = (_index != transform.childCount - 1);
        //for (int i = 0; i < transform.childCount; i++) {
        //    transform.GetChild (i).gameObject.SetActive (i == _index);
        //    items_description.GetComponentInChildren<TextMeshProUGUI>().text = transform.GetChild(_index).gameObject.GetComponent<TextMeshPro>().text;
        //}

        PrevButton.interactable = (_index != 0);
        NextButton.interactable = (_index != transform.childCount - 1);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == _index);
            items_description.GetComponentInChildren<TextMeshProUGUI>().text = transform.GetChild(_index).gameObject.GetComponent<TextMeshPro>().text;
        }



    }

    public void ChangeItem (int _change) {
        currentItem += _change;
        SelectMenuItem (currentItem);
        

    }

}