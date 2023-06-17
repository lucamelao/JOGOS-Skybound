using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Modules
{
  public class Module : MonoBehaviour
  {
    public float Speed { get; set; }
    void OnTriggerEnter2D(Collider2D other)
    {
      if (other.gameObject.tag == "EOM")
      {
        Destroy(gameObject);
      }
    }

    void FixedUpdate()
    {
      Move();
    }

    private void Move()
    {
      transform.Translate(-transform.right * Time.deltaTime * Speed);
    }
  }
}