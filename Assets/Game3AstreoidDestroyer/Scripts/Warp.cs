using UnityEngine;

public class Warp : MonoBehaviour
{
    private void Update()
    {
        Vector3 viewportPosition=Camera.main.WorldToViewportPoint(transform.position);
        Vector3 moveAdjustment=Vector3.zero;
        if (viewportPosition.x<0)
        {
            moveAdjustment.x+=1;
        }
        else if (viewportPosition.x>1)
        {
            moveAdjustment.x-=1;
        }
        else if (viewportPosition.y<0)
        {
            moveAdjustment.y+=1;
        }
        else if (viewportPosition.y>1)
        {
            moveAdjustment.y-=1;
        }

        transform.position=Camera.main.ViewportToWorldPoint(viewportPosition+moveAdjustment);
    }


    //
    //Aşağıdaki kod daha optimize olabilir.
    
    //  private Camera _mainCam;

    // void Start()
    // {
    //     _mainCam = Camera.main;
    // }

    // private void Update()
    // {
    //     Vector3 viewportPos = _mainCam.WorldToViewportPoint(transform.position);
    //     Vector3 adjustment = Vector3.zero;

    //     if (viewportPos.x < 0) adjustment.x += 1;
    //     if (viewportPos.x > 1) adjustment.x -= 1;
    //     if (viewportPos.y < 0) adjustment.y += 1;
    //     if (viewportPos.y > 1) adjustment.y -= 1;

    //     if (adjustment != Vector3.zero)
    //     {
    //         transform.position = _mainCam.ViewportToWorldPoint(viewportPos + adjustment);
    //     }
    // }
}
