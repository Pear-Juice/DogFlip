using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour {
	NavMeshAgent agent;

	public Transform target;
	public float shootDistance;

	private void Awake() {
		agent = GetComponent<NavMeshAgent>();
	}

	private void Update() {
		if(Physics.Raycast(transform.position, target.position-transform.position, out RaycastHit hit, shootDistance) && hit.collider.tag=="Player") {
			agent.ResetPath();
			// shoot at target
		} else {
			agent.SetDestination(target.position);
		}
	}

	private void OnDrawGizmosSelected() {
		Gizmos.DrawLine(transform.position, transform.position + transform.forward * shootDistance);
	}
}
