using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Es.InkPainter.Effective;
using UnityEngine.Rendering;

#if UNITY_EDITOR

using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;

#endif

namespace Es.InkPainter
{

    /// <summary>
    /// Texture paint to canvas.
    /// To set the per-material.
    /// </summary>
    [RequireComponent(typeof(Renderer))]
    [DisallowMultipleComponent]
    public class InkCanvas : MonoBehaviour
    {
        [Serializable]
        public class PaintSet
        {

            /// <summary>
            /// Applying paint materials.
            /// </summary>
            [HideInInspector]
            [NonSerialized]
            public Material material;

            [SerializeField, Tooltip("The property name of the main texture.")]
            public string mainTextureName = "_MainTex";

            [SerializeField, Tooltip("Normal map texture property name.")]
            public string normalTextureName = "_BumpMap";

            [SerializeField, Tooltip("The property name of the heightmap texture.")]
            public string heightTextureName = "_ParallaxMap";

            [SerializeField, Tooltip("Whether or not use main texture paint.")]
            public bool useMainPaint = true;

            [SerializeField, Tooltip("Whether or not use normal map paint (you need material on normal maps).")]
            public bool useNormalPaint = false;

            [SerializeField, Tooltip("Whether or not use heightmap painting (you need material on the heightmap).")]
            public bool useHeightPaint = false;

            /// <summary>
            /// In the first time set to the material's main texture.
            /// </summary>
            [HideInInspector]
            [NonSerialized]
            public Texture mainTexture;

            /// <summary>
            /// Copied the main texture to rendertexture that use to paint.
            /// </summary>
            [HideInInspector]
            [NonSerialized]
            public RenderTexture paintMainTexture;

            /// <summary>
            /// In the first time set to the material's normal map.
            /// </summary>
            [HideInInspector]
            [NonSerialized]
            public Texture normalTexture;

            /// <summary>
            /// Copied the normal map to rendertexture that use to paint.
            /// </summary>
            [HideInInspector]
            [NonSerialized]
            public RenderTexture paintNormalTexture;

            /// <summary>
            /// In the first time set to the material's height map.
            /// </summary>
            [HideInInspector]
            [NonSerialized]
            public Texture heightTexture;

            /// <summary>
            /// Copied the height map to rendertexture that use to paint.
            /// </summary>
            [HideInInspector]
            [NonSerialized]
            public RenderTexture paintHeightTexture;

            #region ShaderPropertyID

            [HideInInspector]
            [NonSerialized]
            public int mainTexturePropertyID;

            [HideInInspector]
            [NonSerialized]
            public int normalTexturePropertyID;

            [HideInInspector]
            [NonSerialized]
            public int heightTexturePropertyID;

            #endregion ShaderPropertyID

            #region Constractor
            /// <summary>
            /// Default constractor.
            /// </summary>
            public PaintSet() { }

            /// <summary>
            /// Setup paint data.
            /// </summary>
            /// <param name="mainTextureName">Shader property name(main texture).</param>
            /// <param name="normalTextureName">Shader property name(normal map).</param>
            /// <param name="heightTextureName">Shader property name(height map)</param>
            /// <param name="useMainPaint">Whether to use main texture paint.</param>
            /// <param name="useNormalPaint">Whether to use normal map paint.</param>
            /// <param name="useHeightPaint">Whether to use height map paint.</param>
            public PaintSet(string mainTextureName, string normalTextureName, string heightTextureName, bool useMainPaint, bool useNormalPaint, bool useHeightPaint)
            {
                this.mainTextureName = mainTextureName;
                this.normalTextureName = normalTextureName;
                this.heightTextureName = heightTextureName;
                this.useMainPaint = useMainPaint;
                this.useNormalPaint = useNormalPaint;
                this.useHeightPaint = useHeightPaint;
            }

            /// <summary>
            /// Setup paint data.
            /// </summary>
            /// <param name="mainTextureName">Shader property name(main texture).</param>
            /// <param name="normalTextureName">Shader property name(normal map).</param>
            /// <param name="heightTextureName">Shader property name(height map)</param>
            /// <param name="useMainPaint">Whether to use main texture paint.</param>
            /// <param name="useNormalPaint">Whether to use normal map paint.</param>
            /// <param name="useHeightPaint">Whether to use height map paint.</param>
            /// <param name="material">Specify when painting a specific material.</param>
            public PaintSet(string mainTextureName, string normalTextureName, string heightTextureName, bool useMainPaint, bool useNormalPaint, bool useHeightPaint, Material material)
                : this(mainTextureName, normalTextureName, heightTextureName, useMainPaint, useNormalPaint, useHeightPaint)
            {
                this.material = material;
            }
            #endregion Constractor
        }



        private static Material paintMainMaterial = null;
        private static Material paintNormalMaterial = null;
        private static Material paintHeightMaterial = null;
        private bool eraseFlag = false;
        private RenderTexture debugEraserMainView;
        private RenderTexture debugEraserNormalView;
        private RenderTexture debugEraserHeightView;


#pragma warning disable 0649
        private bool eraserDebug;
#pragma warning restore 0649

        /// <summary>
        /// Access data used for painting.
        /// </summary>
        public List<PaintSet> PaintDatas { get { return paintSet; } set { paintSet = value; } }

        /// <summary>
        /// Called by InkCanvas attached game object.
        /// </summary>
        public event Action<InkCanvas> OnCanvasAttached;

        /// <summary>
        /// Called by InkCanvas initialization start times.
        /// </summary>
        public event Action<InkCanvas> OnInitializedStart;

        /// <summary>
        /// Called by InkCanvas initialization completion times.
        /// </summary>
        public event Action<InkCanvas> OnInitializedAfter;

