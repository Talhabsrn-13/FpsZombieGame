using Project3.Abstract.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project3.Abstract.Controller
{
    public interface IEntityController
    {
        public Transform transform { get; }
        IMover Mover { get; }
    }

}
