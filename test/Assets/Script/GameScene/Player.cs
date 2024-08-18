using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField]
    FieldMaker fieldMaker;

    [SerializeField]
    private Vector3 defaultPosition;  // �����ʒu
    [SerializeField]
    private Vector3 defaultRotation;  // �����p�x

    private Vector3 startMousePos;
    private Vector3 preMousePos;
    private Vector3 prePosition;
    private Vector3 preRotation;
    [SerializeField]
    private float moveSpeed;    // ���s�ړ����x
    [SerializeField]
    private float rotateSpeed;  // ��]���x
    [SerializeField]
    private float zoomSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = defaultPosition;
        transform.eulerAngles = defaultRotation;
    }

    // Update is called once per frame
    void Update()
    {
        InputUpdate();
        
    }

    private void InputUpdate()
    {
        ObjectClick();
        MoveUpdate();
    }
    private void ObjectClick()
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

    private void MoveUpdate()
    {
        var leftClickDown = Input.GetMouseButtonDown(0);
        var leftClickDrag = Input.GetMouseButton(0);
        var rightClickDown = Input.GetMouseButtonDown(1);
        var rightClickDrag = Input.GetMouseButton(1);
        var centerClickDown = Input.GetMouseButtonDown(2);
        var centerClickDrag = Input.GetMouseButton(2);
        var scroll = Input.mouseScrollDelta.y;

        //  �ړ�
        //  �z�C�[���N���b�N�̃h���b�O���ړ�
        if (centerClickDown)
        {
            preMousePos = Input.mousePosition;
        }
        if (centerClickDrag)
        {
            var dx = (Input.mousePosition - preMousePos).x / Screen.width * moveSpeed;
            var dy = (Input.mousePosition - preMousePos).y / Screen.height * moveSpeed;

            transform.position += -transform.right * dx;
            transform.position += -transform.up * dy;

            preMousePos = Input.mousePosition;
        }

        //  ��]
        //  �E�N���b�N�̃h���b�O
        if (rightClickDown)
        {
            preMousePos = Input.mousePosition;
        }
        if (rightClickDrag)
        {
            var dx = (Input.mousePosition - preMousePos).x / Screen.width * rotateSpeed;
            var dy = (Input.mousePosition - preMousePos).y / Screen.height * rotateSpeed;
            transform.Rotate(0, dx, 0, Space.World);
            transform.Rotate(-dy, 0, 0);

            preMousePos = Input.mousePosition;
        }

        //  �Y�[��
        //  �z�C�[���ő���
        transform.position += transform.forward * scroll * zoomSpeed;

        Camera.main.gameObject.transform.SetPositionAndRotation(transform.position, transform.rotation);
    }
}
