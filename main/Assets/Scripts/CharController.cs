using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CharController : MonoBehaviour
{				
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;

	private Rigidbody2D m_Rigidbody2D;

	// var de controle da direcao do player
	private bool m_FacingRight = true;
	private Vector3 m_Velocity = Vector3.zero;

	private void Awake()
	{
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{

	}

	public void Move(float hMove, float vMove)
	{
		// Move the character by finding the target velocity
		Vector3 targetVelocity = new Vector2(hMove * 10f, vMove * 10f);
		// And then smoothing it out and applying it to the character
		m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        // flipa o jogador
		if (hMove > 0 && !m_FacingRight)
		{
			Flip();
		}
		else if (hMove < 0 && m_FacingRight)
		{
			Flip();
		}

	}

	private void Flip()
	{
		// var de controle da direcao do player
		m_FacingRight = !m_FacingRight;

		// multiplica a escala x do jogador por -1
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}
