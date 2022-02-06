using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace FSM
{ 
    public class Controller : MonoBehaviour
    {
        public State currentState;
        public State remainState;
        

        public bool ActiveAI { get; set; }

        public void Start()
        {
            ActiveAI = true;
        }

        private HealthSystem _healthSystem;
        private Animator _animatorController;

        private void Awake()
        {
            _animatorController = GetComponent<Animator>();
            _healthSystem = GetComponent<HealthSystem>();
           
        }
        public void Update()
        {
            if (!ActiveAI) return;

            currentState.UpdateState(this);
        }

        public void Transition(State nextState)
        {
            if(nextState != remainState)
            {
                currentState = nextState;
            }
        }

        public void SetAnimation(string animation, bool value)
        {
            _animatorController.SetBool(animation, value);
        }

        public float GetCurrentHealth()
        {
            return _healthSystem.currentHealth;
        }

    }
}
