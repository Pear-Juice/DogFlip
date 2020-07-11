using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour {
	NavMeshAgent agent;

	public Transform target;
	public float shootDistance;

	int poolIndex = 0;
	public Transform bulletPoolRoot;

	private void Awake() {
		agent = GetComponent<NavMeshAgent>();
	}

	private void Update() {
		if(Physics.Raycast(transform.position, target.position-transform.position, out RaycastHit hit, shootDistance) && hit.collider.tag=="Player") {
			agent.ResetPath();
			//transform.LookAt(target);
			//Shoot();
		} else {
			agent.SetDestination(target.position);
		}
	}

	void Shoot() { // NEEDS WORK
		Rigidbody bullet = bulletPoolRoot.GetChild(poolIndex).GetComponent<Rigidbody>();
		bullet.gameObject.SetActive(true);
		bullet.position = transform.position + transform.forward * .3f;
		bullet.velocity = transform.forward * 1f;
		poolIndex = (int)Mathf.Repeat((float)poolIndex + 1, bulletPoolRoot.childCount);
	}

	private void OnDrawGizmosSelected() {
		Gizmos.DrawLine(transform.position, transform.position + transform.forward * shootDistance);
	}
}
