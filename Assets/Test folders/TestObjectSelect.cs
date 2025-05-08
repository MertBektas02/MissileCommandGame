using System;
using UnityEngine;

public class TestObjectSelect : MonoBehaviour
{
    private GameObject selectedObject;
    private bool isObjectSelected=false;
    private Vector3 originalScale;


    private void Update()
    {
        SelectByMause();
    }

    private void SelectByMause()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mausePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit=Physics2D.Raycast(mausePos,Vector2.zero);
            if (hit.collider!=null)
            {
                SelectedObject(hit.collider.gameObject);
            }
            else
            {
                DeselectObject();
            }
        }
    }

    private void SelectedObject(GameObject obj)
    {
        selectedObject=obj;
        SpriteRenderer renderer=selectedObject.GetComponent<SpriteRenderer>();
        if (isObjectSelected==true)
        {
            
            return;
        }
        if (renderer!=null)
        {
            originalScale=selectedObject.transform.localScale;
            selectedObject.transform.localScale=originalScale*1.2f;
            //Debug.Log("objenin scale'i büyütüldü.");
            // renderer.color=Color.green;
            // Debug.Log("obje seçildi!");
            isObjectSelected=true;   
        }
        
    }
    private void DeselectObject()
    {
        if (selectedObject!=null)
        {
            SpriteRenderer renderer=selectedObject.GetComponent<SpriteRenderer>();
            if (renderer!=null)
            {
                selectedObject.transform.localScale=originalScale;
                isObjectSelected=false; 
                //Debug.Log("objenin scale'i orijinal boyutuna döndü.");
                // renderer.color=Color.white;
                // Debug.Log("obje seçimi kaldırıldı!");
            }
            selectedObject=null;
        }

    }
}
