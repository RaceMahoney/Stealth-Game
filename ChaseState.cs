using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IEnemyState

{

    private readonly StatePatternEnemy enemy;
    
 
    public ChaseState(StatePatternEnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void Awake()
    {
        enemy.HideCanvas.gameObject.SetActive(false);
    }

    public void UpdateState()
    {
        Look();
        Chase();
    }

    public void OnTriggerEnter(Collider other)
    {

    }

    public void ToPatrolState()
    {

    }

    public void ToAlertState()
    {
        enemy.currentState = enemy.alertState;
    }

    public void ToChaseState()
    {

    }

    private void Look()
    {
        RaycastHit hit;
        //checks if agent sees Player
        Vector3 enemyToTarget = (enemy.chaseTarget.position + enemy.offset) - enemy.eyes.transform.position;
        if (Physics.Raycast(enemy.eyes.transform.position, enemyToTarget, out hit, enemy.sightRange) && hit.collider.CompareTag("Player"))
        {
            enemy.chaseTarget = hit.transform;


        }
        else
        {
            //this secttion of code is where old waypoints are removed and a new set of 4 waypoints are
            //created based on the player's last seen location

            enemy.wayPoints.Clear(); //clear list of old waypoints
            enemy.HideCanvas.gameObject.SetActive(false); //turn hide canvas if not already off

            
            enemy.currentPlayerPosition = hit.transform;
            enemy.lastPosition = enemy.currentPlayerPosition;
            enemy.VecPos = enemy.lastPosition.transform.position; //saved the last position as a vector 3

            GameObject newWaypoint = Object.Instantiate(enemy.waypointPrefab, enemy.VecPos, Quaternion.identity) as GameObject; //create new inital waypoint based on player's last postion


            enemy.wayPoints.Add(newWaypoint.transform);//center

            Vector3 position1 = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)) + enemy.VecPos; //make new postions randomly in a 10 by 10 range
            Vector3 position2 = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)) + enemy.VecPos;
            Vector3 position3 = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)) + enemy.VecPos;
            GameObject newWaypoint1 = GameObject.Instantiate(enemy.waypointPrefab, position1, Quaternion.identity); //create and place new gameobjects
            GameObject newWaypoint2 = GameObject.Instantiate(enemy.waypointPrefab,position2, Quaternion.identity);
            GameObject newWaypoint3 = GameObject.Instantiate(enemy.waypointPrefab, position3, Quaternion.identity);

            enemy.wayPoints.Add(newWaypoint1.transform); //add new waypints to list
            enemy.wayPoints.Add(newWaypoint2.transform);
            enemy.wayPoints.Add(newWaypoint3.transform);

            ToAlertState();//move to alert state
        }

    }

    private void Chase()
    {
        enemy.HideCanvas.gameObject.SetActive(true); //turn on hide canvas

        enemy.m_Animator.SetFloat("forwardSpeed", 0.7f);// set agent and animator speed
        enemy.m_Animator.SetFloat("turnSpeed", 0f);//

        enemy.meshRendererFlag.material.color = Color.red;
        enemy.navMeshAgent.destination = enemy.chaseTarget.position;
        enemy.navMeshAgent.Resume();

        
       
    }

   




}