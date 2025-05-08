using UnityEngine;

public class TestDragAndDrop : MonoBehaviour
{
    private bool isDragging=false;
    private void Update()
    {
        DragAndDropObject();
    }
    void DragAndDropObject()
    {
        Vector2 mausePos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D hit=Physics2D.OverlapPoint(mausePos);
            if (hit!=null&&hit.gameObject==this.gameObject)
            {
                isDragging=true;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragging=false;
        }
        if (isDragging==true)
        {
            transform.position=mausePos;
        }
    }
}
