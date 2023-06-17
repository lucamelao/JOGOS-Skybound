using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Overtime.FSM;

namespace Game.Player
{
  public class PlayerStateMachine : MonoBehaviour 
  {
	  public LevelManager m_LevelManager;
	  public float jumpForce = 300;
	  public GameObject glider;
    private StateMachine<PlayerStateMachine, StateID, StateTransition> m_FSM;
    public StateMachine<PlayerStateMachine, StateID, StateTransition> FSM
    {
      get { return m_FSM; }
    }
    public StateID m_InitialState;

		public ScriptableObject[] m_States;

		public bool m_Debug;

		void OnDestroy()
		{
			m_FSM.Destroy();
		}

		void Start()
		{
			m_FSM = new StateMachine<PlayerStateMachine, StateID, StateTransition>(this, m_States, m_InitialState, m_Debug);
		}

		void Update()
		{
			m_FSM.Update();
		}

		void FixedUpdate()
		{
			m_FSM.FixedUpdate();
		}

		void OnTriggerEnter(Collider col)
		{
			m_FSM.OnTriggerEnter(col);
		}

		void OnCollisionEnter2D(Collision2D col)
		{
			m_FSM.OnCollisionEnter2D(col);
			if(col.gameObject.tag == "Floor" || col.gameObject.tag == "EOM" || col.gameObject.tag == "Spike" || col.gameObject.tag == "Wall")
      {
        SetStop();
				EndGame();
      }
		}
		void Continue()
		{
			gameObject.GetComponent<Transform>().position = new Vector3(-4, 5, 0);
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
			m_FSM.Continue();
			SetContinue();
		}

		void EndGame()
		{
			m_LevelManager.EndGame();
		}

		void SetStop()
		{
			m_LevelManager.SetStop();
		}

		void SetContinue()
		{
			m_LevelManager.SetContinue();
		}

		#if UNITY_EDITOR
		void OnGUI()
		{
			if(m_Debug)
			{
				GUI.color = Color.white;
				GUI.Label(new Rect(0.0f, 0.0f, 500.0f, 500.0f), string.Format("Example State: {0}", FSM.CurrentStateName));
			}
		}
		#endif
  }
}