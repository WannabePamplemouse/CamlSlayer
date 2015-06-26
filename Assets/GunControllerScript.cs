using UnityEngine;
using System.Collections;

public class GunControllerScript : MonoBehaviour {
	
	public float fireRate = 0;
	public float Damages = 10;
	public LayerMask whatToHit;
	public GameObject toshot;

	private float timeToFire = 0;
	private Transform gunPoint;

	GameObject player;
	Transform target;
	void Awake () 
	{
		gunPoint = GameObject.FindGameObjectWithTag ("MultiGun").gameObject.transform;
		Physics2D.IgnoreLayerCollision (8, gameObject.layer);
		if (gunPoint == null)
			Debug.Log ("No gun found");

		player = GameObject.FindWithTag ("Player");
		target = player.transform;
	}
	

	void Update () 
	{
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3, player.transform.position.z);
		if (fireRate == 0) 
		{
			if (Input.GetKeyDown (KeyCode.U))
				Shoot ();
		}
		else 
		{
			if(Input.GetKeyDown (KeyCode.U) && Time.time > timeToFire)
			{
				timeToFire = Time.time + 1/fireRate;
				Shoot();
			}
		}
	}

	private void Shoot()
	{
		Vector2 mousePos = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
		Vector2 firePos = new Vector2 (gunPoint.position.x, gunPoint.position.y);
		GameObject _shoot = (GameObject)Instantiate (toshot, transform.position, new Quaternion (0, 0, 0, 0));
		_shoot.rigidbody2D.velocity = ((mousePos - firePos) * 5);
		Debug.Log ("Mouse position in x = " + mousePos.x + "Mouse position in y = " + mousePos.y);
		//RaycastHit2D hit = Physics2D.Raycast (firePos, (mousePos - firePos), 100, whatToHit);
		//Debug.DrawLine (firePos, (mousePos - firePos) * 100, Color.cyan);
		/*Debug.Log ("Shooting dont know where");
		if (hit.collider != null) 
		{
			Debug.DrawLine(firePos, hit.point, Color.red);
			Debug.Log("We hit" + hit.collider.name);
		}
		/*Vector2 dir = (target.position - transform.position).normalized;
		GameObject shoot_bullet = (GameObject)Instantiate(toshot, transform.position, new Quaternion(0, 0, 0, 0));
		shoot_bullet.rigidbody2D.velocity = dir * 25;*/

	}
}
