using UnityEngine;
using System.Collections;

public class FireMulti : MonoBehaviour {

    [SerializeField]
    private float time;
    [SerializeField]
    private int value;
    private float timer;

	private float lastSynchronizationTime = 0f;
	private float syncDelay = 0f;
	private float syncTime = 0f;
	private Vector3 syncStartPosition = Vector3.zero;
	private Vector3 syncEndPosition = Vector3.zero;

    private bool destroyable;

    // Use this for initialization
    void Start()
    {
        Physics2D.IgnoreLayerCollision(gameObject.layer, 10);
        Physics2D.IgnoreLayerCollision(gameObject.layer, gameObject.layer);
        GetComponent<AudioSource>().Play();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
		if (!networkView.isMine)
			SyncedMovement ();
		else 
		{
			timer += Time.deltaTime;
			if (timer >= time) 
			{
				Destroy (gameObject);
			}
		}
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            coll.gameObject.GetComponent<EnemyHealth>().TakeDamage(value);
            Destroy(gameObject);
        }
    }

	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
	{
		Vector3 syncPosition = Vector3.zero;
		Vector3 syncVelocity = Vector3.zero;
		if (stream.isWriting) {
			syncPosition = rigidbody2D.position;
			stream.Serialize (ref syncPosition);
			
			syncVelocity = rigidbody.velocity;
			stream.Serialize (ref syncVelocity);
		} 
		else {
			stream.Serialize(ref syncPosition);
			stream.Serialize(ref syncVelocity);
			
			syncTime = 0f;
			syncDelay = Time.time - lastSynchronizationTime;
			lastSynchronizationTime = Time.time;
			
			syncEndPosition = syncPosition + syncVelocity * syncDelay;
			syncStartPosition = rigidbody2D.position;
		}
	}

	private void SyncedMovement()
	{
		syncTime += Time.deltaTime;
		rigidbody.position = Vector3.Lerp (syncStartPosition, syncEndPosition, syncTime / syncDelay);
	}
}
