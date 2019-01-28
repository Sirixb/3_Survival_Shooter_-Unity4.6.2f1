using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;

	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidbody;
	int floorMask;
	float camRayLength=100f;

	void Awake()
	{
		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent <Animator> ();
		playerRigidbody= GetComponent<Rigidbody> ();
	}
	void FixedUpdate()
	{
		float h = Input.GetAxisRaw ("Horizontal");//Axis raw me permite valores de -1,0 o 1
		float v = Input.GetAxisRaw ("Vertical");

		Move (h, v);
		Turning ();
		animating (h, v);
	}
	void Move(float h,float v)
	{
		movement.Set(h,0f,v);//el valor por defecto de movimiento es 1 por eso lo multiplicamos por speed.

		movement = movement.normalized * speed * Time.deltaTime;//delta time es el tiempo entre cada llamada de actualizacion.

		playerRigidbody.MovePosition (transform.position + movement);
	}
	void Turning()
	{
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit floorHit;

		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) 
		{
			Vector3 playerToMouse= floorHit.point-transform.position;
			playerToMouse.y=0f;

			Quaternion newRotation=Quaternion.LookRotation(playerToMouse);
			playerRigidbody.MoveRotation(newRotation);
		}
	}

	void animating(float h, float v)
	{
		bool walking = h != 0f || v != 0f;
		anim.SetBool ("IsWalking", walking);
	}
}
