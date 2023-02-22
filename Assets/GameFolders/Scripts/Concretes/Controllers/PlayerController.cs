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
        [SerializeField] float _turnSpeed;
        [SerializeField] Transform _turnTransform;

        CharacterAnimation _animation;
       
        IInputReader _input;
        IMover _mover;
        IRotator _xRotator;
        IRotator _yRotator;

        Vector3 _direction;
        Vector2 _rotation;

        public Transform TurnTransform => _turnTransform;
        private void Awake()
        {
            _input = GetComponent<IInputReader>();
            _mover = new MoveWithCharacterController(this);
            _animation = new CharacterAnimation(this);
            _xRotator = new RotatorX(this);
            _yRotator = new RotatorY(this);
        }
        private void Update()
        {
            _direction = _input.Direction;
            _rotation = _input.Rotation;
            _xRotator.RotationAction(_rotation.x, _turnSpeed);
            _yRotator.RotationAction(_rotation.y, _turnSpeed);
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
