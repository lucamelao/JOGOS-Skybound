using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Overtime.FSM;

namespace Game.Player
{
  public class Fall : StateBase {
    public override void BuildTransitions ()
    {
      base.BuildTransitions();
      AddTransition (StateTransition.STOP_FALL, StateID.RUN);
      AddTransition (StateTransition.START_FLY, StateID.FLY);
    }

    public override void Enter ()
    {
      base.Enter();
      m_currentPressTransition = StateTransition.START_FLY;
      m_Inputs.Player.Press.performed += OnPress;
      gameObject.GetComponent<Animator>().Play("Falling");
      gameObject.GetComponent<PlayerStateMachine>().glider.SetActive(false);
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
      //DetectJump();
    }

    //check collision with tag platform
    public override void OnCollisionEnter2D(Collision2D col)
    {
      base.OnCollisionEnter2D(col);
      if(col.gameObject.tag == "Platform")
      {
        MakeTransition(StateTransition.STOP_FALL);
      }
      else if(col.gameObject.tag == "Floor" || col.gameObject.tag == "EOM" || col.gameObject.tag == "Spike" || col.gameObject.tag == "Wall")
      {
        MakeTransition(StateTransition.START_DEAD);
      }
    }
  }
}