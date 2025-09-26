using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class BlinkAlpha : MonoBehaviour
{
    public enum TargetType { Auto, Graphic, SpriteRenderer, CanvasGroup }

    [Header("�Ώ�")]
    public TargetType targetType = TargetType.Auto;
    public Graphic uiGraphic;            // UI: Image / Text / TMPUGUI �Ȃ�
    public SpriteRenderer spriteRenderer;// 2D: �X�v���C�g
    public CanvasGroup canvasGroup;      // �e�܂Ƃ߂ē_�ł�������

    [Header("�_�Ńp�����[�^")]
    [Min(0.05f)] public float period = 1.8f; // �����i�����Á����j���ԁB�傫���قǂ������
    [Range(0f, 1f)] public float minAlpha = 0.2f;
    [Range(0f, 1f)] public float maxAlpha = 1.0f;
    public AnimationCurve curve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    public bool playOnEnable = true;
    public bool unscaledTime = true;

    float _t;
    bool _playing;

    void Reset()
    {
        AutoFetch();
    }

    void Awake()
    {
        AutoFetch();
    }

    void OnEnable()
    {
        _t = 0f;
        _playing = playOnEnable;
        SetAlpha(maxAlpha);
    }

    void AutoFetch()
    {
        if (targetType == TargetType.Auto)
        {
            uiGraphic = uiGraphic ? uiGraphic : GetComponent<Graphic>();
            spriteRenderer = spriteRenderer ? spriteRenderer : GetComponent<SpriteRenderer>();
            canvasGroup = canvasGroup ? canvasGroup : GetComponent<CanvasGroup>();

            if (canvasGroup) targetType = TargetType.CanvasGroup;
            else if (uiGraphic) targetType = TargetType.Graphic;
            else if (spriteRenderer) targetType = TargetType.SpriteRenderer;
            else targetType = TargetType.Graphic; // �f�t�H���g
        }
        else
        {
            if (targetType == TargetType.Graphic && !uiGraphic) uiGraphic = GetComponent<Graphic>();
            if (targetType == TargetType.SpriteRenderer && !spriteRenderer) spriteRenderer = GetComponent<SpriteRenderer>();
            if (targetType == TargetType.CanvasGroup && !canvasGroup) canvasGroup = GetComponent<CanvasGroup>();
        }
    }

    public void Play() { _playing = true; }
    public void Stop() { _playing = false; SetAlpha(maxAlpha); }
    public void Toggle() { _playing = !_playing; if (!_playing) SetAlpha(maxAlpha); }

    void Update()
    {
        if (!_playing || period <= 0f) return;

        float dt = unscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
        _t += dt / Mathf.Max(0.0001f, period);

        // 0��1��0�c �̎O�p�g
        float tri = 1f - Mathf.Abs(((_t % 2f) - 1f));
        float k = curve.Evaluate(tri);
        float a = Mathf.Lerp(minAlpha, maxAlpha, k);

        SetAlpha(a);
    }

    void SetAlpha(float a)
    {
        a = Mathf.Clamp01(a);

        switch (targetType)
        {
            case TargetType.CanvasGroup:
                if (!canvasGroup) canvasGroup = GetComponent<CanvasGroup>();
                if (!canvasGroup) canvasGroup = gameObject.AddComponent<CanvasGroup>();
                canvasGroup.alpha = a;
                return;

            case TargetType.SpriteRenderer:
                if (!spriteRenderer) spriteRenderer = GetComponent<SpriteRenderer>();
                if (spriteRenderer)
                {
                    var c = spriteRenderer.color; c.a = a;
                    spriteRenderer.color = c;
                }
                return;

            default: // Graphic
                if (!uiGraphic) uiGraphic = GetComponent<Graphic>();
                if (uiGraphic)
                {
                    var c = uiGraphic.color; c.a = a;
                    uiGraphic.color = c;
                }
                return;
        }
    }
}
