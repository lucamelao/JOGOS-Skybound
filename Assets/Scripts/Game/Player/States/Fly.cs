using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Overtime.FSM;

namespace Game.Player
{
  public class Fly : StateBase {
    [SerializeField] private float airForceConstant;
    public override void BuildTransitions ()
    {
      base.BuildTransitions();
      AddTransition (StateTransition.STOP_FLY, StateID.FALL);
      AddTransition (StateTransition.START_RUN, StateID.RUN);
    }

    public override void Enter ()
    {
      base.Enter();
      m_currentPressTransition = StateTransition.STOP_FLY;
      m_Inputs.Player.Press.canceled += OnPress;
      gameObject.GetComponent<Animator>().Play("Gliding");
      gameObject.GetComponent<PlayerStateMachine>().glider.SetActive(true);
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
      else if(col.gameObject.tag == "Floor" || col.gameObject.tag == "EOM" || col.gameObject.tag == "Spike" || col.gameObject.tag == "Wall")
      {
        MakeTransition(StateTransition.START_DEAD);
      }
    }

    private void ApplyForce()
    {
      float velo = gameObject.GetComponent<Rigidbody2D>().velocity.y;
      float airForce;
      if (velo<0) {
        airForce = velo*velo * airForceConstant;
      } else {
        airForce = -velo*velo * airForceConstant;
      }
      gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * airForce);
    }
  }
}