using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Rigidbody2D myRigidbody;
	public float playerSpeed;
	private bool facingRight;

	public  Animator myAnimator;

	public static bool attack;

	public Transform[] groundPoints;
	public float groundRadius;
	public LayerMask whatIsGround;
	private bool isGrounded;
	private bool jump;
	public float jumpForce;

	public bool airControl;

	public static PlayerController singleton;

	public GameObject bulletToRight;
	public GameObject bulletToLeft;
	Vector2 bulletPos;
	public float fireRate = 0.5f;
	float nextFire = 0.0f;


	// Use this for initialization
	void Start () {
		facingRight = true;
		singleton = this;
		
	}

	void Update(){
		HandInput();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float horizontal = Input.GetAxis("Horizontal");
		isGrounded = IsGrounded();
		MovePlayer(horizontal);

		Flip(horizontal);	
		Attack();
		HandleLayers();

		reset();
	}

	private void MovePlayer(float horizontal){

		if (myRigidbody.velocity.y < 0) {
			myAnimator.SetBool("land",true);
		}
		if 	(!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack") && (isGrounded || airControl)){
		myRigidbody.velocity = new Vector2(horizontal * playerSpeed , myRigidbody.velocity.y);
		}

		if(isGrounded && jump){
			isGrounded = false;
			myRigidbody.AddForce(new Vector3(0,jumpForce,0), ForceMode2D.Impulse);
			myAnimator.SetTrigger("jump");
		}
		myAnimator.SetFloat("speed",Mathf.Abs(horizontal));
	}

	private void Attack(){
		if (attack && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack")){
			myAnimator.SetTrigger("attack");
			myRigidbody.velocity = Vector2.zero;
		}
	}

	private void HandInput(){

		if (Input.GetKeyDown(KeyCode.Space)){
			jump = true;
		}

		if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time > nextFire){
			nextFire = Time.time + fireRate;
			fire();
			attack = true;
		}
	}

	void fire(){
		bulletPos = transform.position;
		if (facingRight) {
			bulletPos += new Vector2(+1f, 0f);
			Instantiate(bulletToRight, bulletPos, Quaternion.identity);
		}else{
	
			bulletPos += new Vector2(-1f, 0f);
			Instantiate(bulletToLeft, bulletPos, Quaternion.identity);
		}
	}

	private void Flip(float horizontal){
		if (horizontal>0 && !facingRight || horizontal < 0 && facingRight ){
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *=-1;
			transform.localScale = theScale;
		}
	}

	private void reset(){
		attack =false;
		jump = false;
	}

	private bool IsGrounded(){
		if (myRigidbody.velocity.y <= 0){
			foreach (Transform point in groundPoints){
				Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

				for (int i =0; i < colliders.Length; i++){
					if( colliders[i].gameObject != gameObject){
						myAnimator.ResetTrigger("jump");
						myAnimator.SetBool("land", false);
						return true;
					}
				}
			}
		} return false;
	}

	private void HandleLayers(){
		if(!isGrounded){
			myAnimator.SetLayerWeight(1,1);
		}
		else{
			myAnimator.SetLayerWeight(1,0);
		}
	}
}
