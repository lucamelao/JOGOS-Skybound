using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Overtime.FSM;

namespace Game.Player
{
  public class Jump : StateBase {

    [SerializeField] private float jumpForce;
    public override void BuildTransitions ()
    {
      AddTransition (StateTransition.STOP_JUMP, StateID.FALL);
    }

    public override void Enter ()
    {
      Debug.Log ("Enter Jump");
      ApplyForce();
      MakeTransition(StateTransition.STOP_JUMP);
    }

    public override void Exit ()
    {
      Debug.Log ("Exit Jump");
    }

    public override void FixedUpdate ()
    {
      base.FixedUpdate();

    }

    public override void Update ()
    {
    }

    private void ApplyForce()
    {
      gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce);
    }
  }
}