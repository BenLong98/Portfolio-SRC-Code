using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMotor : MonoBehaviour {

    public AudioSource dingSource;

    public float speed;
    public Sprite[] walkanim;
    public Sprite idle;
    public Sprite idleFly;
    public float jumpSpeed;

    bool isMoving;
    bool isGrounded;
    public bool towardRight;
    public bool isMining = false;
  

  

    public GameObject player;

    public float IronValue, DiamondValue, GoldValue, StoneValue, CoalValue;

    public float playersMoney = 100.00f;
    Timer gameTime;

    StatsForItems SFI;


    RaycastHit2D hit;
     void Start()
    {
        gameTime = GetComponent<Timer>();
        SFI = GetComponent<StatsForItems>();
        dingSource = GetComponent<AudioSource>();
    }

    void Update () {

        if (gameTime.hasRunOutOfTime == true)
        {
            isMoving = false;
            isMining = false;
            isGrounded = true;

            SFI.GatherResources();

        }
        Rigidbody2D r2d = GetComponent<Rigidbody2D>();

        if (gameTime.hasRunOutOfTime == false)
        {
            r2d.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, r2d.velocity.y);
        }

        if (Input.GetAxis("Horizontal") > 0 && gameTime.hasRunOutOfTime == false) {
            towardRight = true;
        }if (Input.GetAxis("Horizontal") < 0 && gameTime.hasRunOutOfTime == false) {
            towardRight = false;
        }

        if (!towardRight) {
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponentInChildren<SpriteRenderer>().flipX = true;
            


        } else {
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponentInChildren<SpriteRenderer>().flipX = false;
      
        }

        if (r2d.velocity.magnitude > 0.1f) {
            if (!isMoving) {
                
                StartCoroutine(Move());
            }
        }

        hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down);

        if (hit.distance < .5f)
        {
            isGrounded = true;
        }
        else {
            isGrounded = false;
            GetComponent<SpriteRenderer>().sprite = idle;
        }

        if (isGrounded) {
            if (Input.GetKey(KeyCode.Space) && gameTime.hasRunOutOfTime == false)
            {
                r2d.velocity = new Vector2(r2d.velocity.x, jumpSpeed);
                // Flying animation starts here
                GetComponent<SpriteRenderer>().sprite = idleFly;
               
            }
        
        }


        if (Input.GetKeyUp(KeyCode.Escape)) {
            SceneManager.LoadScene("Main_Menu");
        }


        if (!isMoving) {
            GetComponent<SpriteRenderer>().sprite = idle;
        }

        

        if (Input.GetMouseButton(0) && gameTime.hasRunOutOfTime == false)
        {
          

      

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (hit.collider.gameObject == null){
                return;
            }


            if (hit.collider.gameObject != null)
            {
                isMining = true;

                float dist = Vector2.Distance(player.transform.position, hit.collider.gameObject.transform.position);

                if (hit.collider.gameObject.tag == "BedRock") {
                    return;
                }
                if (hit.collider.gameObject.name == "Player")
                {
                    return;
                }
                else if (dist < 2.3f)
                {
                    Debug.Log(dist);

                    if (hit.collider.gameObject.tag == "Iron") {
                        dingSource.Play();
                        playersMoney += IronValue;
                        SFI.moneyForIron += IronValue;
                        GetComponent<Inventory>().Add(1, 1);
                        GetComponent<Inventory>().AddMoneyToCounter(IronValue, true);

                    }
                    if (hit.collider.gameObject.tag == "Diamond")
                    {
                        dingSource.Play();
                        playersMoney += DiamondValue;
                        SFI.moneyForDiamond += DiamondValue;
                        GetComponent<Inventory>().Add(3, 1);
                        GetComponent<Inventory>().AddMoneyToCounter(DiamondValue, true);
                    }
                    if (hit.collider.gameObject.tag == "Gold")
                    {
                        dingSource.Play();
                        playersMoney += GoldValue;
                        SFI.moneyForGold += GoldValue;
                        GetComponent<Inventory>().Add(2, 1);
                        GetComponent<Inventory>().AddMoneyToCounter(GoldValue, true);
                    }
                    if (hit.collider.gameObject.tag == "Stone_Block")
                    {
                        
                        playersMoney -= StoneValue;
                        SFI.moneyForStone += StoneValue;
                        GetComponent<Inventory>().Add(0, 1);
                        GetComponent<Inventory>().AddMoneyToCounter(StoneValue, false);
                    }
                    if (hit.collider.gameObject.tag == "Coal")
                    {
                        dingSource.Play();
                        playersMoney += CoalValue;
                        SFI.moneyForCoal += CoalValue;
                        GetComponent<Inventory>().Add(4, 1);
                        GetComponent<Inventory>().AddMoneyToCounter(CoalValue, true);
                    }


                    Destroy(hit.collider.gameObject);
                }
                else
                {
                    return;
                }
            }
            else if (hit.collider.gameObject == null){
                Debug.Log("hit nothing");
            }
        }
        else {
            isMining = false;
            return;
        }

      
    }



    IEnumerator Move() {
      
            isMoving = true;
            //Walking ANIM

            GetComponent<SpriteRenderer>().sprite = walkanim[0];
            yield return new WaitForSeconds(0.15f);
            GetComponent<SpriteRenderer>().sprite = walkanim[1];
            yield return new WaitForSeconds(0.15f);

            isMoving = false;
        }



 

}


