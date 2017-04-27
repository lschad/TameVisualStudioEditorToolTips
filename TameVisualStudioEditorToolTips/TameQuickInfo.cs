namespace TameVisualStudioEditorToolTips {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Windows.Input;
    using Microsoft.VisualStudio.Language.Intellisense;
    using Microsoft.VisualStudio.Text;
    using Microsoft.VisualStudio.Utilities;

    [Export(typeof(IQuickInfoSourceProvider))]
    [Name("Tame Quick Info")]
    [Order(Before = "Default Quick Info Presenter")]
    [ContentType("CSharp")]
    [ContentType("XAML")]
    [ContentType("XML")]
    internal class TameQuickInfo : IQuickInfoSourceProvider {

        public IQuickInfoSource TryCreateQuickInfoSource(ITextBuffer textBuffer) {
            return new CancelingQuickInfoSource();
        }

    }

    internal class CancelingQuickInfoSource : IQuickInfoSource {

        public void AugmentQuickInfoSession(IQuickInfoSession session, IList<Object> quickInfoContent, out ITrackingSpan applicableToSpan) {
            if (!Keyboard.IsKeyDown(Key.LeftCtrl) && !Keyboard.IsKeyDown(Key.RightCtrl)) {
                session.Dismiss();
            }
            applicableToSpan = null;
        }

        public void Dispose() {
        }

    }
}
