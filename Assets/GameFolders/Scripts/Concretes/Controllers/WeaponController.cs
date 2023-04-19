using Project3.Abstract.Combats;
using Project3.Combats;
using Project3.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project3.Controllers
{
    public class WeaponController : MonoBehaviour
    {

        [SerializeField] bool _canFire;    
        [SerializeField] Transform _transformObject;
        [SerializeField] AttackSO _attackSO;
      
        IAttackType _attackType;

        public AttackSO AttackSO => _attackSO;

        float _currentTime;

        private void Awake()
        {
            _attackType = _attackSO.GetAttackType(_transformObject);
        }
        void Update()
        {
            _currentTime += Time.deltaTime;

            _canFire = _currentTime > _attackSO.AttackMaxDelay;
        }

        public void Attack()
        {
            if (!_canFire) return;

  
            _attackType.AttackAction();

            _currentTime = 0;

        }
    }

}
