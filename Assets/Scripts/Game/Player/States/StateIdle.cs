namespace Game.Player
{
  public class StateIdle : StateBase {
    [SerializeField]
		private float idleTime;

		public override void BuildTransitions ()
		{
			AddTransition(StateTransition.START_RUN, StateID.RUN);
		}

		public override void Enter ()
		{
			StartCoroutine(WaitAndRun());
		}

		private IEnumerator WaitAndRun()
		{
			yield return new WaitForSeconds(idleTime);

			MakeTransition(StateTransition.START_RUN);
		}
	}
}