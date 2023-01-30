using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpawnPlane
{
    public class SpawnCharacterItemEnemy : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _listEnemy;
        [SerializeField] private List<GameObject> _poitSpawn;
        [SerializeField] private int _countEnemy;
        [SerializeField] private float _timeSpawnEnemy;
        private int _positionSpaw;
        private void Start()
        {
            StartCoroutine(Spawn());
            _positionSpaw = _poitSpawn.Count - 1;
        }

        private IEnumerator Spawn()
        {
           
            int count = 0;
            while (true)
            {
                if (count > _countEnemy)
                {
                    yield break;
                }
                Instantiate(_listEnemy[Random.Range(0, _listEnemy.Count - 1)],
                    _poitSpawn[_positionSpaw].transform.position, Quaternion.identity);
                count++;
                _positionSpaw--;
                yield return new WaitForSeconds(_timeSpawnEnemy);
                if (_positionSpaw == 0)
                {
                    _positionSpaw = _poitSpawn.Count - 1;
                }
            }
        }
    }
}