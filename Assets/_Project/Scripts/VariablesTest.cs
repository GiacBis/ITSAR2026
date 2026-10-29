using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class VariablesTest : MonoBehaviour
{
    [SerializeField] int shopIndex = 8;
    #region INCAPSULAMENTO
    //INCAPSULAMENTO - creiamo una variabile publica che riporta il valore della variabile private,
    //permettendo quindi di leggerne il valore fuori da questa classe neza doverlarendere public
    //altrimenti si potrebbe fare public int shopIndex (get; private set; ) rendendo così private la scrittura.
    //In questo modo però non si può serializzare per modificarla nell'inspector
    public int ShopIndex => shopIndex;
    // => funge da 'get'
    public void SetShopIndexValue(int _shopIndex)
    {
        if(shopStateBase != ShopState.CLOSING)
        {
            shopIndex = _shopIndex;
        }
    }
    #endregion
    [SerializeField] float shopRevenues = 50.5f;
    [SerializeField] bool shopOpen = false;
    private enum ShopState { OPENING, SELLING, RESTOCKING, CLOSING }
    [SerializeField] ShopState shopStateBase = ShopState.OPENING;
    [SerializeField] ShopState shopStateAdvanced = ShopState.RESTOCKING;
    [SerializeField] string shopName = "shopperone";
    //array bool+[] > nome variabile
    [SerializeField] int[] productArray = new int[5];
    [SerializeField] List<int> productList = new List<int>();
    //di base unity non permette di avere dictionary e HashSet come serializezefield editabile nell'inspector
    //keys = nome prodotto; float = prezzo prodotto
    Dictionary<string, float> productDictionary = new Dictionary<string, float>();
    HashSet<Product> productHashSet = new HashSet<Product>();
    //la classe product di base non è serializable quindi anche questa list non comparirà nell'inspector a meno di dichiarare la classe Product come serializable
    [SerializeField] List<Product> productsList = new List<Product>();

}

[Serializable]
public class Product
{
    public string Name;
    public float Price;
}