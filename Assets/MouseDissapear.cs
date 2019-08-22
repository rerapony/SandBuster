using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDissapear : MonoBehaviour
{
    public SpawnPoint point;
    private SpawnManager sm;
    private GameObject satan;
    public int scoreValue = 2;
    public int maxCounter = 2;
    private int counter;
    private AudioSource sandSound;
    private BonusManager bm;
    //private Animator animator;
    public Sprite[] sprites = new Sprite[3];
    public GameObject dust;
    //public Sprite spriteToChange;

    void Start()
    {
        //sm = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        satan = GameObject.Find("satan");
        sandSound = GameObject.Find("BonusManager").GetComponent<AudioSource>();
        bm = GameObject.Find("BonusManager").GetComponent<BonusManager>();
        //animator = gameObject.GetComponent<Animator>();
        dust = bm.dust;
        counter = 0;
       
    }

    void Update()
    {
        if (this.GetComponent<SpriteRenderer>().sprite == null)
        {
            this.GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = sprites[counter];
        }



        if (Input.GetMouseButtonDown(0))
        {
            
            Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 100f);
            if (hit.collider != null && OnTimeSatan.isSatan == false)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    counter += 1;
                    if (counter >= maxCounter)
                    {
                        Instantiate(dust, new Vector3(point.transform.position.x, point.transform.position.y-1f, point.transform.position.z), point.transform.rotation);
                        sandSound.Play(0);
                        ScoreManager.score += scoreValue;
                        Destroy(gameObject);
                        point.isOccupied = false;
                        bm.getBonus(point);
                        counter = 0;

                    }
                }
            }
            else if (hit.collider != null && OnTimeSatan.isSatan == true)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    GameObject.Find("SpawnManager").GetComponent<SpawnManager>().Lose();
                }
            }
        }
    }

}


    