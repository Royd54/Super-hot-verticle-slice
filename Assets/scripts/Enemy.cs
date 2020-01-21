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
    float attackTime = 2f;

     void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }


     void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        
        if(distance > 0.5)
        {
            agent.updatePosition = true;
            agent.SetDestination(target.position);
            anim.SetBool("Idle", false);
            anim.SetBool("Attack", false);
            anim.SetBool("walking", true);
        }
        else
        {
            agent.updatePosition = false;
            anim.SetBool("Idle", false);
            anim.SetBool("Attack", true);
            anim.SetBool("walking", true);
            StartCoroutine(AttackTime());
        }
    }

   IEnumerator AttackTime()
    {
        yield return new WaitForSeconds(0.5f);
        PlayerHealth.singleton.DamagePlayer(damageAmount);
        yield return new WaitForSeconds(attackTime);
    }


    // transform. forward gebruiken met time. delta time
    //navmesh gebruiken
    //navmes op component zetten
    //chek er op zetten over distance 
    //bullet kan naar emty toe gaan in speler
}





