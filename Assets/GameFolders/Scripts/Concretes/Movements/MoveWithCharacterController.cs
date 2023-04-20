using Project3.Abstract.Controller;
using Project3.Abstract.Movements;
using Project3.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project3.Movements
{
    public class MoveWithCharacterController : IMover
    {
        CharacterController _characterController;
        public MoveWithCharacterController(IEntityContoller entityController)
        {
            _characterController = entityController.transform.GetComponent<CharacterController>();
        }


        public void MoveAction(Vector3 direction, float moveSpeed)
        {
            if (direction.magnitude == 0f) return;

            Vector3 worldPosition = _characterController.transform.TransformDirection(direction);
            Vector3 movement = worldPosition * moveSpeed * Time.deltaTime;

            _characterController.Move(movement);
        }
    }

}
