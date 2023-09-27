using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class ObjectToInteract : MonoBehaviour
{
    Vector3 originalPos;
    Vector3 newPos;

    public float yFactor;
    public float speed;
    public bool hitted;
    public float timer;
    bool unlock;

    private void Start()
    {
        originalPos = transform.position;
        newPos = originalPos + new Vector3(0,yFactor,0);
    }

    private void Update()
    {
        if(hitted && !unlock)
        {
            StartCoroutine(CalcultateTime());
            MovePos();
        }

        else
        {
            if(unlock)
            {
                MovePos();
            }

            else
            {
                StopAllCoroutines();
                ResetPos();
            }
        }
    }
    public void MovePos()
    {
        transform.position = Vector3.MoveTowards(transform.position, newPos, speed * Time.deltaTime);
    }

    public void ResetPos()
    {
        Vector3 pos = transform.position;
        transform.position = Vector3.MoveTowards(pos, originalPos, speed * Time.deltaTime);
    }


    IEnumerator CalcultateTime()
    {
        unlock = false;
        yield return new WaitForSeconds(timer);
        unlock = true;
    }
}
