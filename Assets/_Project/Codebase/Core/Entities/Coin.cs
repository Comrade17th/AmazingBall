using UnityEngine;

namespace _Project.Codebase.Core.Entities
{
    [RequireComponent(typeof(Collider))]
    public class Coin : MonoBehaviour
    {
        [SerializeField] public int Value = 1;
    }
}