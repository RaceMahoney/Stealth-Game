using UnityEngine;
using System.Collections;

public interface IEnemyState
    //interface for State Machine
{

    void UpdateState();

    void OnTriggerEnter(Collider other);

    void ToPatrolState();

    void ToAlertState();

    void ToChaseState();
}
