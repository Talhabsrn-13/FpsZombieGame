using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project3.Abstract.Combats
{
    public interface IHealth
    {
        bool IsDead { get; }
        void TakeDamage(int damage);
        event System.Action OnDead;
    }

}
