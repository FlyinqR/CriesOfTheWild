<<<<<<< Updated upstream
using UnityEngine;
using System.Collections;
=======
﻿using UnityEngine;
using System.Collections;
using UnityEngine.TextCore.LowLevel;
>>>>>>> Stashed changes


namespace TMPro.Examples
{
<<<<<<< Updated upstream
    
    public class Benchmark03 : MonoBehaviour
    {

        public int SpawnType = 0;
        public int NumberOfNPC = 12;

        public Font TheFont;

        //private TextMeshProFloatingText floatingText_Script;
=======

    public class Benchmark03 : MonoBehaviour
    {
        public enum BenchmarkType { TMP_SDF_MOBILE = 0, TMP_SDF__MOBILE_SSD = 1, TMP_SDF = 2, TMP_BITMAP_MOBILE = 3, TEXTMESH_BITMAP = 4 }

        public int NumberOfSamples = 100;
        public BenchmarkType Benchmark;

        public Font SourceFont;

>>>>>>> Stashed changes

        void Awake()
        {

        }


        void Start()
        {
<<<<<<< Updated upstream
            for (int i = 0; i < NumberOfNPC; i++)
            {
                if (SpawnType == 0)
                {
                    // TextMesh Pro Implementation
                    //go.transform.localScale = new Vector3(2, 2, 2);
                    GameObject go = new GameObject(); //"NPC " + i);
                    //go.transform.position = new Vector3(Random.Range(-95f, 95f), 0.5f, Random.Range(-95f, 95f));

                    go.transform.position = new Vector3(0, 0, 0);
                    //go.renderer.castShadows = false;
                    //go.renderer.receiveShadows = false;
                    //go.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);

                    TextMeshPro textMeshPro = go.AddComponent<TextMeshPro>();
                    //textMeshPro.FontAsset = Resources.Load("Fonts & Materials/LiberationSans SDF", typeof(TextMeshProFont)) as TextMeshProFont;
                    textMeshPro.alignment = TextAlignmentOptions.Center;
                    textMeshPro.fontSize = 96;

                    textMeshPro.text = "@";
                    textMeshPro.color = new Color32(255, 255, 0, 255);
                    //textMeshPro.Text = "!";


                    // Spawn Floating Text
                    //floatingText_Script = go.AddComponent<TextMeshProFloatingText>();
                    //floatingText_Script.SpawnType = 0;
                }
                else
                {
                    // TextMesh Implementation
                    GameObject go = new GameObject(); //"NPC " + i);
                    //go.transform.position = new Vector3(Random.Range(-95f, 95f), 0.5f, Random.Range(-95f, 95f));

                    go.transform.position = new Vector3(0, 0, 0);

                    TextMesh textMesh = go.AddComponent<TextMesh>();
                    textMesh.GetComponent<Renderer>().sharedMaterial = TheFont.material;
                    textMesh.font = TheFont;
                    textMesh.anchor = TextAnchor.MiddleCenter;
                    textMesh.fontSize = 96;

                    textMesh.color = new Color32(255, 255, 0, 255);
                    textMesh.text = "@";

                    // Spawn Floating Text
                    //floatingText_Script = go.AddComponent<TextMeshProFloatingText>();
                    //floatingText_Script.SpawnType = 1;
=======
            TMP_FontAsset fontAsset = null;

            // Create Dynamic Font Asset for the given font file.
            switch (Benchmark)
            {
                case BenchmarkType.TMP_SDF_MOBILE:
                    fontAsset = TMP_FontAsset.CreateFontAsset(SourceFont, 90, 9, GlyphRenderMode.SDFAA, 256, 256, AtlasPopulationMode.Dynamic);
                    break;
                case BenchmarkType.TMP_SDF__MOBILE_SSD:
                    fontAsset = TMP_FontAsset.CreateFontAsset(SourceFont, 90, 9, GlyphRenderMode.SDFAA, 256, 256, AtlasPopulationMode.Dynamic);
                    fontAsset.material.shader = Shader.Find("TextMeshPro/Mobile/Distance Field SSD");
                    break;
                case BenchmarkType.TMP_SDF:
                    fontAsset = TMP_FontAsset.CreateFontAsset(SourceFont, 90, 9, GlyphRenderMode.SDFAA, 256, 256, AtlasPopulationMode.Dynamic);
                    fontAsset.material.shader = Shader.Find("TextMeshPro/Distance Field");
                    break;
                case BenchmarkType.TMP_BITMAP_MOBILE:
                    fontAsset = TMP_FontAsset.CreateFontAsset(SourceFont, 90, 9, GlyphRenderMode.SMOOTH, 256, 256, AtlasPopulationMode.Dynamic);
                    break;
            }

            for (int i = 0; i < NumberOfSamples; i++)
            {
                switch (Benchmark)
                {
                    case BenchmarkType.TMP_SDF_MOBILE:
                    case BenchmarkType.TMP_SDF__MOBILE_SSD:
                    case BenchmarkType.TMP_SDF:
                    case BenchmarkType.TMP_BITMAP_MOBILE:
                        {
                            GameObject go = new GameObject();
                            go.transform.position = new Vector3(0, 1.2f, 0);

                            TextMeshPro textComponent = go.AddComponent<TextMeshPro>();
                            textComponent.font = fontAsset;
                            textComponent.fontSize = 128;
                            textComponent.text = "@";
                            textComponent.alignment = TextAlignmentOptions.Center;
                            textComponent.color = new Color32(255, 255, 0, 255);

                            if (Benchmark == BenchmarkType.TMP_BITMAP_MOBILE)
                                textComponent.fontSize = 132;

                        }
                        break;
                    case BenchmarkType.TEXTMESH_BITMAP:
                        {
                            GameObject go = new GameObject();
                            go.transform.position = new Vector3(0, 1.2f, 0);

                            TextMesh textMesh = go.AddComponent<TextMesh>();
                            textMesh.GetComponent<Renderer>().sharedMaterial = SourceFont.material;
                            textMesh.font = SourceFont;
                            textMesh.anchor = TextAnchor.MiddleCenter;
                            textMesh.fontSize = 130;

                            textMesh.color = new Color32(255, 255, 0, 255);
                            textMesh.text = "@";
                        }
                        break;
>>>>>>> Stashed changes
                }
            }
        }

    }
}
