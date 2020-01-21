using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitsController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
	{
		GameController.Instance.OnSuccessfulHit();
	}
}
