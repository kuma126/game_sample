using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField]
    private int rank;               // �X�̃����N 0,1,2
    private const int maxRank = 2;  // �����N����@�K�v�Ȃ�
    private int totalSales = 0;     // ������グ

    [SerializeField]
    private GameObject[] storePrefabs;  // prefab
    private GameObject storeChild;      // �C���X�^���X�ێ�

    private ScoreManager scoreManager;  //  ���v�Ǘ��N���X

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        rank = 0;
        storeChild = Instantiate(storePrefabs[rank], transform.position, Quaternion.identity, this.gameObject.transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �̔����
    public void Sale()
    {
        var sales = CalcSale();
        totalSales += sales;
        scoreManager.AddScore(sales);
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
        if (rank >= maxRank) return;  // �����N���

        rank++;
        Destroy(storeChild);
        storeChild = Instantiate(storePrefabs[rank], transform.position, Quaternion.identity, this.gameObject.transform);
    }

    // ���v�v�Z
    private int CalcSale()
    {
        int sale = (rank + 1) * 1000;  // �K���Ȍv�Z��
        return sale;
    }

    
}
