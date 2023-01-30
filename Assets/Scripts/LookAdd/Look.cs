using System;
using UnityEngine;

namespace LookAdd
{
    public class Look : MonoBehaviour
    {
        private void Update()
        {
            GlobalManagerEvent.Events.LookTarget.AddListener(AddLook);
        }

        private void AddLook(Transform target)
        {
            transform.LookAt(target);
        }
    }
}