using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EverNote.Views
{
    /// <summary>
    /// Interaction logic for NotesWindow.xaml
    /// </summary>
    public partial class NotesWindow : Window
    {
        private SpeechRecognitionEngine recognizer;
        public NotesWindow()
        {
            InitializeComponent();

            var currentCulture = (from x in SpeechRecognitionEngine.InstalledRecognizers()
                where x.Culture.Equals(Thread.CurrentThread.CurrentCulture)
                select x).FirstOrDefault();
            recognizer = new SpeechRecognitionEngine(currentCulture);

            GrammarBuilder builder = new GrammarBuilder();
            builder.AppendDictation();
            Grammar grammar = new Grammar(builder);
            recognizer.LoadGrammar(grammar);
            recognizer.SetInputToDefaultAudioDevice();

            recognizer.SpeechRecognized += RecognizerOnSpeechRecognized;

            var fonts = Fonts.SystemFontFamilies.OrderBy(x => x.Source).ToList();
            FontFamilyComboBox.ItemsSource = fonts;

            List<double> fontSizes = new List<double>(){8,9,10,11,12,14,16,18,24,28,36,72};
            FontSizeComboBox.ItemsSource = fontSizes;

        }
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            if (string.IsNullOrEmpty(App.UserId))
            {
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();

            }
        }

        private void RecognizerOnSpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            var recognizedText = e.Result.Text;

            RichTextBox.Document.Blocks.Add(new Paragraph(new Run(recognizedText)));

        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void RichTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            int amountOfCharacters = (new TextRange(RichTextBox.Document.ContentStart,RichTextBox.Document.ContentEnd)).Text.Length;
            
            statusTextBlock.Text = $"Document Length :{amountOfCharacters} Characters ";
        }

        private void BoldButton_OnClick(object sender, RoutedEventArgs e)
        {
            bool isChecked = (sender as ToggleButton).IsChecked ?? false;
            if (isChecked)
                RichTextBox.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Bold);
            else
                RichTextBox.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Normal);
        }

       
        private void SpeechButton_OnClick(object sender, RoutedEventArgs e)
        {
            bool isChecked = (sender as ToggleButton).IsChecked ?? false;
            if (isChecked)
            {
                recognizer.RecognizeAsync(RecognizeMode.Multiple);
            }
            else
            {
                recognizer.RecognizeAsyncStop();
            }
        }

        private void RichTextBox_OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            var selectedState = RichTextBox.Selection.GetPropertyValue(Inline.FontWeightProperty);
            BoldButton.IsChecked =  (selectedState != DependencyProperty.UnsetValue) &&  (selectedState.Equals(FontWeights.Bold));

            var selectedStyle = RichTextBox.Selection.GetPropertyValue(Inline.FontStyleProperty);
            BoldButton.IsChecked = (selectedStyle != DependencyProperty.UnsetValue) && (selectedStyle.Equals(FontStyles.Italic));

            var selectedDecoration = RichTextBox.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            BoldButton.IsChecked = (selectedDecoration != DependencyProperty.UnsetValue) && (selectedDecoration.Equals(TextDecorations.Underline));

            FontFamilyComboBox.SelectedItem = RichTextBox.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            FontSizeComboBox.Text = (RichTextBox.Selection.GetPropertyValue(Inline.FontSizeProperty)).ToString();
        }

        private void ItalicButton_OnClick(object sender, RoutedEventArgs e)
        {
            bool isChecked = (sender as ToggleButton).IsChecked ?? false;
            if (isChecked)
                RichTextBox.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Italic);
            else
                RichTextBox.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Normal);
        }

        private void UnderlineButton_OnClick(object sender, RoutedEventArgs e)
        {
            bool isChecked = (sender as ToggleButton).IsChecked ?? false;
            if (isChecked)
                RichTextBox.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
            else
            {
                TextDecorationCollection textDecorations;
                textDecorations = RichTextBox.Selection.GetPropertyValue(Inline.TextDecorationsProperty) as TextDecorationCollection;

                if (textDecorations.Contains(TextDecorations.Underline[0]))
                {
                    TextDecorationCollection noUnderline = new TextDecorationCollection(textDecorations);
                    noUnderline.Remove(TextDecorations.Underline[0]);  //this is a bool, and could replace Contains above
                    RichTextBox.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, noUnderline);
                }

            }
                
        }

        private void FontFamilyComboBox__OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontFamilyComboBox.SelectedItem != null)
            {
                RichTextBox.Selection.ApplyPropertyValue(Inline.FontFamilyProperty,FontFamilyComboBox.SelectedItem);

            }
        }

        private void FontSizeComboBox_OnTextInput(object sender, TextCompositionEventArgs e)
        {
            RichTextBox.Selection.ApplyPropertyValue(Inline.FontSizeProperty,FontSizeComboBox.Text);
        }


        private void FontSizeComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RichTextBox.Selection.ApplyPropertyValue(Inline.FontSizeProperty, FontSizeComboBox.SelectedItem.ToString());
        }
    }
}
