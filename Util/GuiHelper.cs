using UnityEngine;

namespace JsonValue
{
    public static class H
    {
        public static void Pixel(Vector2 Position, Color color, float thickness)
        {
            if (H._coloredLineTexture == null || H._coloredLineColor != color)
            {
                H._coloredLineColor = color;
                H._coloredLineTexture = new Texture2D(1, 1);
                H._coloredLineTexture.SetPixel(0, 0, H._coloredLineColor);
                H._coloredLineTexture.wrapMode = 0;
                H._coloredLineTexture.Apply();
            }
            if (thickness < 1f)
            {
                thickness = 1f;
            }
            float num = Mathf.Ceil(thickness / 2f);
            GUI.DrawTexture(new Rect(Position.x, Position.y - num, thickness, thickness), H._coloredLineTexture);
        }

        public static void Line(Vector2 lineStart, Vector2 lineEnd, Color color, int thickness)
        {
            if (_coloredLineTexture == null || _coloredLineColor != color)
            {
                _coloredLineColor = color;
                _coloredLineTexture = new Texture2D(1, 1);
                _coloredLineTexture.SetPixel(0, 0, _coloredLineColor);
                _coloredLineTexture.wrapMode = 0;
                _coloredLineTexture.Apply();
            }

            var vector = lineEnd - lineStart;
            float pivot = 57.29578f * Mathf.Atan(vector.y / vector.x);
            if (vector.x < 0f)
            {
                pivot += 180f;
            }

            if (thickness < 1)
            {
                thickness = 1;
            }

            int yOffset = (int)Mathf.Ceil((float)(thickness / 2));

            GUIUtility.RotateAroundPivot(pivot, lineStart);
            GUI.DrawTexture(new Rect(lineStart.x, lineStart.y - (float)yOffset, vector.magnitude, (float)thickness), _coloredLineTexture);
            GUIUtility.RotateAroundPivot(-pivot, lineStart);
        }

        private static Texture2D _coloredLineTexture;

        private static Color _coloredLineColor;
    }
}