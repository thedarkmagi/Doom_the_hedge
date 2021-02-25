using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class animal
{
    public string name;
    public int weaponIndexValue;
    public slot currentSlot;
    public Sprite logo;
}

public enum slot
{
    top,
    middle,
    bottom
}

public class slots
{
    public animal _top;
    public animal _middle;
    public animal _bottom;
}

public class Player : MonoBehaviour
{
    public gun Gun;
    public HpPool hp;

    public animal hedgeHog;
    public animal skunk;
    public animal rabbit;

    slots tower;
    // Start is called before the first frame update
    void Start()
    {
        tower = new slots();
        //tower._top = 
        setTowerLocation(hedgeHog);
        setTowerLocation(skunk);
        setTowerLocation(rabbit);
    }

   

    // Update is called once per frame
    void Update()
    {
        //check if can be fired
        if (Gun.tick())
        {
            if (Input.GetMouseButton(0))
            {
                Gun.fire();
            }
        }
        //reload
        if (Input.GetKey(KeyCode.R))
        {
            Gun.reload();
        }

        //swapping logic 
        if(Input.GetKeyDown(KeyCode.Q))
        {
            swapTowerPosition(slot.top);
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            swapTowerPosition(slot.bottom);
        }
    }

    void swapTowerPosition(slot position)
    {
        switch (position)
        {
            case slot.top:
                var temp = tower._top;
                tower._top = tower._middle;
                tower._middle = temp;
                changeSystemsBasedOnTowerSlots(position);
                break;
            case slot.middle:
                changeSystemsBasedOnTowerSlots(position);
                break;
            case slot.bottom:
                var temp2 = tower._bottom;
                tower._bottom = tower._middle;
                tower._middle = temp2;
                changeSystemsBasedOnTowerSlots(position);
                break;
            default:
                break;
        }
    }

    //things update.
    void changeSystemsBasedOnTowerSlots(slot position)
    {
        switch (position)
        {
            case slot.top:
                //update weapon and passive
                Gun.changeWeapon(tower._middle.weaponIndexValue);
                break;
            case slot.middle:
                //middle and probably serve as an initialize/Set all
                break;
            case slot.bottom:
                //update weapon and legs 
                
                Gun.changeWeapon(tower._middle.weaponIndexValue);
                break;
            default:
                break;
        }
    }

    void setTowerLocation(animal _animal)
    {
        switch (_animal.currentSlot)
        {
            case slot.top:
                tower._top = _animal;
                break;
            case slot.middle:
                tower._middle = _animal;
                break;
            case slot.bottom:
                tower._bottom = _animal;
                break;
            default:
                break;
        }
    }
}
