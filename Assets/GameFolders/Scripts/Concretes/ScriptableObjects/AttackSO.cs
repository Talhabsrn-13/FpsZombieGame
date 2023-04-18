using Project3.Abstract.Combats;
using Project3.Combats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project3.ScriptableObjects
{
    enum AttackTypeEnum : byte
    {
        Range,Melee
    }
    [CreateAssetMenu(fileName = "Attack Info", menuName = "Attack Information/ Create New", order = 51)]
    public class AttackSO : ScriptableObject
    {
        [SerializeField] AttackTypeEnum _attackType;
        [SerializeField] float _floatValue = 1f;
        [SerializeField] int _damage = 10;
        [SerializeField] LayerMask _layerMask;
        [SerializeField] float _attackMaxDelay = 0.25f;
        [SerializeField] AnimatorOverrideController _animatorOverride;
        public int Damage => _damage;
        public float FloatValue => _floatValue;
        public LayerMask LayerMask => _layerMask;
        public float AttackMaxDelay => _attackMaxDelay;
        public AnimatorOverrideController AnimatorOverride => _animatorOverride;
        public IAttackType GetAttackType(Transform transform)
        {
            if (_attackType == AttackTypeEnum.Range)
            {
                return new RangeAttackType(transform,this);
            }
            else
            {
                return new MeleeAttackType(transform,this);
            }
        }
    }

}