        /// <summary>
        /// Called at paint start.
        /// </summary>
        public event Action<InkCanvas, Brush> OnPaintStart;

        /// <summary>
        /// Called at paint end.
        /// </summary>
        public event Action<InkCanvas> OnPaintEnd;

        #region SerializedField

        [SerializeField]
        private List<PaintSet> paintSet = null;

        #endregion SerializedField

        #region ShaderPropertyID

        private int paintUVPropertyID;

        private int brushTexturePropertyID;
        private int brushScalePropertyID;
        private int brushRotatePropertyID;
        private int brushColorPropertyID;
        private int brushNormalTexturePropertyID;
        private int brushNormalBlendPropertyID;
        private int brushHeightTexturePropertyID;
        private int brushHeightBlendPropertyID;
        private int brushHeightColorPropertyID;

        #endregion ShaderPropertyID

        #region ShaderKeywords

        private const string COLOR_BLEND_USE_CONTROL = "INK_PAINTER_COLOR_BLEND_USE_CONTROL";
        private const string COLOR_BLEND_USE_BRUSH = "INK_PAINTER_COLOR_BLEND_USE_BRUSH";
        private const string COLOR_BLEND_NEUTRAL = "INK_PAINTER_COLOR_BLEND_NEUTRAL";
        private const string COLOR_BLEND_ALPHA_ONLY = "INK_PAINTER_COLOR_BLEND_ALPHA_ONLY";

        private const string NORMAL_BLEND_USE_BRUSH = "INK_PAINTER_NORMAL_BLEND_USE_BRUSH";
        private const string NORMAL_BLEND_ADD = "INK_PAINTER_NORMAL_BLEND_ADD";
        private const string NORMAL_BLEND_SUB = "INK_PAINTER_NORMAL_BLEND_SUB";
        private const string NORMAL_BLEND_MIN = "INK_PAINTER_NORMAL_BLEND_MIN";
        private const string NORMAL_BLEND_MAX = "INK_PAINTER_NORMAL_BLEND_MAX";
        private const string DXT5NM_COMPRESS_USE = "DXT5NM_COMPRESS_USE";
        private const string DXT5NM_COMPRESS_UNUSE = "DXT5NM_COMPRESS_UNUSE";

        private const string HEIGHT_BLEND_USE_BRUSH = "INK_PAINTER_HEIGHT_BLEND_USE_BRUSH";
        private const string HEIGHT_BLEND_ADD = "INK_PAINTER_HEIGHT_BLEND_ADD";
        private const string HEIGHT_BLEND_SUB = "INK_PAINTER_HEIGHT_BLEND_SUB";
        private const string HEIGHT_BLEND_MIN = "INK_PAINTER_HEIGHT_BLEND_MIN";
        private const string HEIGHT_BLEND_MAX = "INK_PAINTER_HEIGHT_BLEND_MAX";
        private const string HEIGHT_BLEND_COLOR_RGB_HEIGHT_A = "INK_PAINTER_HEIGHT_BLEND_COLOR_RGB_HEIGHT_A";

        #endregion ShaderKeywords

        #region MeshData

        private MeshOperator meshOperator;

        public MeshOperator MeshOperator
        {
            get
            {
                if (meshOperator == null)
                    Debug.LogError("To take advantage of the features must Mesh filter or Skinned mesh renderer component associated Mesh.");

                return meshOperator;
            }
        }

        #endregion MeshData

        #region UnityEventMethod

        static RenderTexture renderTexture;
        private int paintCount = 0;
        public int PaintCount
        {
            get { return paintCount; }
        }


        private float per = 0.0f;
        public float Per
        {
            get { return per; }
            set { per = value; }
        }


        private Texture2D newTex;
        private Color32 clearColor;

        private bool paintSwitching = false;
        public bool PaintSwitching
        {
            get { return paintSwitching; }
        }

        private Vector3 Floor_localScale;
        private Vector3 area_localScale;
        private int area_count;

        private RaycastHit hit;
        private int distance = 100;
        private Ray ray;
        private Vector3 Floor_worldPos;
        private Vector3 floor_upperLeft;
        private Vector3 floor_LowerRight;


        //テスト
        private float floor_width;
        private float floor_height;
        private GameObject Floor_obj;


        int[,] countArea;
        int countWidth;
        int countHeight;

        private float CPS = 1.0f;

        const float DIVIDE_SIZE = 16.0f;

        private void Awake()
        {
            if (OnCanvasAttached != null)
                OnCanvasAttached(this);

            InitPropertyID();
            SetMaterial();
            SetTexture();
            MeshDataCache();
        }

