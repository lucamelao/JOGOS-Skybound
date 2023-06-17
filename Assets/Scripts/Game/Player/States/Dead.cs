using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Overtime.FSM;

namespace Game.Player
{
  public class Dead : StateBase {
    [SerializeField]
		private float idleTime, gravityScale;

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

      		gameObject.GetComponent<Animator>().speed = 0;
			gravityScale = gameObject.GetComponent<Rigidbody2D>().gravityScale;
			gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0);
		}

		public override void Exit () 
		{
		}

    public override void Continue()
    {
      StartCoroutine(WaitAndRun());
    }

		private IEnumerator WaitAndRun()
		{
			yield return new WaitForSeconds(idleTime);
      		gameObject.GetComponent<Animator>().speed = 1;
			gameObject.GetComponent<Rigidbody2D>().gravityScale = gravityScale;

			MakeTransition(StateTransition.START_FLY);
		}
	}
}