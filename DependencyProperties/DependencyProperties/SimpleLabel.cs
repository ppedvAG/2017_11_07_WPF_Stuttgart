using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace DependencyProperties
{
    public class SimpleLabel : FrameworkElement
    {
        public static readonly DependencyProperty fontSizeProperty;
        public static readonly DependencyProperty textProperty;
        public static readonly DependencyProperty foregroundProperty;
        public static readonly DependencyProperty backgroundProperty;

        static SimpleLabel()
        {
            fontSizeProperty = DependencyProperty.Register(
                name: "FontSize",
                propertyType: typeof(double),
                ownerType: typeof(SimpleLabel),
                typeMetadata: new FrameworkPropertyMetadata(
                    defaultValue: 11.0,
                    flags: FrameworkPropertyMetadataOptions.AffectsMeasure),
                validateValueCallback: v => (double)v > 0);

            textProperty = DependencyProperty.Register(
                name: nameof(Text),
                propertyType: typeof(string),
                ownerType: typeof(SimpleLabel),
                typeMetadata: new FrameworkPropertyMetadata(
                    defaultValue: string.Empty,
                    flags: FrameworkPropertyMetadataOptions.AffectsMeasure |
                           FrameworkPropertyMetadataOptions.AffectsRender));

            foregroundProperty = DependencyProperty.Register(
                nameof(Foreground),
                typeof(Brush),
                typeof(SimpleLabel),
                typeMetadata: new PropertyMetadata(Brushes.Black));

            backgroundProperty = DependencyProperty.Register(
               nameof(Background),
               typeof(Brush),
               typeof(SimpleLabel),
               typeMetadata: new PropertyMetadata(Brushes.LightGray));
        }

        public double FontSize
        {
            get => (double)GetValue(fontSizeProperty);
            set => SetValue(fontSizeProperty, value);
        }

        public string Text
        {
            get => (string)GetValue(textProperty);
            set => SetValue(textProperty, value);
        }

        public Brush Foreground
        {
            get => (Brush)GetValue(foregroundProperty);
            set => SetValue(foregroundProperty, value);
        }

        public Brush Background
        {
            get => (Brush)GetValue(backgroundProperty);
            set => SetValue(backgroundProperty, value);
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            drawingContext.DrawRectangle(Background, null, new Rect(RenderSize));
            drawingContext.DrawText(GetFormattedText(), new Point(2.5, 2.5));
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            var text = GetFormattedText();
            return new Size(text.Width + 5, text.Height + 5);
        }

        private FormattedText GetFormattedText() => new FormattedText(
            Text,
            CultureInfo.InvariantCulture,
            FlowDirection.LeftToRight,
            new Typeface("Arial"),
            FontSize,
            Foreground);
    }
}
