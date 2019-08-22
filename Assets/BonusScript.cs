using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusScript : MonoBehaviour
{
    protected SpawnPoint point;
    //private GameObject dust;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 100f);
            if (hit.collider != null && OnTimeSatan.isSatan == false)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    BonusPick();
                }
            }
        }
    }
    public void BonusCore(SpawnPoint point, float BonusTime)
    {
        this.point = point;
        StartCoroutine(BonusDisappear(BonusTime));

       
    }

    public IEnumerator BonusDisappear(float BonusTime)
    {

        Debug.Log("IM HERE");
        var spawners = GameObject.Find("SpawnManager").GetComponent<SpawnManager>().spawners;
        yield return new WaitForSeconds(BonusTime);
        Destroy(gameObject);
        point.isOccupied = false;
    }

    public virtual void BonusPick()
    {
        point.isOccupied = false;
        //GameObject.Find("SpawnManager").GetComponent<SpawnManager>().squareNumber -= 1;
        Destroy(gameObject);
    }
}
