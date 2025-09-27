using UnityEngine;

public class BG_LoopingScroller : MonoBehaviour
{
    [Header("�K�{: 2���̓���摜�^�C��")]
    public SpriteRenderer tileA;
    public SpriteRenderer tileB;

    [Header("���֗������x�i�P��/�b�j")]
    public float scrollSpeed = 2f;

    [Tooltip("true: �e�ɑ΂���localPosition�ňړ��i�J�����̎q�ł����E����Ȃ��j")]
    public bool useLocalSpace = true;

    float width;         // 1�^�C���̃��[���h��
    Vector3 aStartLocal; // �������[�J�����W
    Vector3 bStartLocal;

    void Awake()
    {
        if (!tileA || !tileB)
        {
            Debug.LogError("[BG] tileA/tileB �̊������K�v�ł�", this);
            enabled = false;
            return;
        }

        // Draw Mode��Tiled�ł����ۂ̕`��T�C�Y�ŕ����擾�ł���
        width = tileA.bounds.size.x;

        // �������т������I�ɐ����i���ԃ[���j
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

            // 1�������ɔ�������E�[�փ��[�v�i2������j
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
    // �G�f�B�^�Ń^�C������ʒu���m�F���₷��
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
