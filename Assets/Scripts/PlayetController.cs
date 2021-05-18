using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayetController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playAudio;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent <Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        dirtParticle.Stop();
        playAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
          playerRb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
          isOnGround=false;  
          playerAnim.SetTrigger("Jump_trig");
          dirtParticle.Stop();
          playAudio.PlayOneShot(jumpSound,1.0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            dirtParticle.Play();
            isOnGround=true;
        }else if (collision.gameObject.CompareTag("Barrier"))
        {
            playAudio.PlayOneShot(crashSound,1.0f);
            dirtParticle.Stop();
            gameOver=true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int",1);
            explosionParticle.Play();
        }
    }
}
