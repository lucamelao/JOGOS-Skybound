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
      AddTransition (StateTransition.STOP_RUN, StateID.FALL);
      AddTransition (StateTransition.START_JUMP, StateID.JUMP);
    }
    public override void Enter ()
    {
      base.Enter();
      m_currentPressTransition = StateTransition.START_JUMP;
      m_Inputs.Player.Press.performed += OnPress;
      gameObject.GetComponent<Animator>().Play("Running");
    }

    public override void Exit ()
    {
      m_Inputs.Player.Press.performed -= OnPress;
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