using System;
using Character.EnemyZombie;
using Player;
using UnityEngine;

namespace Weapon
{
    public class WeaponZombie : AbstractClass.Weapon
    {
        private void Start()
        {
            damage = 3;
        }

        protected override void OnTriggerEnter(Collider other)
        { 
            if (other.gameObject.CompareTag("Player"))
            {
                other.GetComponent<PlayerClass>().TakeDamage(damage);
                print("Удар");
            }
        }
    }
}