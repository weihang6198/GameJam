using UnityEngine;

public class BG_LoopingScroller : MonoBehaviour
{
    [Header("必須: 2枚の同一画像タイル")]
    public SpriteRenderer tileA;
    public SpriteRenderer tileB;

    [Header("左へ流す速度（単位/秒）")]
    public float scrollSpeed = 2f;

    [Tooltip("true: 親に対するlocalPositionで移動（カメラの子でも相殺されない）")]
    public bool useLocalSpace = true;

    float width;         // 1タイルのワールド幅
    Vector3 aStartLocal; // 初期ローカル座標
    Vector3 bStartLocal;

    void Awake()
    {
        if (!tileA || !tileB)
        {
            Debug.LogError("[BG] tileA/tileB の割当が必要です", this);
            enabled = false;
            return;
        }

        // Draw ModeがTiledでも実際の描画サイズで幅を取得できる
        width = tileA.bounds.size.x;

        // 初期並びを強制的に正す（隙間ゼロ）
        aStartLocal = tileA.transform.localPosition;
        bStartLocal = aStartLocal + new Vector3(width, 0f, 0f);
        tileA.transform.localPosition = aStartLocal;
        tileB.transform.localPosition = bStartLocal;
    }

    void Update()
    {
        float dx = -scrollSpeed * Time.deltaTime;
        if (useLocalSpace)
        {
            tileA.transform.localPosition += new Vector3(dx, 0, 0);
            tileB.transform.localPosition += new Vector3(dx, 0, 0);

            // 1枚が左に抜けたら右端へワープ（2枚分先）
            if (tileA.transform.localPosition.x <= aStartLocal.x - width)
                tileA.transform.localPosition += new Vector3(width * 2f, 0, 0);
            if (tileB.transform.localPosition.x <= aStartLocal.x - width)
                tileB.transform.localPosition += new Vector3(width * 2f, 0, 0);
        }
        else
        {
            tileA.transform.position += new Vector3(dx, 0, 0);
            tileB.transform.position += new Vector3(dx, 0, 0);

            if (tileA.transform.position.x <= tileB.transform.position.x - width)
                tileA.transform.position += new Vector3(width * 2f, 0, 0);
            if (tileB.transform.position.x <= tileA.transform.position.x - width)
                tileB.transform.position += new Vector3(width * 2f, 0, 0);
        }
    }

#if UNITY_EDITOR
    // エディタでタイル幅や位置を確認しやすく
    void OnDrawGizmosSelected()
    {
        if (tileA)
        {
            Gizmos.color = Color.cyan;
            var p = useLocalSpace ? transform.TransformPoint(tileA.transform.localPosition)
                                  : tileA.transform.position;
            Gizmos.DrawLine(p + Vector3.up * 10, p + Vector3.down * 10);
        }
        if (tileB)
        {
            Gizmos.color = Color.magenta;
            var p = useLocalSpace ? transform.TransformPoint(tileB.transform.localPosition)
                                  : tileB.transform.position;
            Gizmos.DrawLine(p + Vector3.up * 10, p + Vector3.down * 10);
        }
    }
#endif
}
