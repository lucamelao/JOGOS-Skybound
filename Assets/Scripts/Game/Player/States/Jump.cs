using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Overtime.FSM;

namespace Game.Player
{
  public class Jump : StateBase {

    public override void BuildTransitions ()
    {
      base.BuildTransitions();
      AddTransition (StateTransition.STOP_JUMP, StateID.FALL);
    }

    public override void Enter ()
    {
      ApplyForce();
      MakeTransition(StateTransition.STOP_JUMP);
    }

    public override void Exit ()
    {
    }

    public override void FixedUpdate ()
    {
      base.FixedUpdate();

    }

    public override void Update ()
    {
    }

    public override void OnCollisionEnter2D (Collision2D col) 
    {
      if(col.gameObject.tag == "Floor" || col.gameObject.tag == "EOM" || col.gameObject.tag == "Spike" || col.gameObject.tag == "Wall")
      {
        MakeTransition(StateTransition.START_DEAD);
      }
    }

    private void ApplyForce()
    {
      gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * gameObject.GetComponent<PlayerStateMachine>().jumpForce);
    }
  }
}