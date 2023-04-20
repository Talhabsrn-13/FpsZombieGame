using Project3.Abstract.Movements;
using Project3.Animations;
using Project3.Controllers;
using UnityEngine;

namespace Project3.Abstract.Controller
{
    public interface IEnemyController : IEntityContoller
    {
        IMover Mover { get; }
        InventoryController Inventory { get; }
        CharacterAnimation Animation { get; }
        Transform Target { get; set; }

        float Magnitude { get; }
    }
}
