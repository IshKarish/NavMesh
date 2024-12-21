using System;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform waypoint;
    [SerializeField] private TextMeshProUGUI uiText;
    
    private NavMeshAgent _agentComponent;
    private bool hasWon;

    private void Awake()
    {
        _agentComponent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _agentComponent.SetDestination(waypoint.position);
    }

    private void Update()
    {
        if (!_agentComponent.hasPath)
            return;
        
        if (!(_agentComponent.pathStatus == NavMeshPathStatus.PathComplete && _agentComponent.remainingDistance < 1))
            return;

        if (!hasWon)
        {
            if (string.IsNullOrEmpty(uiText.text))
            {
                uiText.text = $"AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA\n({transform.name} won)";
                hasWon = true;
            }
            else
            {
                uiText.text = $"{transform.name} lost lol";
            }
        }
    }
}
