using System;
using System.Windows;
using System.Windows.Controls;
using Superiorly.PostInstall.ViewModels;

namespace Superiorly.PostInstall.Models;

public class StretchyWrapPanel : Panel
{
    public static readonly DependencyProperty StretchProportionallyProperty =
        DependencyProperty.Register(nameof(StretchProportionally), typeof(bool), typeof(StretchyWrapPanel),
            new PropertyMetadata(true));

    public bool StretchProportionally
    {
        get => (bool)GetValue(StretchProportionallyProperty);
        set => SetValue(StretchProportionallyProperty, value);
    }

    private static Thickness GetMargin(UIElement child) =>
        child is FrameworkElement fe ? fe.Margin : default;

    private static bool IsGroupHeader(UIElement child)
    {
        if (child is ContentPresenter cp && cp.DataContext is CardViewModel cv)
            return cv.IsGroupHeader;
        return false;
    }

    protected override Size MeasureOverride(Size constraint)
    {
        double curLineU = 0, panelU = 0, panelV = 0, maxV = 0;

        foreach (UIElement child in InternalChildren)
        {
            child.Measure(constraint);
            var m = GetMargin(child);
            double childU = child.DesiredSize.Width + m.Left + m.Right;
            double childV = child.DesiredSize.Height + m.Top + m.Bottom;

            if (IsGroupHeader(child))
            {
                if (curLineU > 0)
                {
                    panelU = Math.Max(panelU, curLineU);
                    panelV += maxV;
                    curLineU = 0;
                    maxV = 0;
                }
                panelU = Math.Max(panelU, constraint.Width);
                panelV += childV;
            }
            else if (curLineU + childU > constraint.Width && curLineU > 0)
            {
                panelU = Math.Max(panelU, curLineU);
                panelV += maxV;
                curLineU = childU;
                maxV = childV;
            }
            else
            {
                curLineU += childU;
                maxV = Math.Max(maxV, childV);
            }
        }

        panelU = Math.Max(panelU, curLineU);
        panelV += maxV;
        return new Size(panelU, panelV);
    }

    protected override Size ArrangeOverride(Size finalSize)
    {
        int firstInLine = 0;
        double curLineU = 0, accumulatedV = 0, maxV = 0;
        var children = InternalChildren;

        for (int i = 0; i < children.Count; i++)
        {
            var child = children[i];
            var m = GetMargin(child);
            double childU = child.DesiredSize.Width + m.Left + m.Right;
            double childV = child.DesiredSize.Height + m.Top + m.Bottom;

            if (IsGroupHeader(child))
            {
                if (curLineU > 0)
                {
                    ArrangeLine(accumulatedV, maxV, firstInLine, i, curLineU, finalSize.Width);
                    accumulatedV += maxV;
                    curLineU = 0;
                    maxV = 0;
                }
                firstInLine = i + 1;
                child.Arrange(new Rect(0, accumulatedV, finalSize.Width, childV));
                accumulatedV += childV;
            }
            else if (curLineU + childU > finalSize.Width && curLineU > 0)
            {
                ArrangeLine(accumulatedV, maxV, firstInLine, i, curLineU, finalSize.Width);
                accumulatedV += maxV;
                firstInLine = i;
                curLineU = childU;
                maxV = childV;
            }
            else
            {
                curLineU += childU;
                maxV = Math.Max(maxV, childV);
            }
        }

        if (firstInLine < children.Count)
            ArrangeLine(accumulatedV, maxV, firstInLine, children.Count, curLineU, finalSize.Width);

        return finalSize;
    }

    private void ArrangeLine(double v, double maxV, int start, int end, double lineU, double totalU)
    {
        double x = 0;
        double scale = StretchProportionally && lineU < totalU ? totalU / lineU : 1;
        // equal shares keep cards uniform; proportional scaling made them content-sized
        int count = end - start;
        bool even = StretchProportionally && lineU < totalU && count > 0;
        double share = even ? totalU / count : 0;

        for (int i = start; i < end; i++)
        {
            var child = InternalChildren[i];
            var m = GetMargin(child);
            double contentW = even ? share - m.Left - m.Right : child.DesiredSize.Width * scale;
            if (contentW < 0) contentW = 0;
            double boxW = even ? share : contentW + m.Left + m.Right;
            child.Arrange(new Rect(x + (even ? 0 : m.Left), v + m.Top, boxW, maxV - m.Top - m.Bottom));
            x += boxW;
        }
    }
}
