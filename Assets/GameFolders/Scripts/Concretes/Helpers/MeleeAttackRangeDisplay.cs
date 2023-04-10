using Project3.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Project3.Helpers
{
    public class MeleeAttackRangeDisplay : MonoBehaviour
    {
        [SerializeField] AttackSO _attackSo;
      void OnDrawGizmos()
        {
            OnDrawGizmosSelected();
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(this.transform.position, _attackSo.FloatValue);
        }
    }

}
