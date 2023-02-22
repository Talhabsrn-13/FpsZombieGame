using Project3.Abstract.Inputs;
using Project3.Abstract.Movements;
using Project3.Animations;
using Project3.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project3.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement Informations")]
        [SerializeField] float _moveSpeed;

        CharacterAnimation _animation;
       
        IInputReader _input;
        IMover _mover;

        Vector3 _direction;
        private void Awake()
        {
            _input = GetComponent<IInputReader>();
            _mover = new MoveWithCharacterController(this);
            _animation = new CharacterAnimation(this);
        }
        private void Update()
        {
            _direction = _input.Direction;
        }
        private void FixedUpdate()
        {
            _mover.MoveAction(_direction, _moveSpeed);
        }
        void LateUpdate()
        {
            _animation.MoveAnimation(_direction.magnitude);
        }
    }
}
