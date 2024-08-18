using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static Unity.Collections.AllocatorManager;

public class Consumer : MonoBehaviour
{
    // fieldmakerから情報を受け取り，屋台に隣接したときにお金を使うか決める
    // 移動→お金使うか確認のループ　
    // 花火を上げれば上げるほどスピードが遅くなるぞ
    // private int money = 10000;  //客の所持金 いらないかも
    private Vector3 myGridPos; // 客のグリッド位置
    private bool isBuying;
    private Transform myTransform = null;
    FieldMaker fieldMaker; // フィールド情報を取得するため最初にもってくる
    Store currentStore; // 取引する店
    GridConverter gridConverter;

    private void Awake()
    {
        myGridPos = Vector3.zero;
        myTransform = this.gameObject.transform;
        fieldMaker = GameObject.Find("FieldMaker").GetComponent<FieldMaker>() ;
        gridConverter = new GridConverter();
    }

    void Update()
    {
        checkGridPos();
        Move();

    }

    void BuySomething()
    {
        isBuying = true;
        currentStore.Sale();
    }

    void Move()
    {
        // 道を見て移動する
        transform.Translate(0.0f, 0.0f, 0.001f);

        if (isBuying)
        {
            return;
        }

        // 店に隣接しているか？
        GameObject store;
        store = null;

        // 上下左右確認
        var dx = new int[4] { 0, -1, 0, 1 };
        var dz = new int[4] { 1, 0, -1, 0 };
        for (int i = 0; i < 4; i++) //一マスで買い物できるのは1個までってことで
        {
            Vector3 checkGrid = Vector3.zero;
            var newX = myGridPos.x + dx[i];
            var newZ = myGridPos.z + dz[i];
            checkGrid.x = newX;
            checkGrid.z = newZ;
            store = fieldMaker.GetStore(checkGrid); // 店チェック
            if (store != null)
            {
                currentStore = store.GetComponent<Store>();
                //購入するか？
                bool buyFlag = true;
                if (buyFlag)
                {
                    BuySomething();
                    break;
                }
            }
        }
    }

    /*
    @brief グリッド位置を更新する 
    */
    void checkGridPos()
    {
        Vector3 newPos;
        newPos = gridConverter.CalcPosition(myTransform.position.x, myTransform.position.z);

        // グリッド位置が変わったなら
        if(newPos.x != myGridPos.x || newPos.z != myGridPos.z)
        {
            isBuying = false;
        }

        myGridPos = newPos;
    }
}
