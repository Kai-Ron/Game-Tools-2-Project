using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDropController : MonoBehaviour
{
    public float pickUpDist = 5f;
    public LayerMask pickupLayerMask;
    public Transform grabPoint;
    private GameObject item;
    private Rigidbody itemRB;

    public KeyCode viewKey = KeyCode.LeftAlt;
    private bool view = false;

    void Update()
    {
        if (Input.GetKeyDown(viewKey))
        {   
            view = !view;
        }

        if (!view)
        {
            if(Input.GetMouseButtonDown(0) && item == null)
            {
                if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, pickUpDist, pickupLayerMask))
                {
                    item = hit.transform.gameObject;
                    if (item.GetComponent<Rigidbody>())
                    {
                        itemRB = item.GetComponent<Rigidbody>();
                        itemRB.useGravity = false;
                        //itemRB.drag = 10;
                    }
                }
            }
            else if(Input.GetMouseButtonDown(0) && item != null)
            {
                item = null;
                itemRB.useGravity = true;
                itemRB.drag = 0;
                itemRB = null;
            }
        }

        if (item != null)
        {
            //item.transform.position = grabPoint.position;
            itemRB.MovePosition(grabPoint.position);
        }
    }
}
