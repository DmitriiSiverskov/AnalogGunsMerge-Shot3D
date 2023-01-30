using UnityEngine;
using UnityEngine.UI;

namespace Character.AbstractClass
{
    public enum State
    {
        Idle,
        Aim,
        Attack,
        Run,
        Die
    }
    public abstract class Character : MonoBehaviour
    {
        [SerializeField] protected Animator _animator;
        protected State _state;
        protected int hp;
        protected int damage;
        [SerializeField] protected Slider healthBar;
        [SerializeField]protected int speedMove;

        protected virtual void Update()
        {
            healthBar.value = hp;
        }

        public virtual void Action(string nameAnimation, bool onOffAnimation)
        {
            _animator.SetBool(nameAnimation,onOffAnimation);
        }
        protected virtual void Move(GameObject target){}

        protected virtual void OnCollisionStay(Collision other) {}

        public virtual void TakeDamage(int damage)
        {
            hp -= damage;
        }
    }
}