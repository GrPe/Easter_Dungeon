using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] private Quest quest;
    [SerializeField] private PlayerCollectingEggs player;

    [SerializeField] private Image questInfo;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI progress;
    

    private void Start()
    {
        questInfo.gameObject.SetActive(quest.isActive);
        player.OnCollectedEggs += UpdateUI;
        description.SetText(quest.description);
        progress.SetText($"{player.CollectedEggs}/{quest.eggsToCollect}");
    }

    private void UpdateUI()
    {
        progress.SetText($"{player.CollectedEggs}/{quest.eggsToCollect}");
    }
}
