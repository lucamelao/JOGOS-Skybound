using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
      Debug.Log ("Enter Run");
    }

    public override void Exit ()
    {
      Debug.Log ("Exit Run");
    }

    public override void FixedUpdate ()
    {
      base.FixedUpdate();
    }

    public override void Update ()
    {
      DetectJump();
    }

    private void DetectJump()
    {
      if(Input.GetKeyDown(KeyCode.Space))
      {
        MakeTransition(StateTransition.START_JUMP);
      }
    }
  }
}