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
      base.SetStop();
      Debug.Log("Dead!!!");
		}

    public override void Continue()
    {
      StartCoroutine(WaitAndRun());
    }

		private IEnumerator WaitAndRun()
		{
			yield return new WaitForSeconds(idleTime);

			MakeTransition(StateTransition.START_FLY);
		}
	}
}