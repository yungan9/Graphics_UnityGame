using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
	[SerializeField]
	private GameObject resultPanel;
	[SerializeField]
	private Board board;

	public void OnResultPanel()
	{
		resultPanel.SetActive(true);
	}
}
