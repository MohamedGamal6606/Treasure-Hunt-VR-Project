using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class SceneAssetCounter : MonoBehaviour
{
    void Start()
    {
        GameObject[] allObjects = FindObjectsByType<GameObject>(FindObjectsSortMode.None);

        Dictionary<string, int> nameCounts = new Dictionary<string, int>();

        foreach (GameObject obj in allObjects)
        {
            // Strip trailing " (1)", " (2)", etc. to group duplicates together
            string baseName = Regex.Replace(obj.name, @"\s*\(\d+\)$", "").Trim();

            if (nameCounts.ContainsKey(baseName))
                nameCounts[baseName]++;
            else
                nameCounts[baseName] = 1;
        }

        // Sort by count descending
        var sorted = new List<KeyValuePair<string, int>>(nameCounts);
        sorted.Sort((a, b) => b.Value.CompareTo(a.Value));

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.AppendLine("=== Scene Object Count ===");
        sb.AppendLine($"Total Unique Assets: {sorted.Count}");
        sb.AppendLine("──────────────────────────");

        foreach (var entry in sorted)
            sb.AppendLine($"{entry.Key}: {entry.Value}");

        Debug.Log(sb.ToString());
    }
}