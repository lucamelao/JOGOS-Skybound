using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Overtime.FSM;

namespace Game.Player
{
  public class PlayerStateMachine : MonoBehaviour 
  {
    private StateMachine<PlayerStateMachine, StateID, StateTransition> m_FSM;
    public StateMachine<PlayerStateMachine, StateID, StateTransition> FSM
    {
      get { return m_FSM; }
    }
  }
}