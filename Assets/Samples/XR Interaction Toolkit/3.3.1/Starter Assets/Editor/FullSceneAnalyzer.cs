using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Text;

public class FullSceneAnalyzer : EditorWindow
{
    [MenuItem("Tools/Full Scene Analyzer")]
    public static void ShowWindow()
    {
        GetWindow<FullSceneAnalyzer>("Full Analyzer");
    }

    void OnGUI()
    {
        if (GUILayout.Button("Analyze Scene"))
        {
            Analyze();
        }
    }

    void Analyze()
    {
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        int totalObjects = allObjects.Length;
        int meshObjects = 0;
        int totalTriangles = 0;
        int heroAssets = 0;
        int audioSources = 0;
        int canvases = 0;

        Dictionary<string, int> meshCounts = new Dictionary<string, int>();
        HashSet<Texture> textures = new HashSet<Texture>();

        StringBuilder perObjectReport = new StringBuilder();
        perObjectReport.AppendLine("===== PER OBJECT TRIANGLE REPORT =====");

        foreach (GameObject obj in allObjects)
        {
            // AUDIO
            if (obj.GetComponent<AudioSource>() != null)
                audioSources++;

            // UI
            if (obj.GetComponent<Canvas>() != null)
                canvases++;

            // MESH
            MeshFilter mf = obj.GetComponent<MeshFilter>();
            if (mf != null && mf.sharedMesh != null)
            {
                meshObjects++;

                int tris = mf.sharedMesh.triangles.Length / 3;
                totalTriangles += tris;

                string meshName = mf.sharedMesh.name;

                // count mesh usage
                if (meshCounts.ContainsKey(meshName))
                    meshCounts[meshName]++;
                else
                    meshCounts[meshName] = 1;

                // PER OBJECT OUTPUT (IMPORTANT FOR REPORT)
                perObjectReport.AppendLine($"{obj.name} ({meshName}) → {tris} tris");

                // HERO DETECTION
                if (tris >= 5000)
                {
                    heroAssets++;
                    perObjectReport.AppendLine($"⭐ HERO ASSET: {obj.name} → {tris} tris");
                }
            }

            // TEXTURES
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                foreach (Material mat in renderer.sharedMaterials)
                {
                    if (mat != null && mat.mainTexture != null)
                        textures.Add(mat.mainTexture);
                }
            }
        }

        // SORT meshes by repetition
        var sortedMeshes = new List<KeyValuePair<string, int>>(meshCounts);
        sortedMeshes.Sort((a, b) => b.Value.CompareTo(a.Value));

        // FINAL REPORT
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("===== FULL SCENE ANALYSIS =====");
        sb.AppendLine($"Total Objects: {totalObjects}");
        sb.AppendLine($"Mesh Objects: {meshObjects}");
        sb.AppendLine($"Unique Meshes: {meshCounts.Count}");
        sb.AppendLine($"Total Triangles: {totalTriangles}");
        sb.AppendLine($"Hero Assets (5000+ tris): {heroAssets}");
        sb.AppendLine($"Audio Sources: {audioSources}");
        sb.AppendLine($"UI Canvases: {canvases}");
        sb.AppendLine("──────────────────────────");

        sb.AppendLine("Top Used Meshes:");
        foreach (var entry in sortedMeshes)
        {
            sb.AppendLine($"{entry.Key}: {entry.Value}");
        }

        sb.AppendLine("──────────────────────────");

        sb.AppendLine("Textures:");
        foreach (Texture tex in textures)
        {
            sb.AppendLine($"{tex.name} → {tex.width}x{tex.height}");
        }

        sb.AppendLine("──────────────────────────");

        // ADD PER OBJECT REPORT (NEW IMPORTANT PART)
        sb.Append(perObjectReport);

        Debug.Log(sb.ToString());
    }
}