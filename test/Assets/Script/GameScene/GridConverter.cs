using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridConverter : MonoBehaviour
{
    // ���[���h���W���O���b�h���W�ɕϊ�����
    public Vector3 CalcPosition(float worldX, float worldZ)
    {
        Vector3 gridPos = Vector3.zero;
        gridPos.x = (int)worldX;
        gridPos.z = (int)worldZ;
        return gridPos;
    }
}
