using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTimeSatan : MonoBehaviour
    
{
    //public GameObject satan;
    public static bool isSatan = false;
    public float minSatan = 20f;
    public float maxSatan = 40f;
    private int maxCounter = 3;
    private int counter;
    private bool startGame;
    Animator animator;
    Animator child_animator;
    AudioSource roar;
    private GameObject child;
    public int childTime = 5;
    public Sprite[] sprites;
    private SpriteRenderer spriteR;
    // Start is called before the first frame update
    void Start()
    {
        child = GameObject.Find("child");
        child_animator = child.GetComponent<Animator>();
        animator = GetComponent<Animator>();
        counter = 0;
        StartCoroutine("SatanStart");
        roar = gameObject.GetComponent<AudioSource>();
        spriteR = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && OnTimeSatan.isSatan == true)
        {
            Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 100f);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    counter += 1;
                    if (counter >= maxCounter)
                    {
                        StartCoroutine("SatanPeriod");
                        counter = 0;
                    }
                }
            }
        }
        
    }

    private void OnMouseDown()
    {
        spriteR.sprite = sprites[1];
    }

    private void OnMouseUp()
    {
        spriteR.sprite = sprites[0];
    }

    public void satanIn()
    {
        animator.SetBool("isSatan", true);
        roar.Play();
    }

    public void changeSatan()
    {
        isSatan = !isSatan;
    }

    public void satanOut()
    {
        animator.SetBool("isSatan", false);
    }
    

    IEnumerator SatanPeriod()
    {
        satanOut();
        yield return SatanStart();
    }

    IEnumerator SatanStart()
    {
        yield return new WaitForSeconds(Random.Range(minSatan - childTime, maxSatan - childTime));
        child_animator.SetBool("isCrying", true);
        child.GetComponent<AudioSource>().Play(0);
        yield return new WaitForSeconds(childTime);
        child_animator.SetBool("isCrying", false);
        satanIn();
    }

}
