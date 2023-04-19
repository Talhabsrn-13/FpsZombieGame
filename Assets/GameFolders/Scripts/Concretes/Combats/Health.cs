using Project3.Abstract.Combats;
using Project3.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project3.Combats
{
    public class Health : MonoBehaviour, IHealth
    {
        [SerializeField] HealthSO _healthInfo;

        public event System.Action<int,int> OnTakeHit;
        int _currentHealth;
        public bool IsDead => _currentHealth <= 0;

        private void Awake()
        {
            _currentHealth = _healthInfo.MaxHealth; 
        }
        
        public void TakeDamage(int  damage)
        {
            if (IsDead) return;
           
            _currentHealth -= damage;

            OnTakeHit?.Invoke(_currentHealth, _healthInfo.MaxHealth);
        }
    }
}
