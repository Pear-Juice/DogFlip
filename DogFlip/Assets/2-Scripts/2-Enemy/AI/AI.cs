using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour {
	NavMeshAgent agent;

	public Transform target;
	public float shootDistance; // min range to get to before agent stops moving towards and starts shooting
	public float turnSpeed;
	public Rigidbody bulletPrefab; // prefab to use for bullet instantiation
	public Transform gunBarrel; // point of firing bullets
	public float shootDelay;
	float shootTime = 0f;

	private void Awake() {
		agent = GetComponent<NavMeshAgent>();
	}

	private void Update() {
		// check if target in direct line of sight and within range
		if(Physics.Raycast(transform.position, target.position-transform.position, out RaycastHit hit, shootDistance) && hit.collider.tag=="Player") {
			agent.ResetPath(); // stop moving
			Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position, Vector3.up); // get look at target rotation
			transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime); // apply
			if(Quaternion.Angle(transform.rotation, targetRotation) < 15f && shootTime >= shootDelay) { // check if target inside viewcone
				Shoot();
			}
		} else {
			agent.SetDestination(target.position); // find path to target and move
		}
		shootTime += Time.deltaTime; // increase time since last shot
	}

	void Shoot() {
		Rigidbody bullet = Instantiate(bulletPrefab, gunBarrel.position, Quaternion.identity) as Rigidbody; // create bullet
		bullet.velocity = gunBarrel.forward * 20f; // make bullet go brrrmmm // * 1f; is hardcode, replace with variable!
		Destroy(bullet.gameObject, 3f); // give bullet lifetime, also hardcode!
		shootTime = 0f;
	}

	private void OnDrawGizmosSelected() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, shootDistance);
		Gizmos.color = Color.red;
		Gizmos.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * shootDistance);
	}
}
