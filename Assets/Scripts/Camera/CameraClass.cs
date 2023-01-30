using System;
using UnityEngine;

namespace Camera
{
    public class CameraClass : MonoBehaviour
    {
        private void Update()
        {
            GlobalManagerEvent.Events.LookTarget.Invoke(transform);
        }
    }
}