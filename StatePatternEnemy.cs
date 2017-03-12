
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class StatePatternEnemy : MonoBehaviour
{
    public float searchingTurnSpeed = 120f;
    public float searchingDuration = 4f;
    public float sightRange = 20f;
    public List <Transform> wayPoints;
    public Transform eyes;
    public Vector3 offset = new Vector3(0, .5f, 0);
    public GameObject waypointPrefab;
    public Transform lastPosition;
    public Transform currentPlayerPosition;
    public MeshRenderer meshRendererFlag;
    public Transform HideCanvas;
    
    [HideInInspector] 
    public Animator m_Animator;
    [HideInInspector]
    public Vector3 VecPos;
    [HideInInspector]
    public Transform chaseTarget;
    [HideInInspector]
    public IEnemyState currentState;
    [HideInInspector]
    public ChaseState chaseState;
    [HideInInspector]
    public AlertState alertState;
    [HideInInspector]
    public PatrolState patrolState;
    [HideInInspector]
    public UnityEngine.AI.NavMeshAgent navMeshAgent;

    private void Awake()
    {
        chaseState = new ChaseState(this);
        alertState = new AlertState(this);
        patrolState = new PatrolState(this);

        m_Animator = GetComponent<Animator>();//
       
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

     
    }

    // Use this for initialization
    void Start()
    {
        currentState = patrolState;
        
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(); //checks current state of enemy

        if (Time.timeScale == 0) //checks if game is over
        {
            HideCanvas.gameObject.SetActive(false); //remove hidecanvas from screen
        }

        if (HideCanvas.gameObject.activeInHierarchy)//begings couroutine for hidecanvas
        {        
            StartCoroutine(turnoff());
          
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }

    IEnumerator turnoff()
    {
        yield return new WaitForSeconds(4); //displays hidecanvas for 4 seconds
        HideCanvas.gameObject.SetActive(false);
    }


}