using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField]
    private int rank;  // 店のランク
    private const int maxRank = 5;  // ランク上限　必要なら
    private int totalSales = 0;  // 総売り上げ

    // sound
    /*
    AudioSource audioSource;
    [SerializeField]
    private AudioClip saleSound;
    */
    
    // Start is called before the first frame update
    void Start()
    {
        /*
        audioSource = GetComponent<AudioSource>();
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 販売一回
    public void Sale()
    {
        totalSales += CalcSale();
        //audioSource.PlayOneShot(saleSound);
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
        if (rank <= maxRank)
        {
            rank++;
        }
    }

    // 収益計算
    private int CalcSale()
    {
        int sale = rank * 1000;  // 適当な計算式
        return sale;
    }

    
}
