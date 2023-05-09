using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Overtime.FSM;

namespace Game.Player
{
	public enum StateID
  {
    IDLE,
    RUN,
    JUMP,
    FALL,
    LAND,
    FLY,
  }

	public enum StateTransition
  {
    START_RUN,
    STOP_RUN,
    START_JUMP,
    STOP_JUMP,
    START_FALL,
    STOP_FALL,
    START_LAND,
    STOP_LAND,
    START_FLY,
    STOP_FLY,
  }

	public abstract class StateBase : State<PlayerStateMachine, StateID, StateTransition>
	{
		public override void BuildTransitions ()
		{
			
		}

		public override void Enter ()
		{
			
		}

		public override void Exit ()
		{
			
		}

		public override void FixedUpdate ()
		{
			
		}

		public override void Update ()
		{
			
		}
	}
}