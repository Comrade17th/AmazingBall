using UniRx;
using UnityEngine;

namespace _Project.Codebase.Core.Ball
{
    public class BallModel : IBallModel
    {
        public ReactiveProperty<Vector3> Velocity { get; set; } = new (new Vector3(10f, 0f, 0f));
    }

    public interface IBallModel
    {
        ReactiveProperty<Vector3> Velocity { get; set; }
    }
}