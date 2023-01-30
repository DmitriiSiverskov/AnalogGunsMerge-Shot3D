using System;
using UnityEngine;

namespace Weapon.AbstractClass
{
    public abstract class Weapon : MonoBehaviour
    {
        protected int damage;

        protected virtual void OnTriggerEnter(Collider other)
        {
            
        }
    }
}