using System.Collections.Generic;
using UnityEngine;

namespace _Project.Codebase.Core
{
    [RequireComponent(typeof(Collider))]
    public class PhysicsBody : MonoBehaviour
    {
        private readonly Vector3 Gravity = new Vector3(0f, -9.81f, 0f);
        
        [SerializeField] private float _friction = 0.1f; // sepparate air friction and ground friction
        [SerializeField] private float _dampingImpactPercent = 0.1f;
        
        [SerializeField] private Vector3 _velocity = new Vector3(0, 0, 0);
        [SerializeField] private Vector3 _acceleration = new Vector3(0, 0, 0);
        

        private void FixedUpdate()
        {
            _velocity += Gravity * Time.fixedDeltaTime;
            
            _velocity = new Vector3(
                Mathf.MoveTowards(_velocity.x, 0, _friction),
                _velocity.y,
                Mathf.MoveTowards(_velocity.z, 0, _friction));
            
            transform.Translate(_velocity * Time.fixedDeltaTime);
        }

        public void AddVelocity(float velocity, Vector3 direction)
        {
            
        }

        private void OnCollisionEnter(Collision collision)
        {
            // Debug.Log("Points colliding: " + collision.contacts.Length);
            // Debug.Log("Normal of the first point: " + collision.contacts[0].normal);
            
            var contatcs = new List<ContactPoint>();
            collision.GetContacts(contatcs);
            
            ContactPoint contact = contatcs[0];
            Vector3 reflectedDirection = Vector3.Reflect(_velocity, contact.normal);
            
            //bug.Log($"{} {reflectedDirection}");
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