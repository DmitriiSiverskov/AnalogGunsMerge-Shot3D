using Player;
using UnityEngine;

namespace Character.AbstractClass
{
   
    public abstract class Enemy : Character
    {
        [SerializeField] protected float _distance;
        
        protected virtual void Start()
        {
            hp = 100;
            GlobalManagerEvent.Events.AddEnemy.Invoke(gameObject);
            GlobalManagerEvent.Events.TargetPosition.AddListener(Move);
            
        }

        protected override void OnCollisionStay(Collision other)
        { 
            if (other.gameObject.CompareTag("Player"))
            {
                Action("IsAttack",true);
            }
            
        }
        protected override void Move(GameObject target)
        {
            var dir = target.transform.position - transform.position;
            if (dir.sqrMagnitude > _distance * _distance)
            {
                float step = speedMove * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
                transform.LookAt(target.transform);
            }
        }
    }
}