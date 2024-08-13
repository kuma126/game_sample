using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField]
    private int rank;  // 店のランク
    private const int maxRank = 3;  // ランク上限　必要なら
    private int totalSales = 0;  // 総売り上げ

    //外観をmeshfilterとmaterialから変更
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

    // 販売一回
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
        // ランク上限あるなら
        if (rank < maxRank)
        {
            rank++;
        }
        meshFilter.mesh = meshs[rank - 1];
        meshRenderer.material = materials[rank - 1];
    }

    // 収益計算
    private int CalcSale()
    {
        int sale = rank * 1000;  // 適当な計算式
        return sale;
    }

    
}
