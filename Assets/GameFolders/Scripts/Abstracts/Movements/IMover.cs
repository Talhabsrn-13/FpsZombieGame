using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project3.Abstract.Movements
{
    public interface IMover 
    {
        void MoveAction(Vector3 direction, float moveSpeed);
    }

}
