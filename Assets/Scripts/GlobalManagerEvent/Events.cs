using UnityEngine;
using UnityEngine.Events;

namespace GlobalManagerEvent
{
    public class Events : MonoBehaviour
    {
        public static UnityEvent<GameObject> AddEnemy = new UnityEvent<GameObject>();
        public static UnityEvent<GameObject> TargetPosition = new UnityEvent<GameObject>();
        public static UnityEvent<Transform> LookTarget = new UnityEvent<Transform>();
    }
}