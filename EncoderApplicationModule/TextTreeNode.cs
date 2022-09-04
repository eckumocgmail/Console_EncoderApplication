using System;
using System.Collections.Generic;
using System.Linq;
using static System.Text.Json.JsonSerializer;
using static System.Console;

/// <summary>
/// Бинорное дерево (Узел) содержит:
/// -последовательность символов
/// -частота употребления в тексте (вероятность повторения)
/// </summary>
public class TextTreeNode
{
    // последовательность символов
    public List<byte> Characters { get; set; }

    // частота (кол-во употреблений)
    public int Rating { get; set; }

    // потомки
    public TextTreeNode Left { get; set; }
    public TextTreeNode Right { get; set; }


    public TextTreeNode() : this(new List<byte>(), 0) { }
    public TextTreeNode(List<byte> Characters, int Rating)
    {
        this.Characters = Characters;
        this.Rating = Rating;
    }

    public bool Contains(byte ch)
        => Characters.Contains(ch);

    public string GetText()
    {
        string text = "";
        foreach (char ch in Characters)
            text += (ch);
        return text;
    }

    // печать в консоль
    public void Trace() => Trace(1);
    public void Trace(int level)
    {
        if (Left != null) Left.Trace(level + 1);

        for (int i = 1; i <= level; i++)
            Write("\t");
        foreach (char ch in Characters)
            Write(ch);
        WriteLine();
        if (Right != null) Right.Trace(level + 1);
    }
}