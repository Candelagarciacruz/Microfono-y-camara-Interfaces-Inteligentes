using UnityEngine;

public class HumanoidsObserve : MonoBehaviour {
    public int type;
    public Transform shieldType1Objective;
    public float speed = 2f;
    
    private Rigidbody rb;
    private Transform objective;
    private bool move = false;

    private AudioSource audioSource;

    void Start() {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();  
    }

    // It runs every time the GameObject becomes active or the script is enabled.
    void OnEnable() {
        CubeNotifies.onType1 += ReactToType1;
        CubeNotifies.onType2 += ReactToType2;
    }

    // It runs when a script is disabled or the GameObject it's attached to is deactivated.
    void OnDisable() {
        CubeNotifies.onType1 -= ReactToType1;
        CubeNotifies.onType2 -= ReactToType2;
    }

    void ReactToType1() {
        if (type == 2) {
            GameObject[] shields = GameObject.FindGameObjectsWithTag("EscudoT2");
            if (shields.Length > 0) {
                objective = shields[Random.Range(0, shields.Length)].transform;
                move = true;
            }
        }
    }

    void ReactToType2() {
        if (type == 1) {
            objective = shieldType1Objective;
            move = (objective != null);
        }
    }

    // It runs before each physics update.
    void FixedUpdate() {
        if (move && objective != null && rb != null) {
            Vector3 direction = (objective.position - rb.position).normalized;
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("EscudoT1") || other.CompareTag("EscudoT2")) {
            if (audioSource != null && !audioSource.isPlaying) {
                audioSource.Play();
            }
            move = false;
        }
    }
}
