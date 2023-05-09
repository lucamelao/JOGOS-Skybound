using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Overtime.FSM;

namespace Game.Player
{
  public class StateRun : StateBase {
    public StateRun (PlayerStateMachine stateMachine) : base (stateMachine) { }

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
      Debug.Log ("FixedUpdate Run");
    }

    public override void Update ()
    {
      Debug.Log ("Update Run");
    }
  }
}