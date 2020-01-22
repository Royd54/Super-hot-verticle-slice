using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;
    Animator anim;

    public float damageAmount = 1f;

    [SerializeField]
    public float attackTime = 2f;

     void Start()
    {
        target = GameObject.Find("Main Camera").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }


     void Update()
    {
            anim.speed = TimeManager.GetInstance().myTimeScale;
            float distance = Vector3.Distance(transform.position, target.position);
            Vector3 myVector = new Vector3(target.position.x, this.gameObject.transform.position.y, target.position.z);
            if (distance > 15 && anim.GetBool("Idle") == false)
            {
                agent.updatePosition = true;
                agent.SetDestination(target.position);
                agent.speed = TimeManager.GetInstance().myTimeScale * 10;
                //agent.velocity = agent.desiredVelocity * TimeManager.GetInstance().myTimeScale * 2;
                anim.SetBool("Attack", false);
                anim.SetBool("walking", true);
            }
            else
            {
            transform.LookAt(myVector);
            agent.updatePosition = false;
            anim.SetBool("Attack", true);
            anim.SetBool("walking", false);
            }
        
    }


    public void deathEvent()
    {
        GameObject.Find("TimeManager").GetComponent<sceneManager>().Death();
    }

    public void ApplyDamage()
    {
        GameObject.Find("TimeManager").GetComponent<EnemyCheck>().EnemyDead();
        Destroy(this.gameObject);
    }


    // transform. forward gebruiken met time. delta time
    //navmesh gebruiken
    //navmes op component zetten
    //chek er op zetten over distance 
    //bullet kan naar emty toe gaan in speler
}





