using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField]
    private int rank;  // �X�̃����N
    private const int maxRank = 5;  // �����N����@�K�v�Ȃ�
    private int totalSales = 0;  // ������グ

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

    // �̔����
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
        // �����N�������Ȃ�
        if (rank <= maxRank)
        {
            rank++;
        }
    }

    // ���v�v�Z
    private int CalcSale()
    {
        int sale = rank * 1000;  // �K���Ȍv�Z��
        return sale;
    }

    
}
