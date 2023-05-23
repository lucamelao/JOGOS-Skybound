using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
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

    protected static GameInputs m_Inputs;
    protected static StateTransition m_currentPressTransition;
		public override void BuildTransitions ()
		{
			
		}

		public override void Enter ()
		{
			GetGameInput();
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

    public override void OnCollisionEnter2D (Collision2D collision) {}

    protected void GetGameInput()
    {
      if(m_Inputs == null)
      {
        m_Inputs = new GameInputs();
        m_Inputs.Player.Enable();
      }
    }

    protected void OnPress(InputAction.CallbackContext context)
    {
      MakeTransition(m_currentPressTransition);
    }
	}
}