using UnityEngine;

public class PlayerController3 : MonoBehaviour
{

    public Rigidbody playerRb;

    public Animator playerAnim;

    public ParticleSystem explosionParticle;

    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    private AudioSource playerAudio;
    public float jumpForce = 10f;
    public float gravityModifier;

    public bool isOnGround = true;

    public bool gameOver = false;

    void Start()
    {
        this.playerRb = GetComponent<Rigidbody>();
        this.playerAnim = GetComponent<Animator>();
        Physics.gravity *= this.gravityModifier;
        this.playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && this.isOnGround && !this.gameOver)

        {
            // Add force to the player in the upward direction
            this.playerRb.AddForce(Vector3.up * this.jumpForce, ForceMode.Impulse);
            this.isOnGround = false;
            this.playerAnim.SetTrigger("Jump_trig");
            this.playerAudio.PlayOneShot(this.jumpSound, 1.0f);
            this.dirtParticle.Stop();
        }
        
    }

    public void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Ground"))
        {
            this.isOnGround = true;
            this.dirtParticle.Play();

        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            this.gameOver = true;
            Debug.Log("Game Over");
            this.playerAnim.SetBool("Death_b", true);
            this.playerAnim.SetInteger("DeathType_int", 1);
            this.explosionParticle.Play();
            this.playerAudio.PlayOneShot(this.crashSound, 1.0f);
            this.dirtParticle.Stop();
        }

    }
}
