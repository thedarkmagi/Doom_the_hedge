using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AttackModes
{
    bubbleBlast,
    shockwave
}

public class boss : MonoBehaviour
{
    public List<GameObject> bubbleBlastLevels;
    public HpPool hp;

    public float fireRate;
    public float currFireRate;

    public AttackModes nextAttackMode;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        currFireRate += Time.deltaTime;
        if (currFireRate > fireRate)
        {

            switch (nextAttackMode)
            {
                case AttackModes.bubbleBlast:
                    bubbleBlast();
                    break;
                case AttackModes.shockwave:
                    shockwave();
                    break;
                default:
                    break;
            }
            currFireRate = 0;
        }
    }

    void bubbleBlast()
    {
        int ind = Random.Range(0, bubbleBlastLevels.Count-1);
        var guns = bubbleBlastLevels[ind].GetComponentsInChildren<gun>();

        foreach (var _gun in guns)
        {
            if (_gun.tick())
            {
                _gun.fire();
            }
        }

        nextAttackMode = AttackModes.shockwave;
        if(Random.Range(0.0f,1.0f)>0.5f)
        {
            nextAttackMode = AttackModes.bubbleBlast;
        }
    }

    void shockwave()
    {


        nextAttackMode = AttackModes.bubbleBlast;
    }
}
