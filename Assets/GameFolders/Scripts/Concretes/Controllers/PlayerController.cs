using Project3.Abstract.Combats;
using Project3.Abstract.Controller;
using Project3.Abstract.Inputs;
using Project3.Abstract.Movements;
using Project3.Animations;
using Project3.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project3.Controllers
{
    public class PlayerController : MonoBehaviour, IEntityContoller
    {
        [Header("Movement Informations")]
        [SerializeField] float _moveSpeed;
        [SerializeField] float _turnSpeed;
        [SerializeField] Transform _turnTransform;

        CharacterAnimation _animation;
        InventoryController _inventory;

        IInputReader _input;
        IMover _mover;
        IRotator _xRotator;
        IRotator _yRotator;
        IHealth _health;

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
            _inventory = GetComponent<InventoryController>();
            _health = GetComponent<IHealth>();
        }
        private void OnEnable()
        {
            _health.OnDead +=()=> _animation.DeadAnimation("dead");
        }
        private void OnDisable()
        {
            _health.OnDead -= () => _animation.DeadAnimation("dead");
        }
        private void Update()
        {
            if (_health.IsDead) return;

            _direction = _input.Direction;
            _rotation = _input.Rotation;

            _xRotator.RotationAction(_rotation.x, _turnSpeed);
            _yRotator.RotationAction(_rotation.y, _turnSpeed);
            
            if (_input.IsAttackButtonPress)
            {
                _inventory.CurrentWeapon.Attack();
            }

            if (_input.IsInventoryButtonPressed)
            {
                _inventory.ChangeWeapon();
            }

        }
        private void FixedUpdate()
        {
            if (_health.IsDead) return;
            _mover.MoveAction(_direction, _moveSpeed);
        }
        void LateUpdate()
        {
            if (_health.IsDead) return;
            _animation.MoveAnimation(_direction.magnitude);
            _animation.AttackAnimation(_input.IsAttackButtonPress);
        }
    }
}
