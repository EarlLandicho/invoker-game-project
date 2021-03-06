﻿#region

using TMPro;
using UnityEngine;

#endregion

public class SpiritUI : MonoBehaviour
{
	private TextMeshProUGUI displaySpiritCurrentAmount1UI;
	private TextMeshProUGUI displaySpiritCurrentAmount2UI;
	private TextMeshProUGUI displaySpiritCurrentAmount3UI;
	private SpiritArrayManager spiritArrayManager;

	//Maybe in Start because it's UI?
	private void Awake()
	{
		spiritArrayManager = GameObject.Find("GameManager").GetComponent<SpiritArrayManager>();
		displaySpiritCurrentAmount1UI = GameObject.Find("CurrentSpiritAmount1UI").GetComponent<TextMeshProUGUI>();
		displaySpiritCurrentAmount2UI = GameObject.Find("CurrentSpiritAmount2UI").GetComponent<TextMeshProUGUI>();
		displaySpiritCurrentAmount3UI = GameObject.Find("CurrentSpiritAmount3UI").GetComponent<TextMeshProUGUI>();
	}

	private void LateUpdate()
	{
		UpdateSpiritCurrentAmount();
	}

	private void UpdateSpiritCurrentAmount()
	{
		displaySpiritCurrentAmount1UI.text = spiritArrayManager.GetSpiritCurrentAmount(1).ToString();
		displaySpiritCurrentAmount2UI.text = spiritArrayManager.GetSpiritCurrentAmount(2).ToString();
		displaySpiritCurrentAmount3UI.text = spiritArrayManager.GetSpiritCurrentAmount(3).ToString();
		;
	}
}