using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Overtime.FSM;

namespace Game.Player
{
  public class Fly : StateBase {
    [SerializeField] private float glideForce;
    public override void BuildTransitions ()
    {
      AddTransition (StateTransition.STOP_FLY, StateID.FALL);
      AddTransition (StateTransition.START_RUN, StateID.RUN);
    }

    public override void Enter ()
    {
      base.Enter();
      m_currentPressTransition = StateTransition.STOP_FLY;
      m_Inputs.Player.Press.canceled += OnPress;
    }

    public override void Exit ()
    {
      m_Inputs.Player.Press.canceled -= OnPress;
    }

    public override void FixedUpdate ()
    {
      base.FixedUpdate();
      ApplyForce();

    }

    public override void Update ()
    {
      //DetectJump();
    }

    //check collision with tag platform
    public override void OnCollisionEnter2D(Collision2D col)
    {
      base.OnCollisionEnter2D(col);
      if(col.gameObject.tag == "Platform")
      {
        MakeTransition(StateTransition.START_RUN);
      }
    }

    private void ApplyForce()
    {
      gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * glideForce);
    }
  }
}