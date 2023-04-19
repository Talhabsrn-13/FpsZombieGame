using Project3.Abstract.Controller;
using Project3.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project3.Animations
{
    public class CharacterAnimation
    {
        Animator _animator;

        public CharacterAnimation(IEntityController entity)
        {
            _animator = entity.transform.GetComponentInChildren<Animator>();
        }

        public void MoveAnimation(float moveSpeed)
        {
            if (_animator.GetFloat("MoveSpeed") == moveSpeed) return;

            _animator.SetFloat("MoveSpeed", moveSpeed, 0.1f, Time.deltaTime);
        }

        public void AttackAnimation(bool canAttack)
        {     
            _animator.SetBool("isAttack", canAttack); 
        }
    }
}
