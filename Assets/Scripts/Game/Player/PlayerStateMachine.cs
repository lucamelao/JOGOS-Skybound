using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Overtime.FSM;

namespace Game.Player
{
  public class PlayerStateMachine : MonoBehaviour 
  {
	  public LevelManager m_LevelManager;
		public AdButton adButton;
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
			if(m_FSM.CurrentState.StateID == StateID.DEAD) return;
			m_FSM.OnCollisionEnter2D(col);
			if(col.gameObject.tag == "Floor" || col.gameObject.tag == "EOM" || col.gameObject.tag == "Spike" || col.gameObject.tag == "Wall")
      {
        SetStop();
				StartCoroutine(Waiter());
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
			adButton.Init();
		}

		void SetContinue()
		{
			m_LevelManager.SetContinue();
		}


	IEnumerator Waiter()
	{	
			//Wait for 1 seconds
			int t = 0;
			while(adButton.adState == AdState.None) 
			{
				if(t > 100) {
					EndGame();
					yield break;
				}
				yield return new WaitForSeconds(0.1f);
				t++;
			}
			if(adButton.adState == AdState.Skipped) {
				EndGame();
				yield break;
			}
			StartCoroutine(IsWatchingAd());
	}

	IEnumerator IsWatchingAd()
	{
		int t = 0;
		while(adButton.adState == AdState.Watching) 
		{
			if(t > 100) {
				EndGame();
				yield break;
			}
			yield return new WaitForSeconds(0.1f);
			t++;
		}
		if(adButton.adState == AdState.Completed) Continue();
		else EndGame();
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