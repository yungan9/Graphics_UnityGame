using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
	[SerializeField]
	private GameObject tilePrefab;                              // ���� Ÿ�� ������
	[SerializeField]
	private Transform tilesParent;                          // Ÿ���� ��ġ�Ǵ� "Board" ������Ʈ�� Transform

	private List<Tile> tileList;							// ������ Ÿ�� ���� ����

	private Vector2Int puzzleSize = new Vector2Int(4, 4);       // 4x4 ����
	private float neighborTileDistance = 62;					// ������ Ÿ�� ������ �Ÿ�, ������ ����� ���� �ִ�.

	public Vector3 EmptyTilePosition { set; get; }				// �� Ÿ���� ��ġ

	private IEnumerator Start()
	{
		tileList = new List<Tile>();

		SpawnTiles();

		UnityEngine.UI.LayoutRebuilder.ForceRebuildLayoutImmediate(tilesParent.GetComponent<RectTransform>());

		// ���� �������� ����� ������ ���
		yield return new WaitForEndOfFrame();

		// tileList�� �ִ� ��� ����� SetCorrectPosition() �޼ҵ� ȣ��
		tileList.ForEach(x => x.SetCorrectPosition());

		StartCoroutine("OnSuffle");
	}

	private void SpawnTiles()
	{
		for (int y = 0; y < puzzleSize.y; ++y)
		{
			for (int x = 0; x < puzzleSize.x; ++x)
			{
				GameObject clone = Instantiate(tilePrefab, tilesParent);
				Tile tile = clone.GetComponent<Tile>();

				tile.Setup(this, puzzleSize.x * puzzleSize.y, y * puzzleSize.x + x + 1);

				tileList.Add(tile);
			}
		}
	}

	private IEnumerator OnSuffle()
	{
		float current = 0;
		float percent = 0;
		float time = 1.5f;

		while (percent < 1)
		{
			current += Time.deltaTime;
			percent = current / time;

			int index = Random.Range(0, puzzleSize.x * puzzleSize.y);
			tileList[index].transform.SetAsLastSibling();

			yield return null;
		}

		// ���� ���� ����� �ٸ� ����̾��µ� UI, GridLayoutGroup�� ����ϴٺ��� �ڽ��� ��ġ�� �ٲٴ� ������ ����
		// �׷��� ���� Ÿ�ϸ���Ʈ�� �������� �ִ� ��Ұ� ������ �� Ÿ��
		EmptyTilePosition = tileList[tileList.Count - 1].GetComponent<RectTransform>().localPosition;
	}

	public void IsMoveTile(Tile tile)
	{
		if (Vector3.Distance(EmptyTilePosition, tile.GetComponent<RectTransform>().localPosition) == neighborTileDistance)
		{
			Vector3 goalPosition = EmptyTilePosition;

			EmptyTilePosition = tile.GetComponent<RectTransform>().localPosition;

			tile.OnMoveTo(goalPosition);
		}
	}

	public void IsGameOver()
    {
		List<Tile> tiles = tileList.FindAll(x => x.IsCorrected == true);

		Debug.Log("Correct Count : " + tiles.Count);
		if ( tiles.Count == puzzleSize.x * puzzleSize.y - 1)
        {
			Debug.Log("GameClear");

			GetComponent<UIController>().OnResultPanel();
        }
    }
}
