using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    FieldMaker fieldMaker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);
            RaycastHit closestHit = hits.OrderBy(hit => hit.distance).FirstOrDefault();
            if (closestHit.collider != null)
            {
                Vector3 hitPos = closestHit.point;
                fieldMaker.Click(hitPos);
            }
        }
    }
}
