using UnityEngine;

namespace Project3.Abstract.Inputs
{
    public interface IInputReader
    {
        Vector3 Direction { get; }
        Vector2 Rotation { get; }
        bool IsAttackButtonPress { get; }
        bool IsInventoryButtonPressed { get;  }
    }
}
