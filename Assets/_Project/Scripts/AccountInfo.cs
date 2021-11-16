using System;
using System.Numerics;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class AccountInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text _accountNumber;
    [SerializeField] private TMP_Text _accountBalance;
    
    private CanvasGroup _canvasGroup;
    private string _chain = "ethereum";
    private string _network = "mainnet";
    private string _account;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private async void Start()
    {
        _account = PlayerPrefs.GetString("Account");
        _accountNumber.text = _account;
        
        var balanceDiv = BigInteger.Parse(await EVM.BalanceOf(_chain, _network, _account)) / 1000000000000000000;
        var balanceMod = BigInteger.Parse(await EVM.BalanceOf(_chain, _network, _account)) % 1000000000000000000;
        
        _accountBalance.text = $"{balanceDiv}.{balanceMod}";
    }

    public void Show()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
    }

    public void Hide()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
    }
}
