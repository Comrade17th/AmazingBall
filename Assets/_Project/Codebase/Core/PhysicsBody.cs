using System.Collections.Generic;
using UnityEngine;

namespace _Project.Codebase.Core
{
    [RequireComponent(typeof(Collider))]
    public class PhysicsBody : MonoBehaviour
    {
        private readonly Vector3 Gravity = new Vector3(0f, -9.81f, 0f);
        private readonly float Gravityf = -9.8f;
        
        [SerializeField] private float _friction = 0.1f;
        [SerializeField] private float _dampingImpactPercent = 0.1f;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private Vector3 _velocity = new Vector3(0, 0, 3);
        
        private void FixedUpdate()
        {
            // if(_velocity.y > 0.1f)
            //     _velocity += Gravity * Time.fixedDeltaTime;
            
            _velocity = new Vector3(
                Mathf.MoveTowards(_velocity.x, 0, _friction * Time.fixedDeltaTime),
                _velocity.y,
                Mathf.MoveTowards(_velocity.z, 0, _friction * Time.fixedDeltaTime));
            
            transform.Translate(_velocity * Time.fixedDeltaTime);
        }

        public void AddVelocity(float velocity, Vector3 direction)
        {
            _velocity += direction * velocity;
        }

        private void OnCollisionEnter(Collision collision)
        {
            var contatcs = new List<ContactPoint>();
            collision.GetContacts(contatcs);
            
            ContactPoint contact = contatcs[0];
            Vector3 reflectedDirection = Vector3.Reflect(_velocity, contact.normal);
            
            _velocity = reflectedDirection;
            _velocity -= _velocity * _dampingImpactPercent;
            
            // foreach (var item in collision.contacts)
            // {
            //     Debug.DrawRay(item.point, _direction * -100, Color.blue, 10f);
            //     Debug.DrawRay(item.point, item.normal * 100, Color.cyan, 10f);
            //     Debug.DrawRay(item.point,  Vector3.Reflect(_direction, item.normal) * 100, Color.magenta, 10f);
            //     Debug.Log($"origin normal {item.point} normalized: {item.point.normalized}");
            //}
        }
    }
}