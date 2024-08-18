using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField]
    private int rank;               // 店のランク 0,1,2
    private const int maxRank = 2;  // ランク上限　必要なら
    private int totalSales = 0;     // 総売り上げ

    [SerializeField]
    private GameObject[] storePrefabs;  // prefab
    private GameObject storeChild;      // インスタンス保持


    // Start is called before the first frame update
    void Start()
    {
        rank = 0;
        storeChild = Instantiate(storePrefabs[rank], transform.position, Quaternion.identity, this.gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 販売一回
    public void Sale()
    {
        totalSales += CalcSale();
        Debug.Log(totalSales);
    }

    public int GetTotalSales()
    {
        return totalSales;
    }

    public void SetRank(int rank)
    {
        this.rank = rank;
    }

    public int GetRank()
    {
        return rank;
    }

    public void RankUp()
    {
        if (rank >= maxRank) return;  // ランク上限

        rank++;
        Destroy(storeChild);
        storeChild = Instantiate(storePrefabs[rank], transform.position, Quaternion.identity, this.gameObject.transform);
    }

    // 収益計算
    private int CalcSale()
    {
        int sale = (rank + 1) * 1000;  // 適当な計算式
        return sale;
    }

    
}
