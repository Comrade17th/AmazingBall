using UniRx;
using UnityEngine;

namespace _Project.Codebase.Core.Ball
{
    public class BallModel : IBallModel
    {
        public ReactiveProperty<Vector3> Velocity { get; set; } = new (new Vector3(0f, 0f, 0f));
        public ReactiveProperty<string> SpeedLabel { get; set; } = new($"Speed:");
        public ReactiveProperty<string> AngleLabel { get; set; }= new($"Angle:");
    }

    public interface IBallModel
    {
        ReactiveProperty<Vector3> Velocity { get; set; }
        ReactiveProperty<string> SpeedLabel { get; set; }
        ReactiveProperty<string> AngleLabel { get; set; }
    }
}