using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Overtime.FSM;

namespace Game.Player
{
  public class Run : StateBase {
    public override void BuildTransitions ()
    {
      base.BuildTransitions();
      AddTransition (StateTransition.STOP_RUN, StateID.FALL);
      AddTransition (StateTransition.START_JUMP, StateID.JUMP);
    }
    public override void Enter ()
    {
      base.Enter();
      m_currentPressTransition = StateTransition.START_JUMP;
      m_Inputs.Player.Press.performed += OnPress;
      gameObject.GetComponent<Animator>().Play("Running");
      gameObject.GetComponent<PlayerStateMachine>().glider.SetActive(false);
    }

    public override void Exit ()
    {
      m_Inputs.Player.Press.performed -= OnPress;
    }

    public override void OnCollisionEnter2D (Collision2D col) 
    {
      if(col.gameObject.tag == "Floor" || col.gameObject.tag == "EOM" || col.gameObject.tag == "Spike" || col.gameObject.tag == "Wall")
      {
        MakeTransition(StateTransition.START_DEAD);
      }
    }

    public override void FixedUpdate ()
    {
      base.FixedUpdate();
    }

    public override void Update ()
    {

    }
  }
}