        RenderTexture main_rendertexture;
        private void Start()
        {

            if (OnInitializedStart != null)
                OnInitializedStart(this);

            SetRenderTexture();

            if (OnInitializedAfter != null)
                OnInitializedAfter(this);

            paintCount = 0;
            CPS = 1.0f;

            InkCanvas inkCanvas = gameObject.GetComponent<InkCanvas>();
            Renderer r = inkCanvas.GetComponent<Renderer>();
            RenderTexture rt = (RenderTexture)r.sharedMaterial.GetTexture("_MainTex");
            renderTexture = rt;


            newTex = new Texture2D(Screen.currentResolution.width, Screen.currentResolution.height, TextureFormat.RGBA32, false);
            newTex.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
            newTex.Apply();
            clearColor = newTex.GetPixel(0, 0);

            var area_objs = GameObject.FindGameObjectsWithTag("notPaintTag");
            Floor_localScale = GameObject.FindGameObjectWithTag("Floor").transform.localScale;
            Floor_worldPos = GameObject.FindGameObjectWithTag("Floor").transform.position;
            Floor_obj = GameObject.FindGameObjectWithTag("Floor");

            // 幅
            floor_width = Floor_obj.GetComponent<Renderer>().bounds.size.x;
            print("width: " + floor_width);

            // 高さ
            floor_height = Floor_obj.GetComponent<Renderer>().bounds.size.z;
            print("height: " + floor_height);

            float not_area_count = 0.0f;
            for (int i = 0; i < area_objs.Length; i++)
            {
                not_area_count += rt.width * (area_objs[i].transform.localScale.x / Floor_localScale.x) *
                              rt.height * (area_objs[i].transform.localScale.z / Floor_localScale.z);
            }

            not_area_count /= DIVIDE_SIZE * DIVIDE_SIZE;

            countHeight = (int)(renderTexture.height / DIVIDE_SIZE + 0.5f);
            countWidth = (int)(renderTexture.width / DIVIDE_SIZE + 0.5f);
            countArea = new int[countHeight, countWidth];


            floor_upperLeft.x = Floor_worldPos.x - floor_width * 0.5f;
            floor_upperLeft.z = Floor_worldPos.z - floor_height * 0.5f;


            Vector3 fuck = Floor_worldPos;
            fuck.y += 50.0f;
            for (int y = 0; y < countHeight; ++y)
            {
                fuck.z = floor_upperLeft.z + (floor_height / countHeight * 0.5f) + (floor_height / countHeight) * y;
                for (int x = 0; x < countWidth; ++x)
                {
                    fuck.x = floor_upperLeft.x + (floor_width / countWidth * 0.5f) + (floor_width / countWidth) * x;
                    ray = new Ray(fuck, Vector3.down);
                    //					Debug.DrawLine(ray.origin, ray.direction * distance, Color.red);

                    if (Physics.Raycast(ray, out hit, distance))
                    {
                        if (hit.collider.CompareTag("Block"))
                        {
                            countArea[y, x] = -1;
                            area_count += 1;
                        }
                        else
                        {
                            countArea[y, x] = 0;
                        }
                    }
                }
            }

            //if (not_area_count > area_count)
            //	area_count = (int)(not_area_count + 0.5f);
        }

        private float fps_count;

        private void Update()
        {
            if (!paintSwitching)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    paintSwitching = true;
                }
            }

