using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum enemyType
{
    otter,
    sniper,
    porpoise,
    plat,
    walrus_tank
}

public class Enemy : MonoBehaviour
{
    public HpPool hp;
    float lastFramesHP;
    public enemyType type;
    NavMeshAgent agent;

    public gun _gun;
    public SphereCollider agroRange;
    public argo agg;

    public float minDistance;
    public float aimTime;
    float currAimTime;
    Animator anim;
    bool hasAnim;

    string deathanimName;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if(TryGetComponent<Animator>(out anim))
        {
            anim = anim;
            hasAnim = true;
        }
        else
        {
            hasAnim = false;
        }
        lastFramesHP = hp.HP;

        switch (type)
        {
            case enemyType.otter:
                deathanimName = "otterDeath";
                break;
            case enemyType.sniper:
                deathanimName = "doplinDeath";
                break;
            case enemyType.porpoise:
                deathanimName = "porpDeath";
                break;
            case enemyType.plat:
                //this will need changing once setup
                deathanimName = "otterDeath";
                break;
            case enemyType.walrus_tank:
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(hpChanged())
        {
            if (hasAnim)
                anim.SetTrigger("hit");
        }

        if(hp.HP<=0)
        {
            kill();
        }
        transform.forward = new Vector3(Camera.main.transform.forward.x,
            transform.forward.y, Camera.main.transform.forward.z);
        switch (type)
        {
            case enemyType.otter:
                otter();
                break;
            case enemyType.sniper:
                sniper();
                break;
            case enemyType.porpoise:
                porpoise();
                break;
            case enemyType.plat:
                otter();
                break;
            case enemyType.walrus_tank:
                break;
            default:
                break;
        }

        
    }

    void otter()
    {
        if (agg.agrroed)
        {
            if (_gun.tick())
            {
                if(hasAnim)
                    anim.SetTrigger("shoot");
                _gun.fire();
            }
            
            if (Vector3.Distance(transform.position, gamemanager.instance.player.transform.position) > minDistance)
            {
                agent.SetDestination(gamemanager.instance.player.transform.position);
            }
        }
    }
    void sniper()
    {
        if (agg.agrroed)
        {
            if (_gun.tick())
            {
                currAimTime += Time.deltaTime;
                if (hasAnim)
                    anim.SetBool("aiming",true);
                if (currAimTime > aimTime)
                {
                    if (hasAnim)
                    {
                        anim.SetBool("aiming", false);
                        anim.SetTrigger("shoot");
                    }
                    currAimTime = 0;
                    _gun.fire();
                }
            }

        }
        else
        {
            if (hasAnim)
                anim.SetBool("aiming", false);
        }
    }
    void porpoise()
    {
        if (agg.agrroed)
        {
            if (_gun.tick())
            {
                _gun.fire();
            }
            if (_gun.isFinishedReloading())
            {
                agent.SetDestination(gamemanager.instance.player.transform.position);
            }
            else
            {
                if (hasAnim)
                    anim.SetTrigger("reload");
            }
        }
    }

    private void LateUpdate()
    {
        //transform.forward = new Vector3(Camera.main.transform.forward.x,
        //    transform.forward.y, Camera.main.transform.forward.z);
    }

    bool hpChanged()
    {
        bool result = false;
        if(hp.HP != lastFramesHP)
        {
            lastFramesHP = hp.HP;
            result = true;
        }

        return result;
    }

    void kill()
    {
        if (hasAnim)
        {
            if (hasAnim)
            {
                anim.SetBool("dead", true);
                
                if (anim.GetCurrentAnimatorStateInfo(0).IsName(deathanimName))
                {
                    Destroy(this.gameObject);
                }
            }

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
