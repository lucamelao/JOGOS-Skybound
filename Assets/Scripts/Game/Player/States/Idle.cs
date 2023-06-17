using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Overtime.FSM;

namespace Game.Player
{
  public class Idle : StateBase {
    [SerializeField]
		private float idleTime;

		public override void BuildTransitions ()
		{
			base.BuildTransitions();
			AddTransition(StateTransition.START_RUN, StateID.RUN);
		}

		public override void FixedUpdate ()
    {
      return;
    }

		public override void Enter ()
		{
			AudioManager audioManager = gameObject.GetComponent<AudioManager>();
			audioManager.PlaySound(6);
			StartCoroutine(WaitAndRun());
		}

		private IEnumerator WaitAndRun()
		{
			yield return new WaitForSeconds(idleTime);

			MakeTransition(StateTransition.START_RUN);
		}
	}
}