            if (paintSwitching)
            {
                fps_count += Time.deltaTime;
                if (fps_count >= CPS)
                {

                    RenderTexture.active = renderTexture;
                    newTex.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
                    newTex.Apply();

                    //Debug.Log("RenderTexture  width : " + renderTexture.width + ("height : ") + renderTexture.height);


                    int ca_y, ca_x;
                    ca_y = 0;
                    for (int y = renderTexture.height / (int)DIVIDE_SIZE / 2; y < renderTexture.height; y += (int)DIVIDE_SIZE)
                    {
                        ca_x = 0;
                        for (int x = renderTexture.width / (int)DIVIDE_SIZE / 2; x < renderTexture.width; x += (int)DIVIDE_SIZE)
                        {
                            if (countArea[ca_y, ca_x] == 0)
                            {
                                Color32 color = newTex.GetPixel(x, renderTexture.height - y);
                                //								Color32 color2 = new Color32(2, 35, 43, 255);

                                if (color.r != clearColor.r && color.g != clearColor.g && color.b != clearColor.b)
                                {
                                    ++paintCount;
                                    countArea[ca_y, ca_x] = 1;
                                }
                                //else
                                //	Debug.Log("はずれの色:" + color);

                                //if (!color.Equals(color2))
                                //	++paintCount;
                                //else
                                //	Debug.Log("はずれの色:" + color);
                            }
                            ++ca_x;
                        }
                        ++ca_y;
                    }
                    fps_count = 0;
                }

                float fuck = (renderTexture.width / DIVIDE_SIZE) * (renderTexture.height / DIVIDE_SIZE); // - (int)area_count;
                                                                                                         //				int bitch = Mathf.CeilToInt(area_count);
                                                                                                         //				per = (paintCount / ((int)(renderTexture.width / DIVIDE_SIZE + 0.5f) * (int)(renderTexture.height / DIVIDE_SIZE + 0.5f) - area_count)) * 100.0f;
                per = paintCount / (fuck - area_count) * 100.0f;
                if (per >= 75.0f)
                    CPS = 0.25f;
                else if (per >= 50.0f)
                    CPS = 0.5f;

                //Debug.Log(per);
                //Debug.Log("塗った数:" + paintCount + " 塗らないといけない数:" + (fuck - area_count));

                RenderTexture.active = null;
            }

        }

        private void OnDestroy()
        {
            ReleaseRenderTexture();
        }

        private void OnGUI()
        {
            if (eraserDebug)
            {
                if (debugEraserMainView != null)
                    GUI.DrawTexture(new Rect(0, 0, 100, 100), debugEraserMainView);

                if (debugEraserNormalView != null)
                    GUI.DrawTexture(new Rect(0, 100, 100, 100), debugEraserNormalView);

                if (debugEraserHeightView != null)
                    GUI.DrawTexture(new Rect(0, 200, 100, 100), debugEraserHeightView);
            }
        }

        #endregion UnityEventMethod

        #region PrivateMethod

        /// <summary>
        /// Cach data from the mesh.
        /// </summary>
        private void MeshDataCache()
        {
            var meshFilter = GetComponent<MeshFilter>();
            var skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
            if (meshFilter != null)
                meshOperator = new MeshOperator(meshFilter.sharedMesh);
            else if (skinnedMeshRenderer != null)
                meshOperator = new MeshOperator(skinnedMeshRenderer.sharedMesh);
        }

        /// <summary>
        /// To initialize the shader property ID.
        /// </summary>
        private void InitPropertyID()
        {
            foreach (var p in paintSet)
            {
                p.mainTexturePropertyID = Shader.PropertyToID(p.mainTextureName);
                p.normalTexturePropertyID = Shader.PropertyToID(p.normalTextureName);
                p.heightTexturePropertyID = Shader.PropertyToID(p.heightTextureName);
            }
            paintUVPropertyID = Shader.PropertyToID("_PaintUV");
            brushTexturePropertyID = Shader.PropertyToID("_Brush");
            brushScalePropertyID = Shader.PropertyToID("_BrushScale");
            brushRotatePropertyID = Shader.PropertyToID("_BrushRotate");
            brushColorPropertyID = Shader.PropertyToID("_ControlColor");
            brushNormalTexturePropertyID = Shader.PropertyToID("_BrushNormal");
            brushNormalBlendPropertyID = Shader.PropertyToID("_NormalBlend");
            brushHeightTexturePropertyID = Shader.PropertyToID("_BrushHeight");
            brushHeightBlendPropertyID = Shader.PropertyToID("_HeightBlend");
            brushHeightColorPropertyID = Shader.PropertyToID("_Color");
        }

        /// <summary>
        /// Set and retrieve the material.
        /// </summary>
        private void SetMaterial()
        {
            if (paintMainMaterial == null)
                paintMainMaterial = new Material(Resources.Load<Material>("Es.InkPainter.PaintMain"));
            if (paintNormalMaterial == null)
                paintNormalMaterial = new Material(Resources.Load<Material>("Es.InkPainter.PaintNormal"));
            if (paintHeightMaterial == null)
                paintHeightMaterial = new Material(Resources.Load<Material>("Es.InkPainter.PaintHeight"));
            var m = GetComponent<Renderer>().materials;
            for (int i = 0; i < m.Length; ++i)
            {
                if (paintSet[i].material == null)
                    paintSet[i].material = m[i];
            }
        }

        /// <summary>
        /// Set and retrieve the texture.
        /// </summary>
        private void SetTexture()
        {
            foreach (var p in paintSet)
            {
                if (p.material.HasProperty(p.mainTexturePropertyID))
                    p.mainTexture = p.material.GetTexture(p.mainTexturePropertyID);
                if (p.material.HasProperty(p.normalTexturePropertyID))
                    p.normalTexture = p.material.GetTexture(p.normalTexturePropertyID);
                if (p.material.HasProperty(p.heightTexturePropertyID))
                    p.heightTexture = p.material.GetTexture(p.heightTexturePropertyID);
            }
        }

        /// <summary>
        /// Create RenderTexture and return.
        /// </summary>
        /// <param name="baseTex">Base texture.</param>
        /// <param name="propertyID">Shader property id.</param>
        /// <param name="material">material.</param>
        private RenderTexture SetupRenderTexture(Texture baseTex, int propertyID, Material material)
        {
            var rt = new RenderTexture(baseTex.width, baseTex.height, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
            rt.filterMode = baseTex.filterMode;
            Graphics.Blit(baseTex, rt);
            material.SetTexture(propertyID, rt);
            return rt;
        }

        /// <summary>
        /// Creates a rendertexture and set the material.
        /// </summary>
        private void SetRenderTexture()
        {
            foreach (var p in paintSet)
            {
                if (p.useMainPaint)
                {
                    if (p.mainTexture != null)
                        p.paintMainTexture = SetupRenderTexture(p.mainTexture, p.mainTexturePropertyID, p.material);
                }
                if (p.useNormalPaint)
                {
                    if (p.normalTexture != null)
                        p.paintNormalTexture = SetupRenderTexture(p.normalTexture, p.normalTexturePropertyID, p.material);
                }
                if (p.useHeightPaint)
                {
                    if (p.heightTexture != null)
                        p.paintHeightTexture = SetupRenderTexture(p.heightTexture, p.heightTexturePropertyID, p.material);
                }
            }
        }

        /// <summary>
        /// Rendertexture release process.
        /// </summary>
        private void ReleaseRenderTexture()
        {
            foreach (var p in paintSet)
            {
                if (RenderTexture.active != p.paintMainTexture && p.paintMainTexture != null && p.paintMainTexture.IsCreated())
                    p.paintMainTexture.Release();
                if (RenderTexture.active != p.paintNormalTexture && p.paintNormalTexture != null && p.paintNormalTexture.IsCreated())
                    p.paintNormalTexture.Release();
                if (RenderTexture.active != p.paintHeightTexture && p.paintHeightTexture != null && p.paintHeightTexture.IsCreated())
                    p.paintHeightTexture.Release();
            }
        }

        /// <summary>
        /// To set the data needed to paint shader.
        /// </summary>
        /// <param name="brush">Brush data.</param>
        /// <param name="uv">UV coordinates for the hit location.</param>
        private void SetPaintMainData(Brush brush, Vector2 uv)
        {
            paintMainMaterial.SetVector(paintUVPropertyID, uv);
            paintMainMaterial.SetTexture(brushTexturePropertyID, brush.BrushTexture);
            paintMainMaterial.SetFloat(brushScalePropertyID, brush.Scale);
            paintMainMaterial.SetFloat(brushRotatePropertyID, brush.RotateAngle);
            paintMainMaterial.SetVector(brushColorPropertyID, brush.Color);

            foreach (var key in paintMainMaterial.shaderKeywords)
                paintMainMaterial.DisableKeyword(key);
            switch (brush.ColorBlending)
            {
                case Brush.ColorBlendType.UseColor:
                    paintMainMaterial.EnableKeyword(COLOR_BLEND_USE_CONTROL);
                    break;

                case Brush.ColorBlendType.UseBrush:
                    paintMainMaterial.EnableKeyword(COLOR_BLEND_USE_BRUSH);
                    break;

                case Brush.ColorBlendType.Neutral:
                    paintMainMaterial.EnableKeyword(COLOR_BLEND_NEUTRAL);
                    break;

                case Brush.ColorBlendType.AlphaOnly:
                    paintMainMaterial.EnableKeyword(COLOR_BLEND_ALPHA_ONLY);
                    break;

                default:
                    paintMainMaterial.EnableKeyword(COLOR_BLEND_USE_CONTROL);
                    break;
            }
        }

        /// <summary>
        /// To set the data needed to normal map paint shader
        /// </summary>
        /// <param name="brush">Brush data.</param>
        /// <param name="uv">UV coordinates for the hit location.</param>
        private void SetPaintNormalData(Brush brush, Vector2 uv, bool erase)
        {
            paintNormalMaterial.SetVector(paintUVPropertyID, uv);
            paintNormalMaterial.SetTexture(brushTexturePropertyID, brush.BrushTexture);
            paintNormalMaterial.SetTexture(brushNormalTexturePropertyID, brush.BrushNormalTexture);
            paintNormalMaterial.SetFloat(brushScalePropertyID, brush.Scale);
            paintNormalMaterial.SetFloat(brushRotatePropertyID, brush.RotateAngle);
            paintNormalMaterial.SetFloat(brushNormalBlendPropertyID, brush.NormalBlend);

            foreach (var key in paintNormalMaterial.shaderKeywords)
                paintNormalMaterial.DisableKeyword(key);
            switch (brush.NormalBlending)
            {
                case Brush.NormalBlendType.UseBrush:
                    paintNormalMaterial.EnableKeyword(NORMAL_BLEND_USE_BRUSH);
                    break;

                case Brush.NormalBlendType.Add:
                    paintNormalMaterial.EnableKeyword(NORMAL_BLEND_ADD);
                    break;

                case Brush.NormalBlendType.Sub:
                    paintNormalMaterial.EnableKeyword(NORMAL_BLEND_SUB);
                    break;

                case Brush.NormalBlendType.Min:
                    paintNormalMaterial.EnableKeyword(NORMAL_BLEND_MIN);
                    break;

                case Brush.NormalBlendType.Max:
                    paintNormalMaterial.EnableKeyword(NORMAL_BLEND_MAX);
                    break;

                default:
                    paintNormalMaterial.EnableKeyword(NORMAL_BLEND_USE_BRUSH);
                    break;
            }

            switch (erase)
            {
                case true:
                    paintNormalMaterial.EnableKeyword(DXT5NM_COMPRESS_UNUSE);
                    break;
                case false:
                    paintNormalMaterial.EnableKeyword(DXT5NM_COMPRESS_USE);
                    break;
            }
        }

        /// <summary>
        /// To set the data needed to height map paint shader.
        /// </summary>
        /// <param name="brush">Brush data.</param>
        /// <param name="uv">UV coordinates for the hit location.</param>
        private void SetPaintHeightData(Brush brush, Vector2 uv)
        {
            paintHeightMaterial.SetVector(paintUVPropertyID, uv);
            paintHeightMaterial.SetTexture(brushTexturePropertyID, brush.BrushTexture);
            paintHeightMaterial.SetTexture(brushHeightTexturePropertyID, brush.BrushHeightTexture);
            paintHeightMaterial.SetFloat(brushScalePropertyID, brush.Scale);
            paintHeightMaterial.SetFloat(brushRotatePropertyID, brush.RotateAngle);
            paintHeightMaterial.SetFloat(brushHeightBlendPropertyID, brush.HeightBlend);
            paintHeightMaterial.SetVector(brushHeightColorPropertyID, brush.Color);

            foreach (var key in paintHeightMaterial.shaderKeywords)
                paintHeightMaterial.DisableKeyword(key);
            switch (brush.HeightBlending)
            {
                case Brush.HeightBlendType.UseBrush:
                    paintHeightMaterial.EnableKeyword(HEIGHT_BLEND_USE_BRUSH);
                    break;

                case Brush.HeightBlendType.Add:
                    paintHeightMaterial.EnableKeyword(HEIGHT_BLEND_ADD);
                    break;

                case Brush.HeightBlendType.Sub:
                    paintHeightMaterial.EnableKeyword(HEIGHT_BLEND_SUB);
                    break;

                case Brush.HeightBlendType.Min:
                    paintHeightMaterial.EnableKeyword(HEIGHT_BLEND_MIN);
                    break;

                case Brush.HeightBlendType.Max:
                    paintHeightMaterial.EnableKeyword(HEIGHT_BLEND_MAX);
                    break;

                case Brush.HeightBlendType.ColorRGB_HeightA:
                    paintHeightMaterial.EnableKeyword(HEIGHT_BLEND_COLOR_RGB_HEIGHT_A);
                    break;

                default:
                    paintHeightMaterial.EnableKeyword(HEIGHT_BLEND_ADD);
                    break;
            }
        }

        /// <summary>
        /// Get an eraser brush.
        /// </summary>
        /// <param name="brush">A brush that becomes the shape of an eraser.</param>
        /// <param name="paintSet">Paint information per material.</param>
        /// <param name="uv">UV coordinates for the hit location.</param>
        /// <param name="useMainPaint">Whether paint is effective.</param>
        /// <param name="useNormalPaint">Whether paint is effective.</param>
        /// <param name="useHeightpaint">Whether paint is effective.</param>
        /// <returns></returns>
        private Brush GetEraser(Brush brush, PaintSet paintSet, Vector2 uv, bool useMainPaint, bool useNormalPaint, bool useHeightpaint)
        {
            var b = brush.Clone() as Brush;
            b.Color = Color.white;
            b.ColorBlending = Brush.ColorBlendType.UseBrush;
            b.NormalBlending = Brush.NormalBlendType.UseBrush;
            b.HeightBlending = Brush.HeightBlendType.UseBrush;
            b.NormalBlend = 1f;
            b.HeightBlend = 1f;

            if (useMainPaint)
            {
                var rt = RenderTexture.GetTemporary(brush.BrushTexture.width, brush.BrushTexture.height);
                GrabArea.Clip(brush.BrushTexture, brush.Scale, paintSet.mainTexture, uv, brush.RotateAngle, GrabArea.GrabTextureWrapMode.Clamp, rt);
                b.BrushTexture = rt;
            }
            if (useNormalPaint)
            {
                var rt = RenderTexture.GetTemporary(brush.BrushNormalTexture.width, brush.BrushNormalTexture.height);
                GrabArea.Clip(brush.BrushNormalTexture, brush.Scale, paintSet.normalTexture, uv, brush.RotateAngle, GrabArea.GrabTextureWrapMode.Clamp, rt, false);
                b.BrushNormalTexture = rt;
            }
            if (useHeightpaint)
            {
                var rt = RenderTexture.GetTemporary(brush.BrushHeightTexture.width, brush.BrushHeightTexture.height);
                GrabArea.Clip(brush.BrushHeightTexture, brush.Scale, paintSet.heightTexture, uv, brush.RotateAngle, GrabArea.GrabTextureWrapMode.Clamp, rt, false);
                b.BrushHeightTexture = rt;
            }

            if (eraserDebug)
            {
                if (debugEraserMainView == null && useMainPaint)
                    debugEraserMainView = new RenderTexture(b.BrushTexture.width, b.BrushTexture.height, 0);

                if (debugEraserNormalView == null && useNormalPaint)
                    debugEraserNormalView = new RenderTexture(b.BrushNormalTexture.width, b.BrushNormalTexture.height, 0);

                if (debugEraserHeightView == null && useHeightpaint)
                    debugEraserHeightView = new RenderTexture(b.BrushHeightTexture.width, b.BrushHeightTexture.height, 0);

                if (useMainPaint)
                    Graphics.Blit(b.BrushTexture, debugEraserMainView);

                if (useNormalPaint)
                    Graphics.Blit(b.BrushNormalTexture, debugEraserNormalView);

                if (useHeightpaint)
                    Graphics.Blit(b.BrushHeightTexture, debugEraserHeightView);
            }

            return b;
        }

        /// <summary>
        /// Release the RenderTexture for the eraser.
        /// </summary>
        /// <param name="brush">Brush data.</param>
        /// <param name="useMainPaint">Whether paint is effective.</param>
        /// <param name="useNormalPaint">Whether paint is effective.</param>
        /// <param name="useHeightpaint">Whether paint is effective.</param>
        private void ReleaseEraser(Brush brush, bool useMainPaint, bool useNormalPaint, bool useHeightpaint)
        {
            if (useMainPaint && brush.BrushTexture is RenderTexture)
                RenderTexture.ReleaseTemporary(brush.BrushTexture as RenderTexture);

            if (useNormalPaint && brush.BrushNormalTexture is RenderTexture)
                RenderTexture.ReleaseTemporary(brush.BrushNormalTexture as RenderTexture);

            if (useHeightpaint && brush.BrushHeightTexture is RenderTexture)
                RenderTexture.ReleaseTemporary(brush.BrushHeightTexture as RenderTexture);
        }

        #endregion PrivateMethod

        #region PublicMethod

        /// <summary>
        /// Paint processing that UV coordinates to the specified.
        /// </summary>
        /// <param name="brush">Brush data.</param>
        /// <param name="uv">UV coordinates for the hit location.</param>
        /// <returns>The success or failure of the paint.</returns>
        public bool PaintUVDirect(Brush brush, Vector2 uv, Func<PaintSet, bool> materialSelector = null)
        {
            #region ErrorCheck

            if (brush == null)
            {
                eraseFlag = false;
                return false;
            }

            #endregion ErrorCheck

            if (OnPaintStart != null)
            {
                brush = brush.Clone() as Brush;
                OnPaintStart(this, brush);
            }

            var set = materialSelector == null ? paintSet : paintSet.Where(materialSelector);
            foreach (var p in set)
            {
                var mainPaintConditions = p.useMainPaint && brush.BrushTexture != null && p.paintMainTexture != null && p.paintMainTexture.IsCreated();
                var normalPaintConditions = p.useNormalPaint && brush.BrushNormalTexture != null && p.paintNormalTexture != null && p.paintNormalTexture.IsCreated();
                var heightPaintConditions = p.useHeightPaint && brush.BrushHeightTexture != null && p.paintHeightTexture != null && p.paintHeightTexture.IsCreated();

                if (eraseFlag)
                    brush = GetEraser(brush, p, uv, mainPaintConditions, normalPaintConditions, heightPaintConditions);

                if (mainPaintConditions)
                {
                    var mainPaintTextureBuffer = RenderTexture.GetTemporary(p.paintMainTexture.width, p.paintMainTexture.height, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
                    SetPaintMainData(brush, uv);
                    Graphics.Blit(p.paintMainTexture, mainPaintTextureBuffer, paintMainMaterial);
                    Graphics.Blit(mainPaintTextureBuffer, p.paintMainTexture);
                    RenderTexture.ReleaseTemporary(mainPaintTextureBuffer);
                }

                if (normalPaintConditions)
                {
                    var normalPaintTextureBuffer = RenderTexture.GetTemporary(p.paintNormalTexture.width, p.paintNormalTexture.height, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
                    SetPaintNormalData(brush, uv, eraseFlag);
                    Graphics.Blit(p.paintNormalTexture, normalPaintTextureBuffer, paintNormalMaterial);
                    Graphics.Blit(normalPaintTextureBuffer, p.paintNormalTexture);
                    RenderTexture.ReleaseTemporary(normalPaintTextureBuffer);
                }

                if (heightPaintConditions)
                {
                    var heightPaintTextureBuffer = RenderTexture.GetTemporary(p.paintHeightTexture.width, p.paintHeightTexture.height, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
                    SetPaintHeightData(brush, uv);
                    Graphics.Blit(p.paintHeightTexture, heightPaintTextureBuffer, paintHeightMaterial);
                    Graphics.Blit(heightPaintTextureBuffer, p.paintHeightTexture);
                    RenderTexture.ReleaseTemporary(heightPaintTextureBuffer);
                }

                if (eraseFlag)
                    ReleaseEraser(brush, mainPaintConditions, normalPaintConditions, heightPaintConditions);
            }

            if (OnPaintEnd != null)
                OnPaintEnd(this);

            eraseFlag = false;
            return true;
        }

        /// <summary>
        /// Paint of points close to the given world-space position on the Mesh surface.
        /// </summary>
        /// <param name="brush">Brush data.</param>
        /// <param name="worldPos">Approximate point.</param>
        /// <param name="renderCamera">Camera to use to render the object.</param>
        /// <returns>The success or failure of the paint.</returns>
        public bool PaintNearestTriangleSurface(Brush brush, Vector3 worldPos, Func<PaintSet, bool> materialSelector = null, Camera renderCamera = null)
        {
            var p = transform.worldToLocalMatrix.MultiplyPoint(worldPos);
            var pd = MeshOperator.NearestLocalSurfacePoint(p);

            return Paint(brush, transform.localToWorldMatrix.MultiplyPoint(pd), materialSelector, renderCamera);
        }

        /// <summary>
        /// Paint processing that use world-space surface position.
        /// </summary>
        /// <param name="brush">Brush data.</param>
        /// <param name="worldPos">Point on object surface (world-space).</param>
        /// <param name="renderCamera">Camera to use to render the object.</param>
        /// <returns>The success or failure of the paint.</returns>
        public bool Paint(Brush brush, Vector3 worldPos, Func<PaintSet, bool> materialSelector = null, Camera renderCamera = null)
        {
            Vector2 uv;

            if (renderCamera == null)
                renderCamera = Camera.main;

            Vector3 p = transform.InverseTransformPoint(worldPos);
            Matrix4x4 mvp = renderCamera.projectionMatrix * renderCamera.worldToCameraMatrix * transform.localToWorldMatrix;
            if (MeshOperator.LocalPointToUV(p, mvp, out uv))
                return PaintUVDirect(brush, uv, materialSelector);
            else
            {
                return PaintNearestTriangleSurface(brush, worldPos, materialSelector, renderCamera);
            }
        }

        /// <summary>
        /// Paint processing that use raycast hit data.
        /// Must MeshCollider is set to the canvas.
        /// </summary>
        /// <param name="brush">Brush data.</param>
        /// <param name="hitInfo">Raycast hit info.</param>
        /// <returns>The success or failure of the paint.</returns>
        public bool Paint(Brush brush, RaycastHit hitInfo, Func<PaintSet, bool> materialSelector = null)
        {
            if (hitInfo.collider != null)
            {
                if (hitInfo.collider is MeshCollider)
                    return PaintUVDirect(brush, hitInfo.textureCoord, materialSelector);

                return PaintNearestTriangleSurface(brush, hitInfo.point, materialSelector);
            }
            return false;
        }

        /// <summary>
        /// Erase processing that UV coordinates to the specified.
        /// </summary>
        /// <param name="brush">Brush data.</param>
        /// <param name="uv">UV coordinates for the hit location.</param>
        /// <returns>The success or failure of the erase.</returns>
        public bool EraseUVDirect(Brush brush, Vector2 uv, Func<PaintSet, bool> materialSelector = null)
        {
            eraseFlag = true;
            return PaintUVDirect(brush, uv, materialSelector);
        }

        /// <summary>
        /// Erase of points close to the given world-space position on the Mesh surface.
        /// </summary>
        /// <param name="brush">Brush data.</param>
        /// <param name="worldPos">Approximate point.</param>
        /// <param name="renderCamera">Camera to use to render the object.</param>
        /// <returns>The success or failure of the erase.</returns>
        public bool EraseNearestTriangleSurface(Brush brush, Vector3 worldPos, Func<PaintSet, bool> materialSelector = null, Camera renderCamera = null)
        {
            eraseFlag = true;
            return PaintNearestTriangleSurface(brush, worldPos, materialSelector, renderCamera);
        }

        /// <summary>
        /// Erase processing that use world-space surface position.
        /// </summary>
        /// <param name="brush">Brush data.</param>
        /// <param name="worldPos">Point on object surface (world-space).</param>
        /// <param name="renderCamera">Camera to use to render the object.</param>
        /// <returns>The success or failure of the erase.</returns>
        public bool Erase(Brush brush, Vector3 worldPos, Func<PaintSet, bool> materialSelector = null, Camera renderCamera = null)
        {
            eraseFlag = true;
            return Paint(brush, worldPos, materialSelector, renderCamera);
        }

        /// <summary>
        /// Erase processing that use raycast hit data.
        /// Must MeshCollider is set to the canvas.
        /// </summary>
        /// <param name="brush">Brush data.</param>
        /// <param name="hitInfo">Raycast hit info.</param>
        /// <returns>The success or failure of the erase.</returns>
        public bool Erase(Brush brush, RaycastHit hitInfo, Func<PaintSet, bool> materialSelector = null)
        {
            eraseFlag = true;
            return Paint(brush, hitInfo, materialSelector);
        }

        /// <summary>
        /// To reset the paint.
        /// </summary>
        public void ResetPaint()
        {
            ReleaseRenderTexture();
            SetRenderTexture();
            if (OnInitializedAfter != null)
                OnInitializedAfter(this);
        }

        /// <summary>
        /// To get the original main texture.
        /// </summary>
        /// <param name="materialName">Material name.</param>
        /// <returns>Original main texture.</returns>
        public Texture GetMainTexture(string materialName)
        {
            materialName = materialName.Replace(" (Instance)", "");
            var data = paintSet.FirstOrDefault(p => p.material.name.Replace(" (Instance)", "") == materialName);
            if (data == null)
                return null;
            return data.mainTexture;
        }

        /// <summary>
        /// To get the main texture in paint.
        /// </summary>
        /// <param name="materialName">Material name.</param>
        /// <returns>Main texture in paint.</returns>
        public RenderTexture GetPaintMainTexture(string materialName)
        {
            materialName = materialName.Replace(" (Instance)", "");
            var data = paintSet.FirstOrDefault(p => p.material.name.Replace(" (Instance)", "") == materialName);
            if (data == null)
                return null;
            return data.paintMainTexture;
        }

        /// <summary>
        /// Set paint texture.
        /// </summary>
        /// <param name="materialName">Material name.</param>
        /// <param name="newTexture">New rendertexture.</param>
        public void SetPaintMainTexture(string materialName, RenderTexture newTexture)
        {
            materialName = materialName.Replace(" (Instance)", "");
            var data = paintSet.FirstOrDefault(p => p.material.name.Replace(" (Instance)", "") == materialName);
            if (data == null)
            {
                return;
            }
            data.paintMainTexture = newTexture;
            data.material.SetTexture(data.mainTextureName, data.paintMainTexture);
            data.useMainPaint = true;
        }

        /// <summary>
        /// To get the original normal map.
        /// </summary>
        /// <param name="materialName">Material name.</param>
        /// <returns>Original normal map.</returns>
        public Texture GetNormalTexture(string materialName)
        {
            materialName = materialName.Replace(" (Instance)", "");
            var data = paintSet.FirstOrDefault(p => p.material.name.Replace(" (Instance)", "") == materialName);
            if (data == null)
                return null;
            return data.normalTexture;
        }

        /// <summary>
        /// To get the paint in normal map.
        /// </summary>
        /// <param name="materialName">Material name.</param>
        /// <returns>Normal map in paint.</returns>
        public RenderTexture GetPaintNormalTexture(string materialName)
        {
            materialName = materialName.Replace(" (Instance)", "");
            var data = paintSet.FirstOrDefault(p => p.material.name.Replace(" (Instance)", "") == materialName);
            if (data == null)
                return null;
            return data.paintNormalTexture;
        }

        /// <summary>
        /// Set paint texture.
        /// </summary>
        /// <param name="materialName">Material name.</param>
        /// <param name="newTexture">New rendertexture.</param>
        public void SetPaintNormalTexture(string materialName, RenderTexture newTexture)
        {
            materialName = materialName.Replace(" (Instance)", "");
            var data = paintSet.FirstOrDefault(p => p.material.name.Replace(" (Instance)", "") == materialName);
            if (data == null)
            {
                return;
            }
            data.paintNormalTexture = newTexture;
            data.material.SetTexture(data.normalTextureName, data.paintNormalTexture);
            data.useNormalPaint = true;
        }

        /// <summary>
        /// To get the original height map.
        /// </summary>
        /// <param name="materialName">Material name.</param>
        /// <returns>Original height map.</returns>
        public Texture GetHeightTexture(string materialName)
        {
            materialName = materialName.Replace(" (Instance)", "");
            var data = paintSet.FirstOrDefault(p => p.material.name.Replace(" (Instance)", "") == materialName);
            if (data == null)
                return null;
            return data.heightTexture;
        }

        /// <summary>
        /// To get the paint in height map.
        /// </summary>
        /// <param name="materialName">Material name.</param>
        /// <returns>Height map in paint.</returns>
        public RenderTexture GetPaintHeightTexture(string materialName)
        {
            materialName = materialName.Replace(" (Instance)", "");
            var data = paintSet.FirstOrDefault(p => p.material.name.Replace(" (Instance)", "") == materialName);
            if (data == null)
                return null;
            return data.paintHeightTexture;
        }

        /// <summary>
        /// Set paint texture.
        /// </summary>
        /// <param name="materialName">Material name.</param>
        /// <param name="newTexture">New rendertexture.</param>
        public void SetPaintHeightTexture(string materialName, RenderTexture newTexture)
        {
            materialName = materialName.Replace(" (Instance)", "");
            var data = paintSet.FirstOrDefault(p => p.material.name.Replace(" (Instance)", "") == materialName);
            if (data == null)
            {
                return;
            }
            data.paintHeightTexture = newTexture;
            data.material.SetTexture(data.heightTextureName, data.paintHeightTexture);
            data.useHeightPaint = true;
        }

        #endregion PublicMethod

    }
}