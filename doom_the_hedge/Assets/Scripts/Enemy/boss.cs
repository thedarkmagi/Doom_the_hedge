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
    public GameObject shockwaveObj;
    public shockwaveOpperator shock;
    public HpPool hp;

    public float fireRate;
    public float currFireRate;

    public AttackModes nextAttackMode;

    public travelDirection direction;
    public GameObject startPos;
    public GameObject endPos;
    public GameObject trigger;
    public float travelUpSpeed;
    public float travelDownSpeed;
    private float startTime;
    private float journeyLength;

    public GameObject waveController;
    // Start is called before the first frame update
    void Start()
    {
        trigger.GetComponent<Collider>().enabled = false;
        //shock = GetComponent<shockwaveOpperator>();
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPos.transform.position, endPos.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (hp.HP <= 0)
        {
            kill();
        }
        else
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
            if (nextAttackMode == AttackModes.shockwave)
            {
                shockwave();
            }
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
    void shockwaveSlam()
    {
        shock.activateAttack();

        nextAttackMode = AttackModes.bubbleBlast;
    }
    void shockwave()
    {
        switch (direction)
        {
            case travelDirection.up:
                travelInDirection(endPos, travelUpSpeed);
                if (Vector3.Distance(transform.position, endPos.transform.position) < 1)
                {
                    direction = travelDirection.down;
                }
                break;
            case travelDirection.down:
                travelInDirection(startPos, travelDownSpeed);
                if (Vector3.Distance(transform.position, startPos.transform.position) < 1)
                {
                    transform.localPosition = Vector3.zero;
                    //setup for next time
                    direction = travelDirection.up;
                    //do attack stuff 
                    shockwaveSlam();
                }
                break;
            case travelDirection.inactive:
                break;
            default:
                break;
        }




    }


    void travelInDirection(GameObject target, float speed)
    {
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;
        ;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(transform.position, target.transform.position, fractionOfJourney);
    }

    void kill()
    {
        transform.localPosition = Vector3.zero;
        //Destroy(gameObject);
        if(waveController)
        {
            Destroy(waveController);
        }
        trigger.GetComponent<Collider>().enabled=true;
    }
}
