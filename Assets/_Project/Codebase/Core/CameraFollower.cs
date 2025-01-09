using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core
{
    public class CameraFollower : MonoBehaviour
    {
        private Transform _target;
        
        public float distance = 3.0f;
        public float height = 3.0f;
        public float damping = 5.0f;
        public bool smoothRotation = true;
        public bool followBehind = true;
        public float rotationDamping = 10.0f;

        [Inject]
        private void Construct(BallView target)
        {
            _target = target.transform;
        }

        void Update() // https://stackoverflow.com/questions/10752435/how-do-i-make-a-camera-follow-an-object-in-unity3d-c#answers 
        {
            Vector3 wantedPosition;
            
            if(followBehind)
                wantedPosition = _target.TransformPoint(0, height, -distance);
            else
                wantedPosition = _target.TransformPoint(0, height, distance);

            transform.position = Vector3.Lerp (transform.position, wantedPosition, Time.deltaTime * damping);

            if (smoothRotation)
            {
                Quaternion wantedRotation = Quaternion.LookRotation(_target.position - transform.position, _target.up);
                transform.rotation = Quaternion.Slerp (transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
            }
            else 
                transform.LookAt (_target, _target.up);
        }
    }
}