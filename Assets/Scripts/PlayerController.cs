using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MicrobytKonami.LazyWheels.Input;

namespace MicrobytKonami.LazyWheels
{
    public class PlayerController : MonoBehaviour
    {
        // Fields
        [SerializeField] private bool isIPedal;

        // Components
        private CarController carController;
        private InputActions inputActions;

        private void Awake()
        {
            carController = GetComponent<CarController>();
            inputActions = new InputActions();
            //inputActions.Player.Move.performed += ctx => carController.Mover(ctx.ReadValue<float>());
        }

        private void OnEnable()
        {
            inputActions.Enable();
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }

        // Start is called before the first frame update
        //void Start()
        //{

        //}

        // Update is called once per frame
        void Update()
        {
            carController.Mover(inputActions.Player.Move.ReadValue<float>());
            if (isIPedal)
                carController.Acceleration(inputActions.Player.iAcceleration.ReadValue<float>());
            else
                carController.Acceleration(inputActions.Player.Acceleration.ReadValue<float>());
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            print($"OnTriggerEnter2D: {collision.gameObject.name}");
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            print($"OnCollisionEnter2D: {collision.gameObject.name}");
        }
    }
}
