using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Observation : MonoBehaviour
{
    
    [SerializeField] private GameObject _gameobject;
    [SerializeField] private List<GameObject> _listGameObjectObservation;
    [SerializeField] private GameObject _targetPosition;
    [SerializeField] private float speed;
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float z;
    private GameObject closest;

    private void Awake()
    {
        _listGameObjectObservation = new List<GameObject>();
        GlobalManagerEvent.Events.AddEnemy.AddListener(AddEnemyInTheListGameObjectObservation);
    }

    void Update()
    {
        SmoothTurn(SeachObject());
        GlobalManagerEvent.Events.TargetPosition.Invoke(_targetPosition);
    }
    private GameObject SeachObject()
    {
        float distance = Mathf.Infinity;
        Vector3 position = _gameobject.transform.position;
        foreach (var item in _listGameObjectObservation)
        {
            Vector3 diff = item.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = item;
                distance = curDistance;   
            }
        }
        return closest;
    }
    
    private void SmoothTurn(GameObject targetGameObject)
    {
         Vector3 direction = targetGameObject.transform.position - _gameobject.transform.position;
         Vector3 forward = _gameobject.transform.forward;
         Vector3 adjustingDirection = new Vector3(x,y,z);
         Quaternion rotation = Quaternion.LookRotation(direction + adjustingDirection);
         _gameobject.transform.rotation = Quaternion.Lerp(_gameobject.transform.rotation,rotation,speed * Time.deltaTime);

    }

    private void AddEnemyInTheListGameObjectObservation(GameObject enemy)
    {
        _listGameObjectObservation.Add(enemy);
    }
}
