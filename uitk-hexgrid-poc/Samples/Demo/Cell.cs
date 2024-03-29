using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Cell : VisualElement {
    const int size = 100;
    public int xpos = 0;
    public int ypos = 0;

    public Cell() {
        AddToClassList("hex-cell");
    }

    public void Init(int x, int y) {
        xpos = x;
        ypos = y;
        var pad = 13;
        var doublePad = pad * 2;
        var offsetx = y % 2 * size / 2;
        style.left = size * x + offsetx;
        style.top = (size - pad) * y;
        style.width = size + doublePad;
        style.height = size + doublePad;
    }
}
