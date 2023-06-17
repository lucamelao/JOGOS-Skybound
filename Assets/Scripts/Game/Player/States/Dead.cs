using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Overtime.FSM;

namespace Game.Player
{
  public class Dead : StateBase {
    [SerializeField]
		private float idleTime;

		public override void BuildTransitions ()
		{
      //base.BuildTransitions();
			AddTransition(StateTransition.START_FLY, StateID.FLY);
		}

		public override void FixedUpdate ()
    {
      return;
    }

		public override void Enter ()
		{
			AudioManager audioManager = gameObject.GetComponent<AudioManager>();
			audioManager.PlaySound(4);
			audioManager.PlaySound(3);

			audioManager.PlaySound(7);

      		// gameObject.GetComponent<PlayerStateMachine>().glider.SetActive(false);
			// gameObject.SetActive(false);
		}

    public override void Continue()
    {
		gameObject.SetActive(true);
      StartCoroutine(WaitAndRun());
    }

		private IEnumerator WaitAndRun()
		{
			yield return new WaitForSeconds(idleTime);

			MakeTransition(StateTransition.START_FLY);
		}
	}
}