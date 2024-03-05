using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZomPunch
{
    public class PositionLockCameraController : MonoBehaviour
    {
        [SerializeField]
        private GameObject Target;
        private Camera managedCamera;

        private void Awake()
        {
            managedCamera = gameObject.GetComponent<Camera>();
        }

        //Use the LateUpdate message to avoid setting the camera's position before
        //GameObject locations are finalized.
        void LateUpdate()
        {
            var targetPosition = this.Target.transform.position;
            var cameraPosition = managedCamera.transform.position;

            managedCamera.transform.position = new Vector3(targetPosition.x, targetPosition.y, cameraPosition.z);
        }
    }
}