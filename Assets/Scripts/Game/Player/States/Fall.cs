using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Overtime.FSM;

namespace Game.Player
{
  public class Fall : StateBase {
    public override void BuildTransitions ()
    {
      AddTransition (StateTransition.STOP_FALL, StateID.RUN);
      AddTransition (StateTransition.START_FLY, StateID.FLY);
    }

    public override void Enter ()
    {
      base.Enter();
      Debug.Log ("Enter Fall");
      m_currentPressTransition = StateTransition.START_FLY;
      m_Inputs.Player.Press.performed += OnPress;
    }

    public override void Exit ()
    {
      m_Inputs.Player.Press.performed -= OnPress;
      Debug.Log ("Exit Fall");
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
      Debug.Log("Collision");
      if(col.gameObject.tag == "Platform")
      {
        MakeTransition(StateTransition.STOP_FALL);
      }
    }
  }
}