using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField]
    private int rank;  // �X�̃����N
    private const int maxRank = 3;  // �����N����@�K�v�Ȃ�
    private int totalSales = 0;  // ������グ

    //�O�ς�meshfilter��material����ύX
    [SerializeField]
    private Mesh[] meshs = new Mesh[maxRank];
    [SerializeField]
    private Material[] materials = new Material[maxRank];

    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;


    // Start is called before the first frame update
    void Start()
    {
        rank = 1;
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();

        meshFilter.mesh = meshs[rank - 1];
        meshRenderer.material = materials[rank - 1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �̔����
    public void Sale()
    {
        totalSales += CalcSale();
    }

    public int getTotalSales()
    {
        return totalSales;
    }

    public void setRank(int rank)
    {
        this.rank = rank;
    }

    public int getRank()
    {
        return rank;
    }

    public void RankUp()
    {
        // �����N�������Ȃ�
        if (rank < maxRank)
        {
            rank++;
        }
        meshFilter.mesh = meshs[rank - 1];
        meshRenderer.material = materials[rank - 1];
    }

    // ���v�v�Z
    private int CalcSale()
    {
        int sale = rank * 1000;  // �K���Ȍv�Z��
        return sale;
    }

    
}
